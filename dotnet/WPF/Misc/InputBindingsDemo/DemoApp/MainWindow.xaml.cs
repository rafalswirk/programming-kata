using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace DemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer mediaElement = new MediaPlayer();

        public RelayCommand WolfSound { get; private set; }
        public RelayCommand BeeSound { get; private set; }
        public RelayCommand CatSound { get; private set; }
        public RelayCommand DonkeySound { get; private set; }
        public RelayCommand FrogSound { get; private set; }
        public RelayCommand LionSound { get; private set; }
        public RelayCommand OwlSound { get; private set; }

        public MainWindow()
        {
            WolfSound = new RelayCommand(() =>
            {
                PlaySound("wolf.mp3");
            });
            BeeSound = new RelayCommand(() =>
            {
                PlaySound("bee.mp3");
            });
            CatSound = new RelayCommand(() =>
            {
                PlaySound("cat.mp3");
            });
            DonkeySound = new RelayCommand(() =>
            {
                PlaySound("donkey.mp3");
            });
            FrogSound = new RelayCommand(() =>
            {
                PlaySound("frogs.mp3");
            });
            LionSound = new RelayCommand(() =>
            {
                PlaySound("lion.mp3");
            });
            OwlSound = new RelayCommand(() =>
            {
                PlaySound("owl.mp3");
            });
            
            InitializeComponent();
        }

        private void PlaySound(string soundName)
        {
            mediaElement.Open(new Uri(Path.Combine("AnimalSounds", soundName), UriKind.Relative));
            mediaElement.Play();
        }
    }
}
