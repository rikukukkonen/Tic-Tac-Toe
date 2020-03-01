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
    public partial class TietojenSyottoTietokone : Form
    {
        public TietojenSyottoTietokone()
        {
            InitializeComponent();
        }
        string tiedostonOsoite;
        string tietojenOsoite;
        string pelaajanEtunimi;
        string pelaajanSukunimi;
        string pelaajanSyntymäaika;
        public static string pelaajan1KokoNimi;

        private void TietojenSyottoTietokone_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //päivittää listBoxit
        private void PopulateListBox(ListBox lsb, string Folder)
        {
            StreamReader sr = new StreamReader($@"{tiedostonOsoite}");
            string uusiTeksti = sr.ReadLine();
            lsb.Items.Add(uusiTeksti);
            sr.Close();
        }
        //nappulan painalluksella siirrytään pelaamaan, jos ehdot täyttyvät
        private void Button1_Click(object sender, EventArgs e)
        {
            if (tietokonePelaajaLista.SelectedIndex == -1)
            {
                MessageBox.Show("Valitse pelaaja ensiksi!");
            }
            else
            {
                string tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string tietokoneTiedostoOsoite = Path.Combine(tietojenOsoite, "ristinollatietokone" + ".txt");
                if (File.Exists(tietokoneTiedostoOsoite) == true)
                {

                }
                else
                {
                    StreamWriter sw = new StreamWriter($@"{tietokoneTiedostoOsoite}", true);
                    sw.WriteLine("ristinollatietokone");
                    sw.WriteLine(2020);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.Close();
                }
                pelaajan1KokoNimi = tietokonePelaajaLista.GetItemText(tietokonePelaajaLista.SelectedItem);

                this.Hide();
                TietokonePeli r = new TietokonePeli();
                r.ShowDialog();
                this.Close();
            }
        }
        //Luo uuden pelaajan ja päivittää sen tiedot tiedostoon
        private void LuoPelaajaNappi_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
            {
                pelaajanEtunimi = textBox1.Text;
                pelaajanSukunimi = textBox2.Text;
                pelaajanSyntymäaika = textBox3.Text;
                tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                tiedostonOsoite = Path.Combine(tietojenOsoite, pelaajanEtunimi + pelaajanSukunimi + ".txt");
                var tiedostonOsoite2 = Path.Combine(tietojenOsoite, pelaajanEtunimi + pelaajanSukunimi);
                if (File.Exists(tiedostonOsoite) == true)
                {
                    MessageBox.Show("Tämä nimi on jo varattu!");
                }
                else
                {
                    StreamWriter sw = new StreamWriter($@"{tiedostonOsoite}", true);
                    sw.Write(pelaajanEtunimi);
                    sw.WriteLine(pelaajanSukunimi);
                    sw.WriteLine(pelaajanSyntymäaika);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.Close();
                    PopulateListBox(tietokonePelaajaLista, tiedostonOsoite);
                }

            }

            else
            {
                MessageBox.Show("Täytä kaikki kentät!");
            }
        }
        //päivittää listboxit sceneen siirryttäessä
        private void TietojenSyottoTietokone_Load(object sender, EventArgs e)
        {
            void TietojenHaku(object l1)
            {
                DirectoryInfo dinfo = new DirectoryInfo($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}");
                string tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string tietokoneTiedostoOsoite = Path.Combine(tietojenOsoite, "ristinollatietokone" + ".txt");
                FileInfo[] Files = dinfo.GetFiles("*.txt");
                foreach (FileInfo file in Files)
                {
                    tietokonePelaajaLista.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
                    
                }
                if (File.Exists(tietokoneTiedostoOsoite) == true)
                {
                    tietokonePelaajaLista.Items.Remove(Path.GetFileNameWithoutExtension(tietokoneTiedostoOsoite));
                }
            }
            TietojenHaku(tietokonePelaajaLista);
        }
    }
}
