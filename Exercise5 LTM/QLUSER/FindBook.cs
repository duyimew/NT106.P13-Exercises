using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLUSER
{
    public partial class FindBook : Form
    {
        private string username1;
        private string token1;
        private string diachi1;
        Dangnhap DN;

        public FindBook(string username,string token,Dangnhap dn,string diachi)
        {
            InitializeComponent();
            username1 = username;
            token1=token;
            DN = dn;
            diachi1=diachi;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
             LoadBookData(tbInputName.Text);


        }
        private async void LoadBookData(string searchQuery)
        {
            dgvBooks.Rows.Clear();
            string apikey = ConfigurationManager.AppSettings["ApiKey"];
            string url = $"https://www.googleapis.com/books/v1/volumes?q={searchQuery}&key={apikey}";

            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    JObject json = JObject.Parse(responseBody);
                    JArray items = (JArray)json["items"];

                    foreach (var item in items)
                    {
                        string ID= item["id"]?.ToString();
                        string title = item["volumeInfo"]["title"]?.ToString();


                        dgvBooks.Rows.Add(ID,title);
                    }
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show("Request error: " + e.Message);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e.Message);
                }
                finally
                {
                    progressBar1.Visible = false;
                    progressBar1.Style = ProgressBarStyle.Continuous;
                }
            }
        }
        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var idCell = dgvBooks.Rows[e.RowIndex].Cells[0].Value;

                if (idCell != null)
                {
                    string ID = idCell.ToString();
                    this.Hide();
                    BookDetail book = new BookDetail(ID,this);
                    book.Show();
                }
                else
                {
                    MessageBox.Show("No data available in selected row.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateBookshelf cb= new CreateBookshelf(this);
            cb.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formuser formuser = new Formuser(username1, token1, DN,this, diachi1);
            formuser.Show();
        }
    }
}
