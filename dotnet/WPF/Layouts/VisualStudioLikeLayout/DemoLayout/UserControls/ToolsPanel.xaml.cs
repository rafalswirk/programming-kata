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

namespace DemoLayout.UserControls
{
    /// <summary>
    /// Interaction logic for ToolsPanel.xaml
    /// </summary>
    public partial class ToolsPanel : PinablePanelBase
    {
        public ToolsPanel()
        {
            InitializeComponent();
        }

        private void btnPin_Click(object sender, RoutedEventArgs e)
        {
            FireOnPinClicked();
        }
    }
}
