using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinieMinima
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // variabile pentru desenarea pe ecran
        Bitmap bmp;
        Graphics grp;

        // variabila pentru a genera numere aleatorii
        static Random rnd = new Random();
        
        // clasa pentru un punct
        public class point
        {
            public float x, y;

            // initializam punctul cu coordonate aleatorii
            public point()
            {
                x = rnd.Next(1000);
                y = rnd.Next(600);
            }
            // functie pentru a-l desena pe ecran
            public void Draw(Graphics grp)
            {
                grp.DrawEllipse(new Pen(Color.Green, 2), x, y, 2, 2);
            }
        }

        // functie pentru a calcula distanta dintre doua puncte A si B
        static float lungime(point A, point B)
        {
            return (float)Math.Sqrt((A.x - B.x) * (A.x - B.x) + (A.y - B.y) * (A.y - B.y));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // legam codul nostru de imaginea care se afiseaza pe ecran
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);

            // setam culoarea de fundal ca fiind neagra
            grp.Clear(Color.Black);

            // declaram cele n puncte
            int n = 100;
            point[] V = new point[n];

            // generam cele n puncte
            for (int i = 0; i < n; i++)
            {
                V[i] = new point();
            }

            // le desenam pe ecran
            for (int i = 0; i < n; i++)
            {
                V[i].Draw(grp);
            }

            // aflam distanta minima de la punct la punct
            for (int j = 0; j < n - 1; j++)
            {
                float lungmin = lungime(V[j], V[j + 1]);
                int idx = j + 1;
                // calculam lungimea de la punctul actual la toate celelalte puncte
                for (int i1 = j + 1; i1 < n; i1++)
                {
                    float l = lungime(V[j], V[i1]);
                    if (l < lungmin)
                    {
                        lungmin = l;
                        idx = i1;
                    }
                }
                
                // dupa ce o gasim pe cea minima, o punem pe pozitia urmatoare din vector
                point aux = V[j + 1];
                V[j + 1] = V[idx];
                V[idx] = aux;

                // desenam o linie intre punctul actual si cel mai apropiat punct de el
                grp.DrawLine(Pens.Gold, V[j].x, V[j].y, V[j + 1].x, V[j + 1].y);
            }

            // actualizam imaginea de pe ecran
            pictureBox1.Image = bmp;
        }
    }
}
