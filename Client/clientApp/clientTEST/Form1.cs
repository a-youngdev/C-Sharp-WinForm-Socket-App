using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Threading; 
namespace clientTEST
{
    public partial class Form1 : Form
    {
        Socket clientsct = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.CadetBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.WhiteSmoke;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.WhiteSmoke;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.CadetBlue;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.CadetBlue;

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.WhiteSmoke;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.BackColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.CadetBlue;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                if (clientsct != null)
                {
                    clientsct.Shutdown(SocketShutdown.Both);

                }
            
                Environment.Exit(Environment.ExitCode);
                Application.Exit();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(Environment.ExitCode);
                Application.Exit();
               
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            groupBox3.Hide();
            groupBox2.Enabled = Enabled;
            groupBox2.Show();
            groupBox4.Visible = false;


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
          
        }
        public void getmassage()
        {
            try
            {
                while (true)
                {
                    byte[] b = new byte[1024];
                    int r = clientsct.Receive(b);
                    if (r > 0)
                    {
                        label2.Text += ("server :" + Encoding.Unicode.GetString(b, 0, r))+"\n";
                        MessageBox.Show("you have a message");
                    }
                }
            }
            catch
            {
                ;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Hide();
          
            }
            

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Hide();
            groupBox4.Visible = false;
            groupBox3.Show();
            groupBox3.Visible = true;

            
            SqlDataAdapter sqadap = new SqlDataAdapter("selectBOOKcus", sqcon);
            DataTable dt = new DataTable();
            sqadap.Fill(dt);
            dataGridView1.DataSource = dt;




        }
        SqlConnection sqcon = new SqlConnection("Data Source=.;Initial Catalog=library;Integrated Security=True");
        private void toorder_Click(object sender, EventArgs e)
        {

        }
        string bookname="";
        private void search_Click(object sender, EventArgs e)
        {
            bookname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            label4.Text = bookname;
            if (label4.Text == "")
            {

                MessageBox.Show("plaese select your book");

            }
            else
            {
                SqlDataAdapter sqadap = new SqlDataAdapter("SELECT inventory from bookTBL where book like'%" + label4.Text + "%'", sqcon);
                DataTable dt = new DataTable();
                sqadap.Fill(dt);
                dataGridView1.DataSource = dt;
                int test = Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                
                if (test > 0)
                {
                    SqlDataAdapter sqadap11 = new SqlDataAdapter("selectBOOKcus", sqcon);
                    DataTable dt11 = new DataTable();
                    sqadap11.Fill(dt11);
                    dataGridView1.DataSource = dt11;
                    MessageBox.Show("mojod");

                }
                else
                {

                    SqlDataAdapter sqadap1 = new SqlDataAdapter("selectBOOKcus", sqcon);
                    DataTable dt1 = new DataTable();
                    sqadap1.Fill(dt1);
                    dataGridView1.DataSource = dt1;

                    MessageBox.Show("namojod"); }
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox3.Visible =false;
            groupBox2.Visible = false;
            MessageBox.Show("please enter your name first");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            button4.BackColor = Color.Red;
            label2.Text = "";
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.CadetBlue;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            label3.BackColor = Color.Red;
        }
        public string username = "";
        private void button4_Click(object sender, EventArgs e)
        {
            
            if (button4.BackColor == Color.Red)
            {
                username = textBox2.Text;
                button4.BackColor = Color.CadetBlue;
                textBox2.Text = "";
            }

            else
            {
                
                byte[] br = new byte[1024];
                br = Encoding.Unicode.GetBytes( username+" :"+textBox2.Text);
                clientsct.Send(br);
                label2.Text += textBox2.Text + "\n";
                textBox2.Text = "";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void button7_Click(object sender, EventArgs e)
        {
            IPEndPoint ipserver = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4040);
            try
            {
                clientsct.Connect(ipserver);
                Thread tr = new Thread(new ThreadStart(getmassage));
                tr.Start();
                button7.BackColor = Color.CadetBlue;
            }
            catch
            {
                MessageBox.Show("server not start");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sqadap = new SqlDataAdapter("select  author,book from bookTBL where book like'%"+textBox1.Text+"%' ", sqcon);
            DataTable dt = new DataTable();
            sqadap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
