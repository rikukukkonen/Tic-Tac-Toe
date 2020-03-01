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
    public partial class UusiPeliValikko : Form
    {
        public UusiPeliValikko()
        {
            InitializeComponent();
        }
        int kokonaisAika = Ristinolla.kokonaisAika;
        string pelaajan1KokoNimi = TietojenSyotto.pelaajan1KokoNimi;
        string pelaajan2KokoNimi = TietojenSyotto.pelaajan2KokoNimi;
        int kaksinpeliVoittaja = Ristinolla.kaksinPeliVoittaja;
        //tallentaa tiedostoihin voitot, tasapelit ja haviöt pelin lopputuloksen mukaan
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
                StreamReader sr2 = new StreamReader($@"{pelaaja1tiedostonOsoite}");
                sr2.ReadLine();
                sr2.ReadLine();
                pelaaja1Aika.Text = "Pelaajan " + pelaajan1KokoNimi + " pelien yhteiskesto : " + sr2.ReadLine() + " sekuntia";
                pelaaja1Voitot.Text = "Pelaajan " + pelaajan1KokoNimi + " voittojen määrä : " + sr2.ReadLine();
                pelaaja1Tasapelit.Text = "Pelaajan " + pelaajan1KokoNimi + " tasapelien määrä : " + sr2.ReadLine();
                pelaaja1Haviot.Text = "Pelaajan " + pelaajan1KokoNimi + " häviöiden määrä : " + sr2.ReadLine();
                sr2.Close();
                string pelaaja2tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string pelaaja2tiedostonOsoite = Path.Combine(pelaaja2tietojenOsoite, pelaajan2KokoNimi + ".txt");
                StreamReader sr3 = new StreamReader($@"{pelaaja2tiedostonOsoite}");
                sr3.ReadLine();
                sr3.ReadLine();
                sr3.ReadLine();
                sr3.ReadLine();
                string pelaajan2KaikkiTasapelit = sr3.ReadLine();
                sr3.Close();
                int pelaajan2TasapelienMaara;
                bool oliNumero2 = Int32.TryParse(pelaajan2KaikkiTasapelit, out pelaajan2TasapelienMaara);
                if (oliNumero2)
                {
                    pelaajan2TasapelienMaara = pelaajan2TasapelienMaara + 1;
                    void lineChanger(string newText, string fileName, int line_to_edit)
                    {
                        string[] arrLine = File.ReadAllLines(fileName);
                        arrLine[line_to_edit - 1] = newText;
                        File.WriteAllLines(fileName, arrLine);
                    }
                    lineChanger(pelaajan2TasapelienMaara.ToString(), pelaaja2tiedostonOsoite, 5);

                }
                StreamReader sr4 = new StreamReader($@"{pelaaja2tiedostonOsoite}");
                sr4.ReadLine();
                sr4.ReadLine();
                pelaaja2Aika.Text = "Pelaajan " + pelaajan2KokoNimi + " pelien yhteiskesto : " + sr4.ReadLine() + " sekuntia";
                pelaaja2Voitot.Text = "Pelaajan " + pelaajan2KokoNimi + " voittojen määrä : " + sr4.ReadLine();
                pelaaja2Tasapelit.Text = "Pelaajan " + pelaajan2KokoNimi + " tasapelien määrä : " + sr4.ReadLine();
                pelaaja2Haviot.Text = "Pelaajan " + pelaajan2KokoNimi + " häviöiden määrä : " + sr4.ReadLine();
                sr4.Close();

            }
            else if(voittaja == 1)
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
                pelaaja1Aika.Text = "Pelaajan " + pelaajan1KokoNimi + " pelien yhteiskesto : " + sr2.ReadLine() + " sekuntia";
                pelaaja1Voitot.Text = "Pelaajan " + pelaajan1KokoNimi + " voittojen määrä : " + sr2.ReadLine();
                pelaaja1Tasapelit.Text = "Pelaajan " + pelaajan1KokoNimi + " tasapelien määrä : " + sr2.ReadLine();
                pelaaja1Haviot.Text = "Pelaajan " + pelaajan1KokoNimi + " häviöiden määrä : " + sr2.ReadLine();
                sr2.Close();
                string pelaaja2tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string pelaaja2tiedostonOsoite = Path.Combine(pelaaja2tietojenOsoite, pelaajan2KokoNimi + ".txt");
                StreamReader sr3 = new StreamReader($@"{pelaaja2tiedostonOsoite}");
                sr3.ReadLine();
                sr3.ReadLine();
                sr3.ReadLine();
                sr3.ReadLine();
                sr3.ReadLine();
                string pelaajan2KaikkiHaviot = sr3.ReadLine();
                sr3.Close();
                int pelaajan2HavioidenMaara;
                bool oliNumero2 = Int32.TryParse(pelaajan2KaikkiHaviot, out pelaajan2HavioidenMaara);
                if (oliNumero2)
                {
                    pelaajan2HavioidenMaara = pelaajan2HavioidenMaara + 1;
                    void lineChanger(string newText, string fileName, int line_to_edit)
                    {
                        string[] arrLine = File.ReadAllLines(fileName);
                        arrLine[line_to_edit - 1] = newText;
                        File.WriteAllLines(fileName, arrLine);
                    }
                    lineChanger(pelaajan2HavioidenMaara.ToString(), pelaaja2tiedostonOsoite, 6);

                }
                StreamReader sr4 = new StreamReader($@"{pelaaja2tiedostonOsoite}");
                sr4.ReadLine();
                sr4.ReadLine();
                pelaaja2Aika.Text = "Pelaajan " + pelaajan2KokoNimi + " pelien yhteiskesto : " + sr4.ReadLine() + " sekuntia";
                pelaaja2Voitot.Text = "Pelaajan " + pelaajan2KokoNimi + " voittojen määrä : " + sr4.ReadLine();
                pelaaja2Tasapelit.Text = "Pelaajan " + pelaajan2KokoNimi + " tasapelien määrä : " + sr4.ReadLine();
                pelaaja2Haviot.Text = "Pelaajan " + pelaajan2KokoNimi + " häviöiden määrä : " + sr4.ReadLine();
                sr4.Close();


            }
            else if (voittaja == 2)
            {
                string pelaaja2tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string pelaaja2tiedostonOsoite = Path.Combine(pelaaja2tietojenOsoite, pelaajan2KokoNimi + ".txt");
                StreamReader sr = new StreamReader($@"{pelaaja2tiedostonOsoite}");
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                string pelaajan2KaikkiVoitot = sr.ReadLine();
                sr.Close();
                int pelaajan2VoittojenMaara;
                bool oliNumero = Int32.TryParse(pelaajan2KaikkiVoitot, out pelaajan2VoittojenMaara);
                if (oliNumero)
                {
                    pelaajan2VoittojenMaara = pelaajan2VoittojenMaara + 1;
                    void lineChanger(string newText, string fileName, int line_to_edit)
                    {
                        string[] arrLine = File.ReadAllLines(fileName);
                        arrLine[line_to_edit - 1] = newText;
                        File.WriteAllLines(fileName, arrLine);
                    }
                    lineChanger(pelaajan2VoittojenMaara.ToString(), pelaaja2tiedostonOsoite, 4);

                }
                string pelaaja1tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string pelaaja1tiedostonOsoite = Path.Combine(pelaaja1tietojenOsoite, pelaajan1KokoNimi + ".txt");
                StreamReader sr2 = new StreamReader($@"{pelaaja2tiedostonOsoite}");
                sr2.ReadLine();
                sr2.ReadLine();
                pelaaja2Aika.Text = "Pelaajan " + pelaajan2KokoNimi + " pelien yhteiskesto : " + sr2.ReadLine() + " sekuntia";
                pelaaja2Voitot.Text = "Pelaajan " + pelaajan2KokoNimi + " voittojen määrä : " + sr2.ReadLine();
                pelaaja2Tasapelit.Text = "Pelaajan " + pelaajan2KokoNimi + " tasapelien määrä : " + sr2.ReadLine();
                pelaaja2Haviot.Text = "Pelaajan " + pelaajan2KokoNimi + " häviöiden määrä : " + sr2.ReadLine();
                sr2.Close();
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
                pelaaja1Aika.Text = "Pelaajan " + pelaajan1KokoNimi + " pelien yhteiskesto : " + sr4.ReadLine() + " sekuntia";
                pelaaja1Voitot.Text = "Pelaajan " + pelaajan1KokoNimi + " voittojen määrä : " + sr4.ReadLine();
                pelaaja1Tasapelit.Text = "Pelaajan " + pelaajan1KokoNimi + " tasapelien määrä : " + sr4.ReadLine();
                pelaaja1Haviot.Text = "Pelaajan " + pelaajan1KokoNimi + " häviöiden määrä : " + sr4.ReadLine();
                sr4.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ristinolla r = new Ristinolla();
            r.ShowDialog();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu M = new Menu();
            M.ShowDialog();
            this.Close();
        }

        private void UusiPeliValikko_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //tallentaa pelin keston pelaajien tietoihin
        private void UusiPeliValikko_Load(object sender, EventArgs e)
        {
            
            string pelaaja1tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pelaaja1tiedostonOsoite = Path.Combine(pelaaja1tietojenOsoite, pelaajan1KokoNimi + ".txt");
            string pelaaja2tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pelaaja2tiedostonOsoite = Path.Combine(pelaaja2tietojenOsoite, pelaajan2KokoNimi + ".txt");
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


            StreamReader sr2 = new StreamReader($@"{pelaaja2tiedostonOsoite}");
            sr2.ReadLine();
            sr2.ReadLine();
            string aikaisempiAika2 = sr2.ReadLine();
            sr2.Close();
            int aika2;
            bool oliNumero2 = Int32.TryParse(aikaisempiAika2, out aika2);
            if (oliNumero)
            {
                aika2 = kokonaisAika + aika2;
                void lineChanger(string newText, string fileName, int line_to_edit)
                {
                    string[] arrLine = File.ReadAllLines(fileName);
                    arrLine[line_to_edit - 1] = newText.ToString();
                    File.WriteAllLines(fileName, arrLine);
                }
                lineChanger(aika2.ToString(), pelaaja2tiedostonOsoite, 3);
            }
            

            //tutkii kumpi voitti pelin
            if (kaksinpeliVoittaja == 0)
            {
                kaksinpeliVoittajaTeksti.Text = "Tasapeli!!";
                LisaaVoitto(kaksinpeliVoittaja);
            }
            if (kaksinpeliVoittaja == 1)
            {
                kaksinpeliVoittajaTeksti.Text = "Pelaaja " + pelaajan1KokoNimi + " voitti!!";
                LisaaVoitto(kaksinpeliVoittaja);
            }
            if (kaksinpeliVoittaja == 2)
            {
                kaksinpeliVoittajaTeksti.Text = "Pelaaja " + pelaajan2KokoNimi + " voitti!!";
                LisaaVoitto(kaksinpeliVoittaja);
            }
        }
    }
}
