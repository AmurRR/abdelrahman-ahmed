using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string us = textBox1.Text;
            string pass = textBox2.Text;
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("UserName and Password fields are empty", "Registeration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (textBox2.Text == textBox3.Text)
            {
                this.tableTableAdapter.InsertQuery(us,pass);
                this.tableTableAdapter.Fill(this.database1DataSet.Table);
                this.Validate();
                this.tableBindingSource.EndEdit();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Your Account has been Successfully Created", "Registeration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form2 login = new Form2();
                login.Show();

            }
            else
            {
                MessageBox.Show("Password dous not match", "Registeration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox2.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form2 login = new Form2();
            login.Show();
            this.Hide();
        }

        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.database1DataSet.Table);

        }

        private void tableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
