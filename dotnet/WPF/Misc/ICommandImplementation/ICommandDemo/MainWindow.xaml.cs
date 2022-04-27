using ICommandDemo.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ICommandDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int accountLimit = 200;
        public int AccountLimit 
        { 
            get => accountLimit; 
            set 
            {
                accountLimit = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AccountLimit))); 
            } 
        }
        public int CashToWithdraw { get; set; } = 60;
        public ICommand WithdrawCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            WithdrawCommand = new RelayCommand(_ =>
            {
                AccountLimit -= CashToWithdraw;
            }, _ => CashToWithdraw <= AccountLimit);
            InitializeComponent();
        }

    }
}
