using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Cukraszda
{
    public partial class Form1 : Form
    {
        Form2 sutiform = new Form2();

        public Form1()
        {
            InitializeComponent();
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fájlBeolvasásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] beolvasott = File.ReadAllLines("sutemenyek.txt");
            List<Sutemeny> sutik = new List<Sutemeny>();
            foreach (var item in beolvasott)
            {
                Sutemeny suti = new Sutemeny(item);
                sutik.Add(suti);
            }
            süteményekToolStripMenuItem.Enabled = true;

            Font arlistaFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            Font rendelFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            for (int i = 0; i < sutik.Count; i++)
            {
                CheckBox checkbox = new CheckBox();
                checkbox.Location = new Point(110, 80 + i * 40);
                checkbox.Text = sutik[i].Nev + "(" + sutik[i].Ar + " Ft)";
                checkbox.Font = arlistaFont;
                checkbox.AutoSize = true;
                sutiform.Controls.Add(checkbox);
                NumericUpDown numericupdown = new NumericUpDown();
                numericupdown.Location = new Point(345, 78 + i * 40);
                numericupdown.Minimum = 0;
                numericupdown.Size = new Size(50, 20);
                numericupdown.Font = arlistaFont;
                numericupdown.TextAlign = HorizontalAlignment.Right;
                Label label = new Label();
                label.Font = arlistaFont;
                label.Location = new Point(400, 80 + i * 40);
                label.Text = "adag";
                sutiform.Controls.Add(numericupdown);
                sutiform.Controls.Add(label);
            }

            Button button = new Button();
            button.Font = rendelFont;
            button.Text = "Rendel";
            button.Location = new Point(255, 100 + sutik.Count * 40);
            button.AutoSize = true;
            button.Click += new EventHandler(rendeles);
            sutiform.Controls.Add(button);

            sutiform.ShowDialog();

        }

        private void süteményekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sutiform.ShowDialog();
        }

        private void rendeles(object sender, EventArgs e)
        {
            int index = 0;
            int osszeg = 0;
            foreach (var item in sutiform.Controls)
            {
                if (item.GetType() == typeof(CheckBox) && ((CheckBox)item).Checked)
                {
                    MessageBox.Show(((CheckBox)item).Text);
                }
                index++;
            }
            MessageBox.Show("rendelés leadva!");
        }
    }
}
