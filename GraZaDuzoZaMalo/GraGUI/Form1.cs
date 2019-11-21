using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelGry;

namespace GraGUI
{
    public partial class Form1 : Form
    {
        private Gra g;

        public Form1()
        {
            InitializeComponent();
            groupBox1.Visible = false;

        }

        private void buttonNowaGra_Click(object sender, EventArgs e)
        {
            groupBoxLosuj.Visible = true;
            buttonNowaGra.Enabled = false;
            groupBox1.Visible = false;
        }

        private void buttonLosuj_Click(object sender, EventArgs e)
        {
            //ToDo: try-catch ..
            var a = int.Parse(textBoxOd.Text);
            var b = int.Parse(textBoxDo.Text);

            g = new Gra(a, b);

            buttonLosuj.Enabled = false;
            textBoxOd.Enabled = textBoxDo.Enabled = false;
            groupBox1.Visible = true;

        }

        private void groupBoxLosuj_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBoxOd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gra.Odpowiedz odpowiedz;
            odpowiedz = g.Ocena(int.Parse(textBox1.Text));
            

            switch (odpowiedz)
            {
                case Gra.Odpowiedz.ZaDuzo:
                    komunikat.Text = "Podaj mniejszą";
                    break;
                case Gra.Odpowiedz.ZaMalo:
                    komunikat.Text = "Podaj większą";
                    break;
                case Gra.Odpowiedz.Trafiono:
                    komunikat.Text = "Trafiono!";
                    MessageBox.Show("Zgadłeś po " + g.LicznikRuchow + " próbach!", "Gratulacje!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Poddaj();

            if (g.Stan == Gra.StanGry.Poddana)
            {
                DialogResult poddanie = MessageBox.Show("Poddałeś się po " + g.LicznikRuchow + " próbach! " + "Prawidłowa liczba to: "+ g.Wylosowana, "Przykro mi...", MessageBoxButtons.OK, MessageBoxIcon.Error);


                if (poddanie == DialogResult.OK)
                {

                    groupBoxLosuj.Visible = true;

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
