using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLUSER
{
    public partial class Formuser : Form
    {
        Dangnhap DN;
        TcpClient tcpClient = new TcpClient();
        private IPAddress ipAddress;
        private string diachiip1;
        private string username1;
        FindBook findBook1;
        public Formuser(string username, string token, Dangnhap dN,FindBook findBook, string diachiip)
        {
            InitializeComponent();
            username1 = username;
            diachiip1=diachiip;
            findBook1 = findBook;
            try
            {
                if (diachiip == "")
                {
                    var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                    var wifiAdapter = networkInterfaces.FirstOrDefault(nic => nic.Name.Contains("Wi-Fi") && nic.OperationalStatus == OperationalStatus.Up);
                    if (wifiAdapter != null)
                    {
                        var ipProperties = wifiAdapter.GetIPProperties();
                        var ipAddress1 = ipProperties.UnicastAddresses.FirstOrDefault(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork)?.Address;
                        ipAddress = IPAddress.Parse(ipAddress1.ToString());
                    }
                }
                else ipAddress = IPAddress.Parse(diachiip);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy địa chỉ IP của server: " + ex.Message);
            }
            try
            {
                tb_username.Text = username;
                DN = dN;
                string[] text = get(username, token);
                tb_email.Text = text[0];
                tb_HienTen.Text = text[1];
                tb_HIenNgSinh.Text = text[2];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không lấy  được thông tin người dùng: " + ex.Message);
            }
        }
        private string[] get(string username, string token)
        {
            string[] text = new string[3];
            text[0] = "";
            text[1] = "";
            text[2] = "";
            try
            {
                ClassQLUSER data = new ClassQLUSER();
                if (ketnoi(username, token))
                {
                    string[] serverResponse = ketqua();
                    if (serverResponse[0] == "1")
                    {
                        text[0] = serverResponse[1];
                        text[1] = serverResponse[2];
                        text[2] = serverResponse[3];
                        return text;

                    }
                    else return text;
                }
                else
                {
                    MessageBox.Show("Kết nối tới server thất bại");
                    DN.Show();
                    return text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin người dùng: " + ex.Message);
                return text;
            }
        }
        private void bt_thoat_Click(object sender, EventArgs e)
        {
            try
            {
                findBook1.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tắt form thông tin người dùng " + ex.Message);
            }
        }

        private void bt_dangxuat_Click(object sender, EventArgs e)
        {
            ClassQLUSER classQLUSER = new ClassQLUSER();
            string tokenFile = classQLUSER.find("token.txt");
            if (tokenFile != null && File.Exists(tokenFile))
            {
                File.Delete(tokenFile);
                DN.Show();
                findBook1.Close();
                this.Close();
                MessageBox.Show("Đăng xuất thành công!");
            }
        }

        private bool ketnoi(string text, string token)
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(ipAddress, 8080);
                MessageBox.Show("Kết nối thành công!");
                NetworkStream ns = tcpClient.GetStream();
                string TEXT = "RQ|" + text + "|" + token;
                byte[] data1 = Encoding.ASCII.GetBytes(TEXT);
                ns.Write(data1, 0, data1.Length);
                ns.Flush();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối đến server " + ex.Message);
                return false;
            }
        }

        private string[] ketqua()
        {
            NetworkStream ns = tcpClient.GetStream();
            byte[] data2 = new byte[1024];
            try
            {
                int bytesRead = ns.Read(data2, 0, data2.Length);
                string text = Encoding.ASCII.GetString(data2, 0, bytesRead);
                string[] result = text.Split('|');
                byte[] quit = Encoding.ASCII.GetBytes("quit");
                ns.Write(quit, 0, quit.Length);
                ns.Close();
                tcpClient.Close();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhận dữ liệu từ server " + ex.Message);
                return new string[] { };
            }
        }

        private void btn_ChangePass_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau(this,username1,diachiip1);
            doiMatKhau.Show();
        }
    }
}
