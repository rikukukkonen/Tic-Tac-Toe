using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ristinolla
{
    public partial class TietokonePeli : Form
    {
        public TietokonePeli()
        {
            InitializeComponent();
        }
        public int[] ruudut = new int[9];
        public int[,] board =
        {
            {0, 0, 0},
            {0, 0, 0},
            {0, 0, 0}
        };
        public static int kokonaisAika;
        public static int Voittaja;
        DateTime start = DateTime.UtcNow;
        string pelaajan1KokoNimi = TietojenSyottoTietokone.pelaajan1KokoNimi;
        //piirretään pelilauta
        private void TietokoneLauta_Paint(object sender, PaintEventArgs e)
        {
            this.Text = "Pelaaja 1 vuoro";

            Pen vv = new Pen(Color.FromArgb(255, 0, 0, 0));
            object[] piirtoTaulukko = new object[9];
            Rectangle ruutu1 = new Rectangle(0, 0, 200, 200);
            piirtoTaulukko[0] = ruutu1;
            Rectangle ruutu2 = new Rectangle(200, 0, 200, 200);
            piirtoTaulukko[1] = ruutu2;
            Rectangle ruutu3 = new Rectangle(400, 0, 199, 200);
            piirtoTaulukko[2] = ruutu3;
            Rectangle ruutu4 = new Rectangle(0, 200, 200, 200);
            piirtoTaulukko[3] = ruutu4;
            Rectangle ruutu5 = new Rectangle(200, 200, 200, 200);
            piirtoTaulukko[4] = ruutu5;
            Rectangle ruutu6 = new Rectangle(400, 200, 199, 200);
            piirtoTaulukko[5] = ruutu6;
            Rectangle ruutu7 = new Rectangle(0, 400, 200, 199);
            piirtoTaulukko[6] = ruutu7;
            Rectangle ruutu8 = new Rectangle(200, 400, 200, 199);
            piirtoTaulukko[7] = ruutu8;
            Rectangle ruutu9 = new Rectangle(400, 400, 199, 199);
            piirtoTaulukko[8] = ruutu9;


            e.Graphics.DrawRectangle(Pens.Black, ruutu1);
            e.Graphics.DrawRectangle(Pens.Black, ruutu2);
            e.Graphics.DrawRectangle(Pens.Black, ruutu3);
            e.Graphics.DrawRectangle(Pens.Black, ruutu4);
            e.Graphics.DrawRectangle(Pens.Black, ruutu5);
            e.Graphics.DrawRectangle(Pens.Black, ruutu6);
            e.Graphics.DrawRectangle(Pens.Black, ruutu7);
            e.Graphics.DrawRectangle(Pens.Black, ruutu8);
            e.Graphics.DrawRectangle(Pens.Black, ruutu9);

            ruudut[0] = ruutu1Pelaaja;
            ruudut[1] = ruutu2Pelaaja;
            ruudut[2] = ruutu3Pelaaja;
            ruudut[3] = ruutu4Pelaaja;
            ruudut[4] = ruutu5Pelaaja;
            ruudut[5] = ruutu6Pelaaja;
            ruudut[6] = ruutu7Pelaaja;
            ruudut[7] = ruutu8Pelaaja;
            ruudut[8] = ruutu9Pelaaja;






        }


        int ruutu1Pelaaja = 0;
        int ruutu2Pelaaja = 0;
        int ruutu3Pelaaja = 0;
        int ruutu4Pelaaja = 0;
        int ruutu5Pelaaja = 0;
        int ruutu6Pelaaja = 0;
        int ruutu7Pelaaja = 0;
        int ruutu8Pelaaja = 0;
        int ruutu9Pelaaja = 0;


        int pelaaja = 1;
        int valmis = 1;

        //tutkitaan voittiko jompikumpi kutsutaan jokaisen siirron jälkeen
        private bool checkWinner(int pelaaja)
        {

            if (ruutu1Pelaaja == pelaaja && ruutu2Pelaaja == pelaaja && ruutu3Pelaaja == pelaaja)
            {
                return true;
            }
            if (ruutu4Pelaaja == pelaaja && ruutu5Pelaaja == pelaaja && ruutu6Pelaaja == pelaaja) { return true; }
            if (ruutu7Pelaaja == pelaaja && ruutu8Pelaaja == pelaaja && ruutu9Pelaaja == pelaaja) { return true; }

            if (ruutu1Pelaaja == pelaaja && ruutu4Pelaaja == pelaaja && ruutu7Pelaaja == pelaaja) { return true; }
            if (ruutu2Pelaaja == pelaaja && ruutu5Pelaaja == pelaaja && ruutu8Pelaaja == pelaaja) { return true; }
            if (ruutu3Pelaaja == pelaaja && ruutu6Pelaaja == pelaaja && ruutu9Pelaaja == pelaaja) { return true; }

            if (ruutu1Pelaaja == pelaaja && ruutu5Pelaaja == pelaaja && ruutu9Pelaaja == pelaaja) { return true; }
            if (ruutu3Pelaaja == pelaaja && ruutu5Pelaaja == pelaaja && ruutu7Pelaaja == pelaaja) { return true; }

            return false;
        }
        //laskee peliin käytetyn ajan
        private void LaskeAika()
        {
            DateTime end = DateTime.UtcNow;
            TimeSpan timeDiff = end - start;
            kokonaisAika = Convert.ToInt32(timeDiff.TotalSeconds);
        }
        //tarkastaa tuliko tasapeli
        private bool tasaPeli()
        {
            if (ruutu1Pelaaja != 0 && ruutu2Pelaaja != 0 && ruutu3Pelaaja != 0 && ruutu4Pelaaja != 0 && ruutu5Pelaaja != 0 && ruutu6Pelaaja != 0 && ruutu7Pelaaja != 0 && ruutu8Pelaaja != 0 && ruutu9Pelaaja != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //vaihtaa sceneä
        private void Leave()
        {
            this.Hide();
            UusiTietokonePeliValikko UPV = new UusiTietokonePeliValikko();
            UPV.ShowDialog();
            this.Close();
        }
        // tekee tietokoneen siirron
        public void TietokoneSiirto()
        {
            Graphics g;
            g = TietokoneLauta.CreateGraphics();
            Pen redPen = new Pen(Color.Red, 2);
            Random random = new Random();
            int i = random.Next(3);
            int j = random.Next(3);
            while(board[i, j] != 0)
            {
                i = random.Next(3);
                j = random.Next(3);
            }
            board[i, j] = 2;
            if (i == 0 && j == 0)
            {
                ruutu1Pelaaja = 2;
                Task.Delay(1000).Wait();
                g.DrawEllipse(redPen, 0, 0, 200, 200);
                
            }
            else if (i == 0 && j == 1)
            {
                ruutu2Pelaaja = 2;
                Task.Delay(1000).Wait();
                g.DrawEllipse(redPen, 200, 0, 200, 200);
                
            }
            else if (i == 0 && j == 2)
            {
                ruutu3Pelaaja = 2;
                Task.Delay(1000).Wait();
                g.DrawEllipse(redPen, 400, 0, 199, 200);
                
            }
            else if (i == 1 && j == 0)
            {
                ruutu4Pelaaja = 2;
                Task.Delay(1000).Wait();
                g.DrawEllipse(redPen, 0, 200, 200, 200);
                
            }
            else if (i == 1 && j == 1)
            {
                ruutu5Pelaaja = 2;
                Task.Delay(1000).Wait();
                g.DrawEllipse(redPen, 200, 200, 200, 200);
                
            }
            else if (i == 1 && j == 2)
            {
                ruutu6Pelaaja = 2;
                Task.Delay(1000).Wait();
                g.DrawEllipse(redPen, 400, 200, 199, 200);
                
            }
            else if (i == 2 && j == 0)
            {
                ruutu7Pelaaja = 2;
                Task.Delay(1000).Wait();
                g.DrawEllipse(redPen, 0, 400, 200, 199);
                
            }
            else if (i == 2 && j == 1)
            {
                ruutu8Pelaaja = 2;
                Task.Delay(1000).Wait();
                g.DrawEllipse(redPen, 200, 400, 200, 199);
                
            }
            else if (i == 2 && j == 2)
            {
                ruutu9Pelaaja = 2;
                Task.Delay(1000).Wait();
                g.DrawEllipse(redPen, 400, 400, 199, 199);
                
            }
            

        }
        
        //tutkii mihin kohtaan lautaa klikattiin ja toimii sen mukaan
        private void TietokoneLauta_Click(object sender, EventArgs e)
        {
            if (valmis == 1)
            {
                Point hiiri = Cursor.Position;
                hiiri = TietokoneLauta.PointToClient(hiiri);
                Pen bluePen = new Pen(Color.Blue, 2);
                Pen redPen = new Pen(Color.Red, 2);
                Graphics g;
                g = TietokoneLauta.CreateGraphics();



                if (hiiri.Y > 0 && hiiri.X > 0 && hiiri.X < 200 && hiiri.Y < 200 && pelaaja == 1 && ruutu1Pelaaja == 0)
                {
                    if (pelaaja == 1)
                    {

                        valmis = 0;
                        Point point1 = new Point(0, 0);
                        Point point2 = new Point(200, 200);
                        Point point3 = new Point(0, 200);
                        Point point4 = new Point(200, 0);
                        g.DrawLine(bluePen, point1, point2);
                        g.DrawLine(bluePen, point3, point4);
                        ruutu1Pelaaja = 1;
                        board[0, 0] = 1;
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 1;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        this.Text = "Tietokoneen vuoro";
                        TietokoneSiirto();
                        this.Text = "Pelaaja 1 vuoro";
                        pelaaja = 2;
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 2;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        pelaaja = 1;
                        valmis = 1;


                    }

                }
                if (hiiri.Y > 0 && hiiri.X > 200 && hiiri.X < 400 && hiiri.Y < 200 && pelaaja == 1 && ruutu2Pelaaja == 0)
                {
                    if (pelaaja == 1)
                    {
                        valmis = 0;
                        Point point1 = new Point(200, 0);
                        Point point2 = new Point(400, 200);
                        Point point3 = new Point(200, 200);
                        Point point4 = new Point(400, 0);
                        g.DrawLine(bluePen, point1, point2);
                        g.DrawLine(bluePen, point3, point4);
                        ruutu2Pelaaja = 1;
                        board[0, 1] = 1;
                        
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 1;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        this.Text = "Tietokoneen vuoro";
                        TietokoneSiirto();
                        this.Text = "Pelaaja 1 vuoro";
                        pelaaja = 2;
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 2;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        pelaaja = 1;
                        valmis = 1;
                    }
                }
                if (hiiri.Y > 0 && hiiri.X < 600 && hiiri.X > 400 && hiiri.Y < 200 && pelaaja == 1 && ruutu3Pelaaja == 0)
                {
                    if (pelaaja == 1)
                    {
                        valmis = 0;
                        Point point1 = new Point(400, 0);
                        Point point2 = new Point(600, 200);
                        Point point3 = new Point(400, 200);
                        Point point4 = new Point(600, 0);
                        g.DrawLine(bluePen, point1, point2);
                        g.DrawLine(bluePen, point3, point4);
                        ruutu3Pelaaja = 1;
                        board[0, 2] = 1;
                        

                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 1;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        this.Text = "Tietokoneen vuoro";
                        TietokoneSiirto();
                        this.Text = "Pelaaja 1 vuoro";
                        pelaaja = 2;
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 2;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        pelaaja = 1;
                        valmis = 1;

                    }
                }
                if (hiiri.X > 0 && hiiri.X < 200 && hiiri.Y > 200 && hiiri.Y < 400 && pelaaja == 1 && ruutu4Pelaaja == 0)
                {
                    if (pelaaja == 1)
                    {
                        valmis = 0;
                        Point point1 = new Point(0, 200);
                        Point point2 = new Point(200, 400);
                        Point point3 = new Point(0, 400);
                        Point point4 = new Point(200, 200);
                        g.DrawLine(bluePen, point1, point2);
                        g.DrawLine(bluePen, point3, point4);
                        ruutu4Pelaaja = 1;
                        board[1, 0] = 1;
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 1;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        this.Text = "Tietokoneen vuoro";
                        TietokoneSiirto();
                        this.Text = "Pelaaja 1 vuoro";
                        pelaaja = 2;
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 2;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        pelaaja = 1;
                        valmis = 1;


                    }
                }
                if (hiiri.X > 200 && hiiri.X < 400 && hiiri.Y > 200 && hiiri.Y < 400 && pelaaja == 1 && ruutu5Pelaaja == 0)
                {
                    if (pelaaja == 1)
                    {
                        valmis = 0;
                        Point point1 = new Point(200, 200);
                        Point point2 = new Point(400, 400);
                        Point point3 = new Point(200, 400);
                        Point point4 = new Point(400, 200);
                        g.DrawLine(bluePen, point1, point2);
                        g.DrawLine(bluePen, point3, point4);
                        ruutu5Pelaaja = 1;
                        board[1, 1] = 1;
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 1;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        this.Text = "Tietokoneen vuoro";
                        TietokoneSiirto();
                        this.Text = "Pelaaja 1 vuoro";
                        pelaaja = 2;
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 2;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        pelaaja = 1;
                        valmis = 1;
                    }
                }
                if ( hiiri.X < 600 && hiiri.X > 400 && hiiri.Y > 200 && hiiri.Y < 400 && pelaaja == 1 && ruutu6Pelaaja == 0)
                {
                    if (pelaaja == 1)
                    {
                        valmis = 0;
                        Point point1 = new Point(400, 200);
                        Point point2 = new Point(600, 400);
                        Point point3 = new Point(400, 400);
                        Point point4 = new Point(600, 200);
                        g.DrawLine(bluePen, point1, point2);
                        g.DrawLine(bluePen, point3, point4);
                        ruutu6Pelaaja = 1;
                        board[1, 2] = 1;
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 1;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        this.Text = "Tietokoneen vuoro";
                        TietokoneSiirto();
                        this.Text = "Pelaaja 1 vuoro";
                        pelaaja = 2;
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 2;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        pelaaja = 1;
                        valmis = 1;
                    }
                }
                if (hiiri.X > 0 && hiiri.Y < 600 && hiiri.X < 200 && hiiri.Y > 400 && pelaaja == 1 && ruutu7Pelaaja == 0)
                {
                    if (pelaaja == 1)
                    {
                        valmis = 0;
                        Point point1 = new Point(0, 400);
                        Point point2 = new Point(200, 600);
                        Point point3 = new Point(0, 600);
                        Point point4 = new Point(200, 400);
                        g.DrawLine(bluePen, point1, point2);
                        g.DrawLine(bluePen, point3, point4);
                        ruutu7Pelaaja = 1;
                        board[2, 0] = 1;
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 1;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        this.Text = "Tietokoneen vuoro";
                        TietokoneSiirto();
                        this.Text = "Pelaaja 1 vuoro";
                        pelaaja = 2;
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 2;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        pelaaja = 1;
                        valmis = 1;
                    }
                }
                if ( hiiri.Y < 600 && hiiri.X > 200 && hiiri.X < 400 && hiiri.Y > 400 && pelaaja == 1 && ruutu8Pelaaja == 0)
                {
                    if (pelaaja == 1)
                    {
                        valmis = 0;
                        Point point1 = new Point(200, 400);
                        Point point2 = new Point(400, 600);
                        Point point3 = new Point(200, 600);
                        Point point4 = new Point(400, 400);
                        g.DrawLine(bluePen, point1, point2);
                        g.DrawLine(bluePen, point3, point4);
                        ruutu8Pelaaja = 1;
                        board[2, 1] = 1;
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 1;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        this.Text = "Tietokoneen vuoro";
                        TietokoneSiirto();
                        this.Text = "Pelaaja 1 vuoro";
                        pelaaja = 2;
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 2;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        pelaaja = 1;
                        valmis = 1;
                    }
                }
                if (hiiri.X < 600 && hiiri.Y < 600 && hiiri.X > 400 && hiiri.Y > 400 && pelaaja == 1 && ruutu9Pelaaja == 0)
                {
                    if (pelaaja == 1)
                    {
                        valmis = 0;
                        Point point1 = new Point(400, 400);
                        Point point2 = new Point(600, 600);
                        Point point3 = new Point(400, 600);
                        Point point4 = new Point(600, 400);
                        g.DrawLine(bluePen, point1, point2);
                        g.DrawLine(bluePen, point3, point4);
                        ruutu9Pelaaja = 1;
                        board[2, 2] = 1;
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 1;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        this.Text = "Tietokoneen vuoro";
                        TietokoneSiirto();
                        this.Text = "Pelaaja 1 vuoro";
                        pelaaja = 2;
                        if (checkWinner(pelaaja) == true)
                        {
                            LaskeAika();
                            Voittaja = 2;
                            Task.Delay(1000).Wait();
                            Leave();
                        }
                        if (tasaPeli() == true)
                        {
                            LaskeAika();
                            Voittaja = 0;
                            Task.Delay(1000).Wait();
                            Leave();

                        }
                        pelaaja = 1;
                        valmis = 1;

                    }

                }
            }

                //MessageBox.Show(ruutu.ToString());

            }

        private void TietokonePeli_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
    }

