using DemoLayout.Converters;
using DemoLayout.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace DemoLayout
{
    internal class PanelManager
    {
        public const double DefaultPanelWidth = 200;

        private Dictionary<UIElement, double> panelWidths = new Dictionary<UIElement, double>();
        private bool _firstColumn = true;
        private Grid _pinnedPanelContainer;
        private GridSplitter _pinnedPanelContainerSplitter;
        private readonly Grid _pinnedLayer;
        private readonly Grid _unpinnedLayer;
        private readonly List<PinnedPanelInfo> _panels = new List<PinnedPanelInfo>();

        internal PanelManager(Grid pinnedLayer, Grid unpinnedLayer)
        {
            _pinnedLayer = pinnedLayer;
            _unpinnedLayer = unpinnedLayer;
        }

        internal void RegisterPanel(PinablePanelBase panel, Button panelButton)
        {
            panelWidths.Add(panel, PanelManager.DefaultPanelWidth);
            panel.OnPinClicked += Panel_OnPinClicked;
            var binding = new Binding("IsPinned");
            binding.Source = panel;
            binding.Converter = new BoolToCollapsed();
            panelButton.SetBinding(Button.VisibilityProperty, binding);
        }

        internal void ShowUnpinnedPanel(UserControl panel)
        {
            if (_unpinnedLayer.Children.Contains(panel))
                return;
            CleanupGrid();
            ShowPanel(panel, _unpinnedLayer);
        }

        private void ShowPanel(UserControl panel, Grid layer)
        {
            layer.Children.Add(panel);
            layer.ColumnDefinitions[1].Width = new GridLength(panelWidths[panel], GridUnitType.Pixel);
            var gridSplitter = new GridSplitter();
            gridSplitter.Width = 5;
            gridSplitter.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetColumn(gridSplitter, 1);
            layer.Children.Add(gridSplitter);
            Grid.SetColumn(panel, 1);
        }

        internal void CleanupGrid()
        {
            if (_unpinnedLayer.Children.Count > 0)
            {
                panelWidths[_unpinnedLayer.Children[1]] = _unpinnedLayer.ColumnDefinitions[1].Width.Value;
                _unpinnedLayer.Children.Clear();
            }
        }

        private void Panel_OnPinClicked(object? sender, EventArgs e)
        {
            var panel = sender as PinablePanelBase;
            if (panel == null)
                return;
            if (_unpinnedLayer.Children.Contains(panel) && panel.IsPinned)
            {
                CleanupGrid();
                PinPanel(panel);

            }
            else
            {
                UnpinPanel(panel);
            }
        }

        private void UnpinPanel(UIElement panel)
        {
            var panelToRemove = _panels.Single(info => info.Panel == panel);
            _panels.Remove(panelToRemove);
            _pinnedPanelContainer.Children.Remove(panelToRemove.Panel);
            if (panelToRemove.PanelSplitter != null)
                _pinnedPanelContainer.Children.Remove(panelToRemove.PanelSplitter);
            if (panelToRemove.SplitterColumn != null)
                _pinnedPanelContainer.ColumnDefinitions.Remove(panelToRemove.SplitterColumn);
            _pinnedPanelContainer.ColumnDefinitions.Remove(panelToRemove.Definition);

            if (_panels.Count == 1)
                RemoveSplitterForSinglePanel();
            if (_panels.Count == 0)
                CleanupPinnableLayer();
        }

        private void CleanupPinnableLayer()
        {
            _pinnedLayer.Children.Remove(_pinnedPanelContainerSplitter);
            _pinnedLayer.Children.Remove(_pinnedPanelContainer);
            _pinnedLayer.ColumnDefinitions.Last().Width = new GridLength(0, GridUnitType.Auto);
        }

        private void RemoveSplitterForSinglePanel()
        {
            var panel = _panels.First();
            _pinnedPanelContainer.Children.Remove(panel.PanelSplitter);
            panel.PanelSplitter = null;

        }

        private void PinPanel(PinablePanelBase panel)
        {
            if(_pinnedPanelContainer == null || _pinnedPanelContainer.ColumnDefinitions.Count == 0)
            {
                AddMainContainer();
                _firstColumn = false;
                AddPanel(panel, null, null, true);
                return;
            }

            var gridSplitterData = GenerateSplitterInNewColumn();
            AddPanel(panel, gridSplitterData.SplitterColumn, gridSplitterData.Splitter);
        }

        private (ColumnDefinition SplitterColumn, GridSplitter Splitter) GenerateSplitterInNewColumn()
        {
            var column = new ColumnDefinition();
            column.Width = new GridLength(5, GridUnitType.Auto);
            _pinnedPanelContainer.ColumnDefinitions.Add(column);
            var gridSplitter = new GridSplitter
            {
                Width = 5,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Grid.SetColumn(gridSplitter, _pinnedPanelContainer.ColumnDefinitions.Count - 1);
            _pinnedPanelContainer.Children.Add(gridSplitter);
            return (column, gridSplitter);
        }

        private void AddPanel(PinablePanelBase panel, ColumnDefinition splitterColumn, GridSplitter splitter, bool first = false)
        {
            var column = new ColumnDefinition();
            if (first)
                column.Width = new GridLength(1, GridUnitType.Star);
            else
                column.Width = new GridLength(panelWidths[panel], GridUnitType.Pixel);
            _pinnedPanelContainer.ColumnDefinitions.Add(column);

            Grid.SetColumn(panel, _pinnedPanelContainer.ColumnDefinitions.Count - 1);
            _pinnedPanelContainer.Children.Add(panel);

            _panels.Add(new PinnedPanelInfo
            {
                Panel = panel,
                Definition = column,
                SplitterColumn = splitterColumn,
                PanelSplitter = splitter
            });
        }

        private void AddMainContainer()
        {
            _pinnedPanelContainerSplitter = new GridSplitter
            {
                Width = 5,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Grid.SetColumn(_pinnedPanelContainerSplitter, 1);
            _pinnedLayer.Children.Add(_pinnedPanelContainerSplitter);

            _pinnedPanelContainer = new Grid();
            Grid.SetColumn(_pinnedPanelContainer, 2);
            _pinnedLayer.Children.Add(_pinnedPanelContainer);
        }
    }
}
