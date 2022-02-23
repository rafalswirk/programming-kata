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

namespace DemoLayout
{
    internal class PanelManager
    {
        public const double DefaultPanelWidth = 200;

        private Dictionary<UIElement, double> panelWidths = new Dictionary<UIElement, double>();
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
            layer.ColumnDefinitions[1].Width = new GridLength(panelWidths[panel]);
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
            _pinnedLayer.Children.Remove(panelToRemove.Panel);
            _pinnedLayer.Children.Remove(panelToRemove.PanelSplitter);
            _pinnedLayer.ColumnDefinitions.Remove(panelToRemove.Definition);
            _panels.Remove(panelToRemove);
        }

        private void PinPanel(PinablePanelBase panel)
        {
            var columnDefinition = new ColumnDefinition();
            columnDefinition.SharedSizeGroup = "PanelSizeGroup";
            _pinnedLayer.ColumnDefinitions.Add(columnDefinition);

            _pinnedLayer.Children.Add(panel);
            _pinnedLayer.ColumnDefinitions[1].Width = new GridLength(panelWidths[panel]);
            var gridSplitter = new GridSplitter();
            gridSplitter.Width = 5;
            gridSplitter.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetColumn(gridSplitter, _panels.Count + 1);
            _pinnedLayer.Children.Add(gridSplitter);
            Grid.SetColumn(panel, _panels.Count + 1);

            _panels.Add(new PinnedPanelInfo 
            {
                Panel = panel,
                PanelSplitter = gridSplitter,
                Definition = columnDefinition
            });
        }
    }
}
