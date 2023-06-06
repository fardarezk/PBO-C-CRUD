using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Npgsql;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.VisualBasic.ApplicationServices;

namespace penjualan_laptop
{
    public partial class Form1 : Form
    {
        private NpgsqlConnection connection = new NpgsqlConnection();
        private DataGridView songsDataGridView = new DataGridView();
        private string constring = "Server=localhost; Port=5432; User Id=postgres; Password=adzkiya;Database=Penjualan_Laptop;";
        private string sql = "Server = localhost; Port=5432; User Id = postgres; Password=adzkiya;Database=Penjualan_Laptop;";
        private NpgsqlCommand cmd = new NpgsqlCommand();
        private DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();

        }

        private void ShowData()
        {
            try
            {
                connection.Open();
                sql = "SELECT * FROM Laptop ";
                cmd = new NpgsqlCommand(sql, connection);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                connection.Close();
                songsDataGridView.DataSource = null;
                songsDataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("error" + ex.Message);
            }
        }
        private void Createdata()
        {
            NpgsqlConnection connection = new NpgsqlConnection(constring);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO Laptop(ID_Laptop, Merk, Harga, Stok) " +
                "VALUES (@value1, @value2, @value3, @value4)", connection);
            command.Parameters.AddWithValue("value1", textBox1.Text);
            command.Parameters.AddWithValue("value2", textBox2.Text);
            command.Parameters.AddWithValue("value3", textBox3.Text);
            command.Parameters.AddWithValue("value4", textBox4.Text);
            connection.Close();

            MessageBox.Show("Success Insert data");
        }

        private void Editdata()
        {
            NpgsqlConnection connection = new NpgsqlConnection(constring);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("UPDATE coba SET Merk = @value2, Harga = @value3, Stok= @value4 WHERE nim = @value1", connection);
            command.Parameters.AddWithValue("value2", textBox2.Text);
            command.Parameters.AddWithValue("value3", textBox3.Text);
            command.Parameters.AddWithValue("value4", textBox4.Text);
            command.Parameters.AddWithValue("value1", textBox1.Text);
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Success Update data");
        }
        private void Deletedata()
        {
            NpgsqlConnection connection = new NpgsqlConnection(constring);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("DELETE FROM coba WHERE ID_Laptop=@value1", connection);
            command.Parameters.AddWithValue("value1", textBox1.Text);
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Success deleted data");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(constring);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Createdata();
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Editdata();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Deletedata();
        }
    }
}