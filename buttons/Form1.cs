using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buttons
{
    public partial class Form1 : Form
    {
        private List<DrawBack> Draws = new List<DrawBack>();
        private List<PictureBox> PBs = new List<PictureBox>();
        private Color Color1 = Color.BlueViolet;
        private Color Color2 = Color.DarkBlue;
        private int count = 9;
        public Form1()
        {
            InitializeComponent();
            Random rnd = new Random();
            int i = 0;
            foreach (PictureBox pb in this.Controls.OfType<PictureBox>().OrderBy(n=>Convert.ToInt32(n.Name.Remove(0,10))))
            {
                pb.BackColor = rnd.NextDouble() > 0.5 ? Color1 : Color2;
                Draws.Add(new DrawBack(i));
                PBs.Add(pb);

                ++i;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.BackColor = pb.BackColor == Color1 ? Color2 : Color1;
            DrawLogic(Draws[PBs.IndexOf(pb)].ArrID);
        }

        private void DrawLogic(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > -1)
                {
                    PBs[arr[i]].BackColor =
                        PBs[arr[i]].BackColor == Color1 ? Color2 : Color1;
                }
            }
        }
    }

    class DrawBack
    {
        public int ID { get; private set; }
        public int Hight { get; set; }
        public int Width { get; set; }

        public int[] ArrID { get; private set; }
        public DrawBack(int ID)
        {
            Hight = 3;
            Width = 3;
            this.ID = ID;

            ArrID = new int[4];
            ArrID[0] = (ID % Width) - 1 < 0? -1: ID - 1;
            ArrID[1] = (ID + 1) % Width == 0 ? -1 : ID + 1;
            ArrID[2] = ID - Width < 0 ? -1 : ID - Width;
            ArrID[3] = ID + Width >= Width * Hight ? -1: ID + Width;
        }
    }

}
