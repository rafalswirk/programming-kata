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
        private readonly SolutionExplorerPanel solutionExplorerPanel = new();
        private readonly ToolsPanel toolsPanel = new();
        private PanelManager _panelManager;

        public MainWindow()
        {
            InitializeComponent();
            _panelManager = new PanelManager(grdShowPinned, grdShowUnpinned);
            _panelManager.RegisterPanel(solutionExplorerPanel, btnSolutionExplorer);
            _panelManager.RegisterPanel(toolsPanel, btnTools);
        }

        private void btnSolutionExplorer_MouseEnter(object sender, MouseEventArgs e)
        {
            _panelManager.ShowUnpinnedPanel(solutionExplorerPanel);
        }

        private void btnTools_MouseEnter(object sender, MouseEventArgs e)
        {
            _panelManager.ShowUnpinnedPanel(toolsPanel);
        }

        private void grdMain_MouseEnter(object sender, MouseEventArgs e)
        {
            _panelManager.CleanupGrid();
        }
    }
}
