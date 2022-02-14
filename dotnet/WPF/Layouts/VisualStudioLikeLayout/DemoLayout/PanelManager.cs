using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DemoLayout
{
    internal class PanelManager
    {
        public const double DefaultPanelWidth = 200;

        private readonly Grid layer;

        public PanelManager(Grid layer)
        {
            this.layer = layer;
        }
    }
}
