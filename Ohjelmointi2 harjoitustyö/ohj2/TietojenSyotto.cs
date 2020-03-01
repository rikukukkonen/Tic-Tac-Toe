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
    public partial class TietojenSyotto : Form
    {
        public TietojenSyotto()
        {
            InitializeComponent();
        }
        public static string pelaajan1KokoNimi;
        public static string pelaajan2KokoNimi;
        //tutkitaan ettei pelaamaan pääse jollei valitse kahta eri pelaajaa
        private void Button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Valitse pelaajat ensiksi!");
            }
            else if (listBox1.SelectedIndex == listBox2.SelectedIndex)
            {
                MessageBox.Show("Et voi valita kahta samaa pelaajaa");
            }
            else if (listBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Valitse pelaajat ensiksi!");
            }

            else
            {
                pelaajan1KokoNimi = listBox1.GetItemText(listBox1.SelectedItem);
                pelaajan2KokoNimi = listBox2.GetItemText(listBox2.SelectedItem);
                this.Hide();
                Ristinolla r = new Ristinolla();
                r.ShowDialog();
                this.Close();
            }
            
            
        }
        string tiedostonOsoite;
        string tietojenOsoite;
        string pelaajanEtunimi;
        string pelaajanSukunimi;
        string pelaajanSyntymäaika;
        private void TietojenSyotto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //päivittää listboxit
        private void PopulateListBox(ListBox lsb, string Folder)
        {
            StreamReader sr = new StreamReader($@"{tiedostonOsoite}");
            string uusiTeksti = sr.ReadLine();
            lsb.Items.Add(uusiTeksti);
            sr.Close();
        }
        //lisää pelaajan listboxiin ja tallentaa pelaajan tiedot kansioon
        private void UusiPelaajaNappi_Click(object sender, EventArgs e)
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
                    PopulateListBox(listBox1, tiedostonOsoite);
                    PopulateListBox(listBox2, tiedostonOsoite);
                }
                    
            }

            else
            {
                MessageBox.Show("Täytä kaikki kentät!");
            }

        }
        //täyttää listboxit sceneen siirtyessä
        private void TietojenSyotto_Load(object sender, EventArgs e)
        {
             void TietojenHaku(object l1, object l2)
            {
                DirectoryInfo dinfo = new DirectoryInfo($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}");
                string tietojenOsoite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string tietokoneTiedostoOsoite = Path.Combine(tietojenOsoite, "ristinollatietokone" + ".txt");
                FileInfo[] Files = dinfo.GetFiles("*.txt");
                foreach (FileInfo file in Files)
                {
                    listBox1.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
                    listBox2.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
                }
                if (File.Exists(tietokoneTiedostoOsoite) == true)
                {
                    listBox1.Items.Remove(Path.GetFileNameWithoutExtension(tietokoneTiedostoOsoite));
                    listBox2.Items.Remove(Path.GetFileNameWithoutExtension(tietokoneTiedostoOsoite));
                }
            }
            TietojenHaku(listBox1, listBox2);

        }
    }
}
