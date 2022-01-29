using DemoLayout.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoLayout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const double DefaultPanelWidth = 200;

        private readonly SolutionExplorerPanel solutionExplorerPanel = new();
        private readonly ToolsPanel toolsPanel = new();
        private Dictionary<UIElement, double> panelWidths = new Dictionary<UIElement, double>();

        public MainWindow()
        {
            InitializeComponent();
            panelWidths.Add(solutionExplorerPanel, DefaultPanelWidth);
            panelWidths.Add(toolsPanel, DefaultPanelWidth);
        }

        private void btnSolutionExplorer_MouseEnter(object sender, MouseEventArgs e)
        {
            ShowUnpinnedPanel(solutionExplorerPanel);
        }

        private void ShowUnpinnedPanel(UserControl panel)
        {
            CleanupGrid();
            var gridSplitter = new GridSplitter();
            gridSplitter.Width = 5;
            Grid.SetColumn(gridSplitter, 0);
            grdShowUnpinned.Children.Add(gridSplitter);
            Grid.SetColumn(panel, 1);
            grdShowUnpinned.ColumnDefinitions[1].Width = new GridLength(panelWidths[panel]);
            grdShowUnpinned.Children.Add(panel);
        }

        private void btnTools_MouseEnter(object sender, MouseEventArgs e)
        {
            ShowUnpinnedPanel(toolsPanel);
        }

        private void grdMain_MouseEnter(object sender, MouseEventArgs e)
        {
            CleanupGrid();
        }

        private void CleanupGrid()
        {
            if (grdShowUnpinned.Children.Count > 0)
            {
                panelWidths[grdShowUnpinned.Children[1]] = grdShowUnpinned.ColumnDefinitions[1].Width.Value;
                grdShowUnpinned.Children.Clear();
            }
        }
    }
}
