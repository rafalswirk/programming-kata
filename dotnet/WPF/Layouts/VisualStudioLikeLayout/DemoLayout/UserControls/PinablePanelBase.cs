using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DemoLayout.UserControls
{
    public abstract class PinablePanelBase: UserControl
    {
        public bool IsPinned
        {
            get { return (bool)GetValue(IsPinnedProperty); }
            set { SetValue(IsPinnedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPinned.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPinnedProperty =
            DependencyProperty.Register("IsPinned", typeof(bool), typeof(PinablePanelBase), new PropertyMetadata(false));

        public event EventHandler? OnPinClicked;

        protected void FireOnPinClicked()
        {
            IsPinned = true;
            OnPinClicked?.Invoke(this, new EventArgs());
        }
    }
}
