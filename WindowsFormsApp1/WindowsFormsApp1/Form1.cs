using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int totalMonto = 0; // Global Variable
        int row_selected = -1;

        public Form1()
        {
            InitializeComponent();
            label7.Hide();
            button2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Button Action send data to the dataGridView
            string noAcc = textBox3.Text.ToString().ToLower();
            string accName = textBox2.Text.ToString();
            string type = comboBox1.Text.ToString();
            string total = textBox1.Text.ToString();


            // Filling the datagrifView

            int credito = 0;
            int debito = 0;
            if(type.ToLower() == "credito")
            {
                credito = Convert.ToInt32(total);
                debito = 0;

            }
            else
            {
                debito = Convert.ToInt32(total);
                credito = 0;

            }

            this.dataGridView1.Rows.Add(noAcc, accName, debito, credito);

            // Updating toal Data
            totalMonto+= Convert.ToInt32(total);
            label6.Text = totalMonto + " $";


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label7.Show();
            button2.Show();

            if (e.RowIndex >= 0)
            {
                row_selected = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                label7.Text = "Remover Cuenta No: " + row.Cells[0].Value.ToString();


            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[row_selected];
            dataGridView1.Rows.Remove(dataGridView1.Rows[row_selected]);

            int totalLess = Convert.ToInt32(row.Cells[2].Value) + Convert.ToInt32(row.Cells[3].Value);
            totalMonto = totalMonto - totalLess;
            label6.Text = totalMonto + " $";

            label7.Hide();
            button2.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
