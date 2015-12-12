using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace NumereCopii
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int index = 0;
        private bool afisareLitere = false;

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AfiseazaUrmator();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                default:
                case Key.Right:
                case Key.Space:
                    AfiseazaUrmator();
                    break;
                case Key.Left:
                case Key.Back:
                    AfiseazaAnterior();
                    break;
                case Key.Escape:
                    AfiseazaCifre(0);
                    break;
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                    AfiseazaCifre(e.Key - Key.D0);
                    break;
                case Key.A:
                case Key.B:
                case Key.C:
                case Key.D:
                case Key.E:
                case Key.F:
                case Key.G:
                case Key.H:
                case Key.I:
                case Key.J:
                case Key.K:
                case Key.L:
                case Key.M:
                case Key.N:
                case Key.O:
                case Key.P:
                case Key.Q:
                case Key.R:
                case Key.S:
                case Key.T:
                case Key.U:
                case Key.V:
                case Key.W:
                case Key.X:
                case Key.Y:
                case Key.Z:
                    AfiseazaLitere((char)('A' + (e.Key - Key.A)));
                    break;
            }
        }

        private void AfiseazaUrmator()
        {
            index++;
            if ((!afisareLitere && index > 100) || (afisareLitere && (index > ('Z' - 'A'))))
                index = 0;
            Afiseaza();
        }

        private void AfiseazaAnterior()
        {
            index--;
            if (index < 0)
                index = 0;
            Afiseaza();
        }

        private void AfiseazaCifre(int numar)
        {
            afisareLitere = false;
            if (numar < 0 || numar > 100)
                numar = 0;
            this.index = numar;
            Afiseaza();
        }

        private void AfiseazaLitere(char caracter)
        {
            afisareLitere = true;
            if (caracter < 'A' || caracter > 'Z')
                caracter = 'A';
            this.index = caracter - 'A';
            Afiseaza();
        }

        private void Afiseaza()
        {
            TextBlock.Text = !afisareLitere ? index.ToString() : ((char)('A' + index)).ToString();
            AplicaCuloare();
        }

        private void AplicaCuloare()
        {
            char caracter = TextBlock.Text.Last();
            int indexCuloare;
            if (char.IsNumber(caracter))
                indexCuloare = int.Parse(caracter.ToString(), CultureInfo.InvariantCulture) % culori.Length;
            else
                indexCuloare = (caracter - 'A' + 1) % culori.Length;
            TextBlock.Foreground = culori[indexCuloare];
        }

        private static Brush[] culori = new Brush[] { Brushes.White, Brushes.Red, Brushes.Yellow, Brushes.Blue, Brushes.Green, Brushes.Orange, Brushes.DarkMagenta, Brushes.DeepPink, Brushes.SaddleBrown, Brushes.DimGray };
    }
}
