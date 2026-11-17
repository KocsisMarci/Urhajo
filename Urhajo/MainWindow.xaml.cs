using System.Security.Policy;
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

namespace Urhajo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /*
    enum Statusz { 
        Sikeres,
        Sikertelen,
        Folyamatban
    };
        Esetleges enum.
     */
    public partial class MainWindow : Window
    {

        public class Urhajo { 
            public string Nev { get; set; }
            public int Legenyseg { get; set; }
            public int MaxHatotav { get; set; }  //Itt érdemes lehet megfontolni a long típus használatát.

            public int UzemanyagSzint { get; set; }

            public string Gyarto { get; set; }

            public string KuldetesStatusz { get; set; }  //Ez egy enum (Statusz) típus is lehetne

            public int InditasEve { get; set; }


            public Urhajo(string nev, int legenyseg ,int maxhato, int uzemanyag, string gyarto, string statusz, int ev) {
                this.Nev = nev;
                this.Legenyseg = legenyseg;
                this.MaxHatotav = maxhato;

                this.UzemanyagSzint = uzemanyag;
                this.Gyarto = gyarto;
                this.KuldetesStatusz=statusz;
                this.InditasEve = ev;
            
            }
        
        };

        public List<Urhajo> urhajok = new List<Urhajo> {
            new Urhajo("Falcon-9", 7,550000, 87, "SpaceX", "Sikeres", 2020),
            new Urhajo("Orion-X1", 4,820000, 73, "NASA", "Folyamatban", 2023),
            new Urhajo("StarRider", 12, 910000, 66, "Boeling", "Sikeres", 2019),
            new Urhajo("SolarWind", 3, 300000, 92, "ESA", "Sikertelen", 2018),
            new Urhajo("Galaxy-Cruiser", 18, 1200000, 54, "Blue Origin", "Sikeres", 2022),
            new Urhajo("Nova-Prime", 10, 760000, 80, "Roscomos", "Sikeres", 2017),
            new Urhajo("Pioneer-VII", 6, 640000, 70, "NASA", "Folyamatban", 2024),
            new Urhajo("Titan-Hawk", 14, 1050000, 48, "SpaceX", "Sikeres", 2021),
            new Urhajo("CosmosJet", 5, 430000, 93, "JAXA", "Sikertelen", 2016),
            new Urhajo("Nebule-FX", 11, 870000, 60, "ESA", "Sikeres", 2020)

        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = urhajok;
            dataGrid.Items.Refresh();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }
    }
}