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

namespace SchoolappDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox3.Text);
                string name = textBox1.Text;
                string grade = textBox2.Text;
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sepideh\source\repos\SchoolappDB\SchoolappDB\schoolapp.mdf;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE studentsTable SET Name = '" + name + "', Grade = '" + grade + "' "
                        ;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Grade", grade);
                        command.Parameters.AddWithValue("@ID", id);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Student information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox3.Text);
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sepideh\source\repos\SchoolappDB\SchoolappDB\schoolapp.mdf;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM studentsTable WHERE ID = '" + id + "'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Student information deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sepideh\source\repos\SchoolappDB\SchoolappDB\schoolapp.mdf;Integrated Security=True"; 
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); string query = "SELECT * FROM studentsTable"; using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader(); listBox1.Items.Clear();
                        while (reader.Read())
                        {
                            string studentInfo = "ID: " + reader["ID"].ToString() + ", Name: " + reader["Name"].ToString() + ", Grade: " + reader["Grade"].ToString();
                            listBox1.Items.Add(studentInfo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string grade = textBox2.Text;
                string connectionStering = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sepideh\source\repos\SchoolappDB\SchoolappDB\schoolapp.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionStering);
                connection.Open();
                string quary = "INSERT INTO studentsTable(Name,Grade)" +
                    " VALUES('" + name + "','" + grade + "')";
                SqlCommand command = new SqlCommand(quary, connection);
                command.ExecuteNonQuery();

                MessageBox.Show("Student information added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    }

