using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace librarySERVER
{
    public partial class formMain : Form
    {



        public string strimage;

        public SqlConnection sqcon = new SqlConnection("Data Source=.;Initial Catalog=library;Integrated Security=True");
        Socket serversct = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket clientsct = null;
        public int invenbook;
        public int idbook;
        public string idRE;

        public formMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (clientsct != null)
                {
                    clientsct.Shutdown(SocketShutdown.Both);

                }
                if (serversct != null)
                {
                    serversct.Shutdown(SocketShutdown.Both);
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

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.WhiteSmoke;


        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.CadetBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.CadetBlue;
            button1.ForeColor = Color.Red;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.Red;
            button1.ForeColor = Color.Black;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.WhiteSmoke;
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            button5.BackColor = Color.CadetBlue;
        }

        private void button6_MouseMove(object sender, MouseEventArgs e)
        {
            button6.BackColor = Color.CadetBlue;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.WhiteSmoke;
        }



        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.WhiteSmoke;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.CadetBlue;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            groupBox2.Visible = true; groupBox5.Visible = false; groupBox6.Visible = false; groupBox7.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false; groupBox5.Visible = false; groupBox6.Visible = true; groupBox7.Visible = false;
            timer1.Enabled = false;


        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            groupBox6.Visible = false;
            groupBox2.Visible = false;
            groupBox5.Visible = true;
            groupBox7.Visible = false;
        }



        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            groupBox2.Visible = false; groupBox5.Visible = false;
            groupBox6.Visible = false;groupBox7.Visible = true;
            MessageBox.Show("Please click on the desired food");

        }
        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            textBox7.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("First select your user");
            }
            else
            {
                idRE = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                tabPage1.Show();
                button3.Visible = false;
                button16.Visible = true;
                button9.Visible = true;
                button8.Visible = false;
                groupBox3.Enabled = false;
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                string pasima = System.IO.Path.GetFullPath(dataGridView1.CurrentRow.Cells[9].Value.ToString());
                circlepc1.Image = Image.FromFile(pasima);


            }











        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog myOpenFileDialog = new OpenFileDialog();
            myOpenFileDialog.ShowDialog();

            if (myOpenFileDialog.FileName != "")

            {

                Image newImage = Image.FromFile(myOpenFileDialog.FileName);

                circlepc1.Image = newImage;

                strimage = myOpenFileDialog.FileName;
            }
        }

        string bookname = "";
        private void Form1_Load(object sender, EventArgs e)
        {
 
            button13.PerformClick();
 
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select your search type first", "Hi!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox2.SelectedItem == "ID Code")
            {
                SqlDataAdapter sqsearch = new SqlDataAdapter("select name,LastName,fatherName,idcode,number,dateSI,dateFINISH from personalTBL where idcode  like '%" + textBox7.Text + "%' ", sqcon);
                DataTable dtse = new DataTable();
                sqsearch.Fill(dtse);
                dataGridView1.DataSource = dtse;

            }
            else if (comboBox2.SelectedItem == "First Name")
            {

                SqlDataAdapter sqsearch = new SqlDataAdapter("select name,LastName,fatherName,idcode,number,dateSI,dateFINISH from personalTBL where name like '%" + textBox7.Text + "%' ", sqcon);
                DataTable dtse = new DataTable();
                sqsearch.Fill(dtse);
                dataGridView1.DataSource = dtse;
            }
            else if (comboBox2.SelectedItem == "Last name")
            {
                SqlDataAdapter sqsearch = new SqlDataAdapter("select name,LastName,fatherName,idcode,number,dateSI,dateFINISH from personalTBL where LastName like '%" + textBox7.Text + "%' ", sqcon);
                DataTable dtse = new DataTable();
                sqsearch.Fill(dtse);
                dataGridView1.DataSource = dtse;

            }
            else if (comboBox2.SelectedItem == "Date Of Registration")
            {
                SqlDataAdapter sqsearch = new SqlDataAdapter("select name,LastName,fatherName,idcode,number,dateSI,dateFINISH from personalTBL where dateSI like '%" + textBox7.Text + "%' ", sqcon);
                DataTable dtse = new DataTable();
                sqsearch.Fill(dtse);
                dataGridView1.DataSource = dtse;
            }
        }



        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Please select your search type first", "Hi!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox4.SelectedItem == "ID Code")
            {
                SqlDataAdapter sqsearch = new SqlDataAdapter("select name,LastName,fatherName,idcode,number,dateSI,dateFINISH from personalTBL where idcode  like '%" + textBox7.Text + "%' ", sqcon);
                DataTable dtse = new DataTable();
                sqsearch.Fill(dtse);
                dataGridView1.DataSource = dtse;

            }
            else if (comboBox4.SelectedItem == "First Name")
            {

                SqlDataAdapter sqsearch = new SqlDataAdapter("select name,LastName,fatherName,idcode,number,dateSI,dateFINISH from personalTBL where name like '%" + textBox7.Text + "%' ", sqcon);
                DataTable dtse = new DataTable();
                sqsearch.Fill(dtse);
                dataGridView1.DataSource = dtse;
            }
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView2.Columns[0].Width = 80;
            dataGridView2.Columns[1].Width = 210;
            dataGridView2.Columns[2].Width = 210;
            dataGridView2.Columns[3].Width = 94;
            dataGridView2.Columns[4].Width = 93;
            dataGridView2.Columns[1].HeaderText = "Author";
            dataGridView2.Columns[2].HeaderText = "Book Name";
        }

        private void dataGridView4_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView4.Columns[0].Width = 80;
            dataGridView4.Columns[1].Width = 200;
            dataGridView4.Columns[2].Width = 200;
            dataGridView4.Columns[3].Width = 200;
            dataGridView4.Columns[4].Width = 200;
            dataGridView4.Columns[5].Width = 150;
            dataGridView4.Columns[6].Width = 150;
            dataGridView4.Columns[6].HeaderText = "Inventory of this book";
            dataGridView4.Columns[4].HeaderText = "Book Name";
            
        }
        public void getmassage()
        {
            try
            {
                while (true)
                {
                    byte[] br = new byte[1024];
                    int r = clientsct.Receive(br);
                    if (r > 0)
                    {
                        label17.Text += ("Client :" + Encoding.Unicode.GetString(br, 0, r)) + "\n";
                        button17.Text = "1";
                        MessageBox.Show("you have a message");
                    }
                }
            }
            catch
            {
                ;
            }
        }
        public void startserver()
        {
            IPEndPoint ipserver = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4040);
            serversct.Bind(ipserver);
            serversct.Listen(1);
            clientsct = serversct.Accept();
            Thread trge = new Thread(new ThreadStart(getmassage));
            trge.Start();
        }
        private void button17_Click(object sender, EventArgs e)
        {
            Thread trstart = new Thread(new ThreadStart(startserver));
            trstart.Start();
            button17.BackColor = Color.CadetBlue;
            button15.BackColor = Color.CadetBlue;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            label17.Text = "";
            button17.Text = "";
            groupBox6.Visible = false;

        }
        private void button15_Click(object sender, EventArgs e)
        {
            if (button17.BackColor == Color.CadetBlue) {
                byte[] b = new byte[1024];
                b = Encoding.Unicode.GetBytes(textBox13.Text);
                clientsct.Send(b);
                label17.Text += textBox13.Text + "\n";
                textBox13.Text = "";
                button17.Text = "";
                }
            else
                MessageBox.Show("Please check the connection\r\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            sqcon.Open();
            SqlCommand sqlcom = new SqlCommand("insert into personalTBL values(@name,@fatherNAME,@lastNAME,@idcode,@phoneNUM,@address,@datesI,@dateFI,@pictureAdd)", sqcon);
            sqlcom.Parameters.AddWithValue("@name", textBox1.Text);
            sqlcom.Parameters.AddWithValue("@fatherNAME", textBox4.Text);
            sqlcom.Parameters.AddWithValue("@lastNAME", textBox5.Text);
            sqlcom.Parameters.AddWithValue("@idcode", textBox2.Text);
            sqlcom.Parameters.AddWithValue("@phoneNUM", textBox3.Text);
            sqlcom.Parameters.AddWithValue("@address", textBox6.Text);
            sqlcom.Parameters.AddWithValue("@datesI", dateTimeSelector1.Text);
            sqlcom.Parameters.AddWithValue("@dateFI", label10.Text);
            sqlcom.Parameters.AddWithValue("@pictureAdd", strimage);
            sqlcom.ExecuteNonQuery();
            sqcon.Close();

            MessageBox.Show("Now registered");
            textBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimeSelector1.Text = "";
            comboBox1.Text = "";
            label10.Text = "";

        }
        private void button8_Click(object sender, EventArgs e)
        {

            //SqlDataAdapter sqsearch = new SqlDataAdapter("select name,LastName from personalTBL where idcode ='%" + textBox2.Text + "%' ", sqcon);

            //DataTable dtse = new DataTable();
            //sqsearch.Fill(dtse);
            //dataGridView3.DataSource = dtse;
            //dataGridView3.CurrentRow.Cells[0].Value.ToString();
            //if (dtse == null)
            //{


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Please correct the following errors :");
            if (textBox1.Text == "")
                sb.AppendLine("Enter the user's first name");
            if (textBox4.Text == "")
                sb.AppendLine("Enter the user's father's name");
            if (textBox5.Text == "")
                sb.AppendLine("Enter the user's last name");
            if (textBox2.Text == "")
                sb.AppendLine("Enter the user's ID Code");
            if (textBox3.Text == "")
                sb.AppendLine("Enter the user's Mobile Phone Number");
            if (textBox6.Text == "")
                sb.AppendLine("Enter the user's home address");
            if (strimage == "")
                sb.AppendLine("choose a photo for your user");
            if (dateTimeSelector1.Text == "")
                sb.AppendLine("Select the user registration time");
            //if(textBox2.Text=)
            if (comboBox1.SelectedItem == null)
                sb.AppendLine("Select the duration of the user's subscription");




            if (sb.ToString() != "Please correct the following errors :")
                MessageBox.Show(sb.ToString(), "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string str = comboBox1.SelectedItem.ToString();
                if (str == "2 YEARs")
                {
                    string text1 = dateTimeSelector1.GetText("dd");
                    string text11 = dateTimeSelector1.GetText("MM");
                    string text111 = dateTimeSelector1.GetText("yyyy");
                    int d = Convert.ToInt16(text111) + 2;
                    label10.Text = d.ToString() + "/" + text11 + "/" + text1;
                }
                else if (str == "1 YEAR")
                {
                    string text1 = dateTimeSelector1.GetText("dd");
                    string text11 = dateTimeSelector1.GetText("MM");
                    string text111 = dateTimeSelector1.GetText("yyyy");
                    int d = Convert.ToInt16(text111) + 1;
                    label10.Text = d.ToString() + "/" + text11 + "/" + text1;
                }
                else if (str == "6 MONTHs")
                {
                    int year = Convert.ToInt16(dateTimeSelector1.GetText("yyyy"));
                    string text1 = dateTimeSelector1.GetText("dd");
                    int month = Convert.ToInt16
                        (dateTimeSelector1.GetText("MM"));
                    month += 6;
                    if (month > 12)
                    {
                        month -= 12;
                        year += 1;
                    }


                    label10.Text = year.ToString() + "/" + month.ToString() + "/" + text1;
                    button3.Enabled = true;

                }
            }
 


        }

        private void dateTimeSelector1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (button14.BackColor == Color.Red)
            {
                label6.Visible = true;
                label9.Visible = true;
                label11.Visible = false;
                comboBox1.Visible = true;
                button19.Visible = false;
                button14.BackColor = Color.WhiteSmoke;
            }
            button16.Visible = false;
            button3.Visible = true;
            button8.Visible = true;
            button9.Visible = false;
            groupBox3.Enabled = true;
            textBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimeSelector1.Text = "";
            comboBox1.Text = "";
            label10.Text = "";
            circlepc1.Image = librarySERVER.Properties.Resources.Character_Man_1;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void textBox11_MouseClick(object sender, MouseEventArgs e)
        {
            textBox11.Text = "";
        }
        public string bonam;
        private void button14_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null)
            {
                MessageBox.Show("First select your book");
            }
            else
            {
                invenbook = Convert.ToInt16(dataGridView2.CurrentRow.Cells[4].Value);
                bonam = dataGridView2.CurrentRow.Cells[1].Value.ToString();

                if (invenbook > 0)
                {
                    idbook = Convert.ToInt16(dataGridView2.CurrentRow.Cells[0].Value);

                    button14.BackColor = Color.Red;
                    --invenbook;
                    groupBox5.Visible = false;
                    groupBox2.Visible = true;
                    tabPage2.Show();
                    MessageBox.Show("Click on the user who takes the book");

                }
                else
                {
                    MessageBox.Show("This book is not available");
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            sqcon.Open();
            SqlCommand sqlcom = new SqlCommand("insert into bookTBL values(@author,@book,@count,@inventory)", sqcon);
            sqlcom.Parameters.AddWithValue("@author", textBox10.Text);
            sqlcom.Parameters.AddWithValue("@book", textBox8.Text);
            sqlcom.Parameters.AddWithValue("@count", textBox9.Text);
            sqlcom.Parameters.AddWithValue("@inventory", textBox9.Text);
            sqlcom.ExecuteNonQuery();
            sqcon.Close();
            MessageBox.Show("The book is now saved", "successful", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            if ((dateTimeSelector1.Text == null) || (comboBox1.SelectedItem.ToString() == null))
                MessageBox.Show("Please complete the requested information");
            else
            {

                string str = comboBox1.SelectedItem.ToString();
                if (str == "2 YEARs")
                {
                    string text1 = dateTimeSelector1.GetText("dd");
                    string text11 = dateTimeSelector1.GetText("MM");
                    string text111 = dateTimeSelector1.GetText("yyyy");
                    int d = Convert.ToInt16(text111) + 2;
                    label10.Text = d.ToString() + "/" + text11 + "/" + text1;
                }
                else if (str == "1 YEAR")
                {
                    string text1 = dateTimeSelector1.GetText("dd");
                    string text11 = dateTimeSelector1.GetText("MM");
                    string text111 = dateTimeSelector1.GetText("yyyy");
                    int d = Convert.ToInt16(text111) + 1;
                    label10.Text = d.ToString() + "/" + text11 + "/" + text1;
                }
                else if (str == "6 MONTHs")
                {
                    int year = Convert.ToInt16(dateTimeSelector1.GetText("yyyy"));
                    string text1 = dateTimeSelector1.GetText("dd");
                    int month = Convert.ToInt16
                        (dateTimeSelector1.GetText("MM"));
                    month += 6;
                    if (month > 12)
                    {
                        month -= 12;
                        year += 1;
                    }



                    label10.Text = year.ToString() + "/" + month.ToString() + "/" + text1;


                }
                sqcon.Open();
                SqlCommand sqlcom = new SqlCommand("update personalTBL set dateSI=@dateSI, dateFINISH=@dateFI where id=@idcode", sqcon);
                sqlcom.Parameters.AddWithValue("@dateSI", dateTimeSelector1.Text);
                sqlcom.Parameters.AddWithValue("@dateFI", label10.Text);
                sqlcom.Parameters.AddWithValue("@idcode", idRE);
                sqlcom.ExecuteNonQuery();
                sqcon.Close();
                MessageBox.Show("Re-registration done");


            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_MouseClick(object sender, MouseEventArgs e)
        {
            textBox12.Text = "";
        }

        private void textBox12_TextChanged_1(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Please select your search type first", "Hi!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox3.SelectedItem == "LAST NAME")
            {
                SqlDataAdapter sqsearch = new SqlDataAdapter("select name,LastName,fatherName,idcode,number,dateSI,dateFINISH from personalTBL where idcode  like '%" + textBox7.Text + "%' ", sqcon);
                DataTable dtse = new DataTable();
                sqsearch.Fill(dtse);
                dataGridView1.DataSource = dtse;

            }
            else if (comboBox3.SelectedItem == "BOOK NAME")
            {

                SqlDataAdapter sqsearch = new SqlDataAdapter("select name,LastName,fatherName,idcode,number,dateSI,dateFINISH from personalTBL where name like '%" + textBox7.Text + "%' ", sqcon);
                DataTable dtse = new DataTable();
                sqsearch.Fill(dtse);
                dataGridView1.DataSource = dtse;
            }
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter sqadap = new SqlDataAdapter("selecSERVERbook", sqcon);
            DataTable dt = new DataTable();
            sqadap.Fill(dt);
            dataGridView2.DataSource = dt;

            SqlDataAdapter sqldap2 = new SqlDataAdapter("personalSelect", sqcon);
            DataTable dt2 = new DataTable();
            sqldap2.Fill(dt2);
            dataGridView1.DataSource = dt2;

            SqlDataAdapter sqadap1 = new SqlDataAdapter("historyTBLcon", sqcon);
            DataTable dt1 = new DataTable();
            sqadap1.Fill(dt1);
            dataGridView4.DataSource = dt1;

            SqlDataAdapter sqadap3 = new SqlDataAdapter("foodtblcon", sqcon);
            DataTable dt3 = new DataTable();
            sqadap3.Fill(dt3);
            dataGridView3.DataSource = dt3;

            SqlDataAdapter sqadap4 = new SqlDataAdapter("drinksel", sqcon);
            DataTable dt4 = new DataTable();
            sqadap4.Fill(dt4);
            dataGridView5.DataSource = dt4;
        }
        public int idpers;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (button14.BackColor == Color.Red)
            {
                idpers = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                tabPage1.Show();
                button3.Visible = false;
                button16.Visible = true;
                button19.Visible = true;
                button8.Visible = false;
                groupBox3.Enabled = false;

                label6.Visible = false;
                label9.Visible = false;
                label11.Visible = true;
                comboBox1.Visible = false;

                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                label10.Text = bonam;
                string pasima = System.IO.Path.GetFullPath(dataGridView1.CurrentRow.Cells[9].Value.ToString());
                circlepc1.Image = Image.FromFile(pasima);
                MessageBox.Show("Select the date of borrowing the book by the user");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Did you choose the right user and book?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                sqcon.Open();
                SqlCommand sqlcom = new SqlCommand("insert into HistoryTBL values(@pers,@idbook,@date,@del)", sqcon);
                sqlcom.Parameters.AddWithValue("@pers", idpers);
                sqlcom.Parameters.AddWithValue("@idbook", idbook);
                sqlcom.Parameters.AddWithValue("@date", dateTimeSelector1.Text);
                sqlcom.Parameters.AddWithValue("@del", true);
                sqlcom.ExecuteNonQuery();

                SqlCommand sqlcom1 = new SqlCommand("update bookTBL set inventory=@inve where id=@idbook", sqcon);
                sqlcom1.Parameters.AddWithValue("@inve", invenbook);
                sqlcom1.Parameters.AddWithValue("@idbook", idbook);
                sqlcom1.ExecuteNonQuery();
                sqcon.Close();
                MessageBox.Show("The book is now saved", "successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                button16.PerformClick();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (dataGridView4.CurrentRow.Cells[0].Value.ToString() != "")
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Did you choose the right user and book?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    int idhistor = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value);
                    String bona = dataGridView4.CurrentRow.Cells[4].Value.ToString();
                    int inventorhis = Convert.ToInt32(dataGridView4.CurrentRow.Cells[6].Value);
                    ++inventorhis;
                    sqcon.Open();
                    SqlCommand sqlcom = new SqlCommand("update HistoryTBL set del=@del where id=@id", sqcon);
                    sqlcom.Parameters.AddWithValue("@id", idhistor);
                    sqlcom.Parameters.AddWithValue("@del", "false");
                    sqlcom.ExecuteNonQuery();
                  
                    int invent = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value);
                    ++invent;
                    SqlCommand sqlcom1 = new SqlCommand("update bookTBL set inventory=@inve where book=@book", sqcon);
                    sqlcom1.Parameters.AddWithValue("@inve",inventorhis );
                    sqlcom1.Parameters.AddWithValue("@book", bona);
                    sqlcom1.ExecuteNonQuery();
                    sqcon.Close();
                    button13.PerformClick();
                }
 
            }
            else
            {
                MessageBox.Show("First select the user");

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
         //   Form form1 = new Form();
            if (button20.BackColor == Color.White)
            {
                groupBox6. BackColor=Color.Sienna;
                label17.BackColor = Color.FromArgb(64,64,64);
                label17.ForeColor = Color.White;
                button20.BackColor = Color.Black;
                button7.BackColor = Color.RosyBrown;
                button7.ForeColor = Color.White;
               
                this.BackColor = Color.FromArgb(64, 64, 64);
            }
            else
            {
                groupBox6.BackColor=Color.Tan;
                label17.BackColor = Color.White;
                label17.ForeColor = Color. FromArgb(64, 64, 64);
                button20.BackColor = Color.White;
                button7.BackColor = Color.CadetBlue;
                button7.ForeColor = Color.Black;
                this.BackColor = Color.White;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        int x = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
         
            if (x == 0)
            {
                label19.ForeColor = Color.Black;
                label20.ForeColor = Color.Red;
                label18.ForeColor = Color.Black;
                label22.ForeColor = Color.Red;


                x = 1;

            }
            else if (x == 1)
            {
                label20.ForeColor = Color.Black;
                label15.ForeColor = Color.Red;
                label22.ForeColor = Color.Black;
                label21.ForeColor = Color.Red;
                x = 2;
            }
            else if (x == 2)
            {
                label15.ForeColor = Color.Black;
                label19.ForeColor = Color.Red;
                label21.ForeColor = Color.Black;
                label18.ForeColor = Color.Red;
                x = 0;

            }
        
        }
        public int sum= 0;

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label23.Text = Convert.ToString(dataGridView3.CurrentRow.Cells[1].Value);
            q = 0;
            timer2.Enabled = true;
            q = 0;
           // sum+=Convert .ToInt32(dataGridView4.CurrentRow.Cells[0].Value);

        }


        public int q;
        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label24.Text = Convert.ToString(dataGridView5.CurrentRow.Cells[1].Value);
            q = 1;
            timer2.Enabled = true;

        }
        public int m=320;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (q == 0)
            {
                if (m <= 520)
                {
                    m += 5;
                    label23.Location = new Point(575, m);
                   
                }
                else
                {
                    
                    m = 320;
                    label23.Location = new Point(575, 320);

                    checkedListBox2.Items.Add(label23.Text);
                    label23.Text = "";



                    timer2.Enabled = false;
                }
            }
            else if (q == 1)
            {
                if (m <= 520)
                {
                    m += 5;
                    label24.Location = new Point(167, m);
                }
                else
                {
                  
                    m = 320;
                    label24.Location = new Point(167, 320);
                    checkedListBox1.Items.Add(label24.Text);
                    label24.Text = "";

                    timer2.Enabled = false;

                }
            }
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }
    }
}
