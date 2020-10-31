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

        Bitmap bmp;
        Graphics grp;
        static Random rnd = new Random();
        public class point
        {
            public float x, y;
            public point()
            {
                x = rnd.Next(1000);
                y = rnd.Next(600);
            }
            public void Draw(Graphics grp)
            {
                grp.DrawEllipse(new Pen(Color.Green, 2), x, y, 2, 2);
            }
        }

        static float lungime(point A, point B)
        {
            return (float)Math.Sqrt((A.x - B.x) * (A.x - B.x) + (A.y - B.y) * (A.y - B.y));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(Color.Black);

            int n = 100;
            point[] V = new point[n];

            for (int i = 0; i < n; i++)
            {
                V[i] = new point();
            }
            for (int i = 0; i < n; i++)
            {
                V[i].Draw(grp);
            }

            for (int j = 0; j < n - 1; j++)
            {
                float lungmin = lungime(V[j], V[j + 1]);
                int idx = j + 1;
                for (int i1 = j + 1; i1 < n; i1++)
                {
                    float l = lungime(V[j], V[i1]);
                    if (l < lungmin)
                    {
                        lungmin = l;
                        idx = i1;
                    }
                }
                point aux = V[j + 1];
                V[j + 1] = V[idx];
                V[idx] = aux;
                grp.DrawLine(Pens.Gold, V[j].x, V[j].y, V[j + 1].x, V[j + 1].y);
            }

            pictureBox1.Image = bmp;
        }
    }
}
