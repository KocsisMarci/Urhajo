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

            public override string ToString()
            {
                return $"Név: {Nev}, legénység: {Legenyseg}, maxhatótáv: {MaxHatotav}, üzemanayag szint: {UzemanyagSzint} gyártó: {Gyarto}, küldetés státusza {KuldetesStatusz}, indítás éve: {InditasEve}";
            }

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
            MessageBox.Show($"Ennyi űrhajó van rögzítve: {urhajok.Count} ");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int legnagyobbHatoTav = urhajok[0].MaxHatotav;
            string neve = urhajok[0].Nev;

            foreach (Urhajo hajo in urhajok) {
                if (hajo.MaxHatotav > legnagyobbHatoTav) { 
                    legnagyobbHatoTav=hajo.MaxHatotav;
                    neve = hajo.Nev;
                }
            }

            MessageBox.Show($"A legnagyobb hatótávú hajó neve: {neve}, hatótáva: {legnagyobbHatoTav}");
           
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var sikeresek = urhajok.Where(urhajo => urhajo.KuldetesStatusz == "Sikeres").ToList();

            MessageBox.Show("Sikeres küldetésen lévő hajók neve, legénysége: ");

            foreach (var hajo in sikeresek) {
                Urhajo jo=(Urhajo)hajo;
                MessageBox.Show($"{jo.Nev}, {jo.Legenyseg}");
            }


        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            double atlagos = urhajok.Average(hajo => hajo.Legenyseg);
            MessageBox.Show($"Átlagos legénységszám: {Math.Round(atlagos,0)}");

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var csoportositva = urhajok.GroupBy(urhajo => urhajo.Gyarto).ToList();
            foreach (var elem in csoportositva) {
                MessageBox.Show(csoportositva.ToString());
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

            if (keresett.Text != "")
            {
                //Nem lesz érzékeny kis és nagy betűkre.
                Urhajo talalat = urhajok.FirstOrDefault(urhajo => urhajo.Nev.ToLower() == keresett.Text.ToLower());
                /*
                 Ha gyűártó alapján keresnénk Where lehetne és a végén ToList(), az ellenőrzésben pedig a 
                talat.Count lenne a nyerő.
               */


                if (talalat is null)
                {
                    MessageBox.Show("Nincs ilyen nevű űrhajó");
                }

                else
                {

                    MessageBox.Show(talalat.ToString());
                    keresett.Text = "";
                }
            }

            else
            {
                MessageBox.Show("Muszáj megadni adatot");
            }
        }


        private void valtva(object sender, RoutedEventArgs e) { 
            Urhajo valasztott=dataGrid.SelectedItem as Urhajo;

            progress.Value = valasztott.UzemanyagSzint;
        }

       
    }
}