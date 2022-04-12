using DemoLayout.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DemoLayout
{
    internal class PinnedPanelInfo
    {
        public PinablePanelBase Panel { get; set; }
        public GridSplitter PanelSplitter { get; set; }
        public ColumnDefinition Definition { get; set; }
        public ColumnDefinition SplitterColumn { get; internal set; }
    }
}
