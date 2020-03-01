using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ristinolla
{
    public partial class UusiTietokonePeliValikko : Form
    {
        public UusiTietokonePeliValikko()
        {
            InitializeComponent();
        }
        string pelaajan1KokoNimi = TietojenSyottoTietokone.pelaajan1KokoNimi;
        int voittaja = TietokonePeli.Voittaja;
        int kokonaisAika = TietokonePeli.kokonaisAika;
        //tallentaa voitot, tappiot ja tasapelit pelin lopputuloksen mukaan pelaajien tiedostoihin
        void LisaaVoitto(int voittaja)
        {
            if (voittaja == 0)
            {
                string pelaaja1tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string pelaaja1tiedostonOsoite = Path.Combine(pelaaja1tietojenOsoite, pelaajan1KokoNimi + ".txt");
                StreamReader sr1 = new StreamReader($@"{pelaaja1tiedostonOsoite}");
                sr1.ReadLine();
                sr1.ReadLine();
                sr1.ReadLine();
                sr1.ReadLine();
                string pelaajan1KaikkiTasapelit = sr1.ReadLine();
                sr1.Close();
                int pelaajan1TasapelienMaara;
                bool oliNumero = Int32.TryParse(pelaajan1KaikkiTasapelit, out pelaajan1TasapelienMaara);
                if (oliNumero)
                {
                    pelaajan1TasapelienMaara = pelaajan1TasapelienMaara + 1;
                    void lineChanger(string newText, string fileName, int line_to_edit)
                    {
                        string[] arrLine = File.ReadAllLines(fileName);
                        arrLine[line_to_edit - 1] = newText;
                        File.WriteAllLines(fileName, arrLine);
                    }
                    lineChanger(pelaajan1TasapelienMaara.ToString(), pelaaja1tiedostonOsoite, 5);

                }
                StreamReader sr = new StreamReader($@"{pelaaja1tiedostonOsoite}");
                sr.ReadLine();
                sr.ReadLine();
                pelaaja1AikaLabel.Text = "Pelaajan " + pelaajan1KokoNimi + " pelien yhteiskesto: " + sr.ReadLine() + " sekuntia";
                pelaaja1VoittoLabel.Text = "Pelaajan " + pelaajan1KokoNimi + " voittojen määrä: " + sr.ReadLine();
                pelaaja1TasapeliLabel.Text = "Pelaajan " + pelaajan1KokoNimi + " tasapelien määrä : " + sr.ReadLine();
                pelaaja1HavioLabel.Text = "Pelaajan " + pelaajan1KokoNimi + " häviöiden määrä : " + sr.ReadLine();
                sr.Close();


                string tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string tietokoneTiedostoOsoite = Path.Combine(tietojenOsoite, "ristinollatietokone" + ".txt");
                StreamReader sr2 = new StreamReader($@"{tietokoneTiedostoOsoite}");
                sr2.ReadLine();
                sr2.ReadLine();
                sr2.ReadLine();
                sr2.ReadLine();
                string tietokoneenKaikkiTasapelit = sr2.ReadLine();
                sr2.Close();
                int tietokoneenTasapelienMaara;
                bool oliNumero2 = Int32.TryParse(tietokoneenKaikkiTasapelit, out tietokoneenTasapelienMaara);
                if (oliNumero2)
                {
                    tietokoneenTasapelienMaara = tietokoneenTasapelienMaara + 1;
                    void lineChanger(string newText, string fileName, int line_to_edit)
                    {
                        string[] arrLine = File.ReadAllLines(fileName);
                        arrLine[line_to_edit - 1] = newText;
                        File.WriteAllLines(fileName, arrLine);
                    }
                    lineChanger(tietokoneenTasapelienMaara.ToString(), tietokoneTiedostoOsoite, 5);

                }
                StreamReader sr3 = new StreamReader($@"{tietokoneTiedostoOsoite}");

                sr3.ReadLine();
                sr3.ReadLine();
                tietokoneenAika.Text = "Tietokoneen pelien yhteiskesto : " + sr3.ReadLine() + " sekuntia";
                tietokoneenVoitot.Text = "Tietokoneen voittojen määrä : " + sr3.ReadLine();
                tietokoneenTasapelit.Text = "Tietokoneen tasapelien määrä : " + sr3.ReadLine();
                tietokoneenHaviot.Text = "Tietokoneen haviöiden määrä : " + sr3.ReadLine();
                sr3.Close();


            }
            else if (voittaja == 1)
            {
                string pelaaja1tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string pelaaja1tiedostonOsoite = Path.Combine(pelaaja1tietojenOsoite, pelaajan1KokoNimi + ".txt");
                StreamReader sr = new StreamReader($@"{pelaaja1tiedostonOsoite}");
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                string pelaajan1KaikkiVoitot = sr.ReadLine();
                sr.Close();
                int pelaajan1VoittojenMaara;
                bool oliNumero = Int32.TryParse(pelaajan1KaikkiVoitot, out pelaajan1VoittojenMaara);
                if (oliNumero)
                {
                    pelaajan1VoittojenMaara = pelaajan1VoittojenMaara + 1;
                    void lineChanger(string newText, string fileName, int line_to_edit)
                    {
                        string[] arrLine = File.ReadAllLines(fileName);
                        arrLine[line_to_edit - 1] = newText;
                        File.WriteAllLines(fileName, arrLine);
                    }
                    lineChanger(pelaajan1VoittojenMaara.ToString(), pelaaja1tiedostonOsoite, 4);

                }
                
                StreamReader sr2 = new StreamReader($@"{pelaaja1tiedostonOsoite}");
                sr2.ReadLine();
                sr2.ReadLine();
                pelaaja1AikaLabel.Text = "Pelaajan " + pelaajan1KokoNimi + " pelien yhteiskesto: " + sr2.ReadLine() + " sekuntia";
                pelaaja1VoittoLabel.Text = "Pelaajan " + pelaajan1KokoNimi + " voittojen määrä: " + sr2.ReadLine();
                pelaaja1TasapeliLabel.Text = "Pelaajan " + pelaajan1KokoNimi + " tasapelien määrä : " + sr2.ReadLine();
                pelaaja1HavioLabel.Text = "Pelaajan " + pelaajan1KokoNimi + " häviöiden määrä : " + sr2.ReadLine();
                sr2.Close();
                string tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string tietokoneTiedostoOsoite = Path.Combine(tietojenOsoite, "ristinollatietokone" + ".txt");
                StreamReader sr3 = new StreamReader($@"{tietokoneTiedostoOsoite}");
                sr3.ReadLine();
                sr3.ReadLine();
                sr3.ReadLine();
                sr3.ReadLine();
                sr3.ReadLine();
                string tietokoneenKaikkiHaviot = sr3.ReadLine();
                sr3.Close();
                int tietokoneenHavioidenMaara;
                bool oliNumero2 = Int32.TryParse(tietokoneenKaikkiHaviot, out tietokoneenHavioidenMaara);
                if (oliNumero2)
                {
                    tietokoneenHavioidenMaara = tietokoneenHavioidenMaara + 1;
                    void lineChanger(string newText, string fileName, int line_to_edit)
                    {
                        string[] arrLine = File.ReadAllLines(fileName);
                        arrLine[line_to_edit - 1] = newText;
                        File.WriteAllLines(fileName, arrLine);
                    }
                    lineChanger(tietokoneenHavioidenMaara.ToString(), tietokoneTiedostoOsoite, 6);

                }
                StreamReader sr4 = new StreamReader($@"{tietokoneTiedostoOsoite}");
                sr4.ReadLine();
                sr4.ReadLine();
                tietokoneenAika.Text = "Tietokoneen pelien yhteiskesto : " + sr4.ReadLine() + " sekuntia";
                tietokoneenVoitot.Text = "Tietokoneen voittojen määrä : " + sr4.ReadLine();
                tietokoneenTasapelit.Text = "Tietokoneen tasapelien määrä : " + sr4.ReadLine();
                tietokoneenHaviot.Text = "Tietokoneen haviöiden määrä : " + sr4.ReadLine();
                sr4.Close();
            }
            else if (voittaja == 2)
            {
                string tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string tietokoneTiedostoOsoite = Path.Combine(tietojenOsoite, "ristinollatietokone" + ".txt");
                StreamReader sr = new StreamReader($@"{tietokoneTiedostoOsoite}");
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                string tietokoneVoitot = sr.ReadLine();
                sr.Close();
                int tietokoneVoittojenMaara;
                bool oliNumero = Int32.TryParse(tietokoneVoitot, out tietokoneVoittojenMaara);
                if (oliNumero)
                {
                    tietokoneVoittojenMaara = tietokoneVoittojenMaara + 1;
                    void lineChanger(string newText, string fileName, int line_to_edit)
                    {
                        string[] arrLine = File.ReadAllLines(fileName);
                        arrLine[line_to_edit - 1] = newText;
                        File.WriteAllLines(fileName, arrLine);
                    }
                    lineChanger(tietokoneVoittojenMaara.ToString(), tietokoneTiedostoOsoite, 4);

                }
                StreamReader sr2 = new StreamReader($@"{tietokoneTiedostoOsoite}");
                sr2.ReadLine();
                sr2.ReadLine();
                tietokoneenAika.Text = "Tietokoneen pelien yhteiskesto : " + sr2.ReadLine();
                tietokoneenVoitot.Text = "Tietokoneen voittojen määrä : " + sr2.ReadLine();
                tietokoneenTasapelit.Text = "Tietokoneen tasapelien määrä : " + sr2.ReadLine();
                tietokoneenHaviot.Text = "Tietokoneen haviöiden määrä : " + sr2.ReadLine();
                sr2.Close();
                string pelaaja1tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string pelaaja1tiedostonOsoite = Path.Combine(pelaaja1tietojenOsoite, pelaajan1KokoNimi + ".txt");
                StreamReader sr3 = new StreamReader($@"{pelaaja1tiedostonOsoite}");
                sr3.ReadLine();
                sr3.ReadLine();
                sr3.ReadLine();
                sr3.ReadLine();
                sr3.ReadLine();
                string pelaajan1KaikkiHaviot = sr3.ReadLine();
                sr3.Close();
                int pelaajan1HavioidenMaara;
                bool oliNumero2 = Int32.TryParse(pelaajan1KaikkiHaviot, out pelaajan1HavioidenMaara);
                if (oliNumero2)
                {
                    pelaajan1HavioidenMaara = pelaajan1HavioidenMaara + 1;
                    void lineChanger(string newText, string fileName, int line_to_edit)
                    {
                        string[] arrLine = File.ReadAllLines(fileName);
                        arrLine[line_to_edit - 1] = newText;
                        File.WriteAllLines(fileName, arrLine);
                    }
                    lineChanger(pelaajan1HavioidenMaara.ToString(), pelaaja1tiedostonOsoite, 6);

                }
                StreamReader sr4 = new StreamReader($@"{pelaaja1tiedostonOsoite}");
                sr4.ReadLine();
                sr4.ReadLine();
                pelaaja1AikaLabel.Text = "Pelaajan " + pelaajan1KokoNimi + " pelien yhteiskesto: " + sr4.ReadLine() + " sekuntia";
                pelaaja1VoittoLabel.Text = "Pelaajan " + pelaajan1KokoNimi + " voittojen määrä: " + sr4.ReadLine();
                pelaaja1TasapeliLabel.Text = "Pelaajan " + pelaajan1KokoNimi + " tasapelien määrä : " + sr4.ReadLine();
                pelaaja1HavioLabel.Text = "Pelaajan " + pelaajan1KokoNimi + " häviöiden määrä : " + sr4.ReadLine();
                sr4.Close();
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TietokonePeli r = new TietokonePeli();
            r.ShowDialog();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu r = new Menu();
            r.ShowDialog();
            this.Close();
        }

        private void UusiTietokonePeliValikko_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //Tallentaa pelin keston pelaajien tietoihin
        private void UusiTietokonePeliValikko_Load(object sender, EventArgs e)
        {
            string pelaaja1tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pelaaja1tiedostonOsoite = Path.Combine(pelaaja1tietojenOsoite, pelaajan1KokoNimi + ".txt");
            StreamReader sr = new StreamReader($@"{pelaaja1tiedostonOsoite}");
            sr.ReadLine();
            sr.ReadLine();
            string aikaisempiAika = sr.ReadLine();
            sr.Close();
            int aika;
            bool oliNumero = Int32.TryParse(aikaisempiAika, out aika);
            if (oliNumero)
            {
                aika = kokonaisAika + aika;
                void lineChanger(string newText, string fileName, int line_to_edit)
                {
                    string[] arrLine = File.ReadAllLines(fileName);
                    arrLine[line_to_edit - 1] = newText;
                    File.WriteAllLines(fileName, arrLine);
                }
                lineChanger(aika.ToString(), pelaaja1tiedostonOsoite, 3);

            }
            
            string tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string tietokoneTiedostoOsoite = Path.Combine(tietojenOsoite, "ristinollatietokone" + ".txt");
            StreamReader sr2 = new StreamReader($@"{tietokoneTiedostoOsoite}");
            sr2.ReadLine();
            sr2.ReadLine();
            string aikaisempiAika2 = sr2.ReadLine();
            sr2.Close();
            int aika2;
            bool oliNumero2 = Int32.TryParse(aikaisempiAika2, out aika2);
            if (oliNumero2)
            {
                aika2 = kokonaisAika + aika2;
                void lineChanger(string newText, string fileName, int line_to_edit)
                {
                    string[] arrLine = File.ReadAllLines(fileName);
                    arrLine[line_to_edit - 1] = newText;
                    File.WriteAllLines(fileName, arrLine);
                }
                lineChanger(aika2.ToString(), tietokoneTiedostoOsoite, 3);

            }
            //tutkii kumpi voitti
            if (voittaja == 0)
            {
                VoittajaTeksti.Text = "Tasapeli!!";
                LisaaVoitto(voittaja);
            }
            if (voittaja == 1)
            {
                LisaaVoitto(voittaja);
                VoittajaTeksti.Text = "Pelaaja " + pelaajan1KokoNimi + " voitti!!";
            }
            if (voittaja == 2)
            {
                LisaaVoitto(voittaja);
                VoittajaTeksti.Text = "Tietokone voitti!!";
            }
        }
    }
}
