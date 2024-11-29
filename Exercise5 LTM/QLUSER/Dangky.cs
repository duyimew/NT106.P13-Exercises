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
using System.Net.Mail;
using System.Net.Sockets;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Threading;
using System.Net.NetworkInformation;

namespace QLUSER
{
    public partial class Dangky : Form
    {
        private Dangnhap DN;
        TcpClient tcpClient = new TcpClient();
        private IPAddress ipAddress;

        public Dangky(Dangnhap dn,string diachiip)
        {
            InitializeComponent();
            DN = dn;
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
            { MessageBox.Show("Lỗi không thể lấy được địa chỉ IP của server"+ex.Message); }
        }
        private void bt_thoat_Click(object sender, EventArgs e)
        {
            try
            {
                DN.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi thoát đăng ký " + ex.Message);
            }
        }
        private void bt_DK_Click(object sender, EventArgs e)
        {
            try
            {
                string username = tb_username.Text;
                string password = tb_pwd.Text;
                string confirmPassword = tb_cfpwd.Text;
                string email = tb_email.Text;
                string ten = tb_hoten.Text;
                string ngaysinh = tb_ngsinh.Text;
                ClassQLUSER data = new ClassQLUSER();

                if (password != confirmPassword)
                {
                    MessageBox.Show("Mật khẩu và xác nhận mật khẩu không trùng khớp.");
                    return;
                }

                if (!data.IsValidEmail(email))
                {
                    MessageBox.Show("Email không đúng định dạng.");
                    return;
                }

                string hashpwd = data.HashPassword(password);
                if (hashpwd == null)
                {
                    MessageBox.Show("Mã hóa thất bại.");
                    return;
                }

                if (ketnoi(username, hashpwd, email, ten, ngaysinh))
                {
                    string serverResponse = ketqua();
                    if (serverResponse == "1") MessageBox.Show("Đăng ký thành công");
                    else MessageBox.Show("Đăng ký thất bại");
                }
                else
                {
                    MessageBox.Show("Kết nối đến server thất bại.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký " + ex.Message);
            }
        }

        private bool ketnoi(string username, string hashpwd, string email,string ten, string ngaysinh)
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(ipAddress, 8080);
                MessageBox.Show("Kết nối thành công!");
                NetworkStream ns = tcpClient.GetStream();
                string TEXT = "DK|" + username + "|" + hashpwd + "|" + email + "|" + ten + "|" +ngaysinh;
                byte[] data1 = Encoding.ASCII.GetBytes(TEXT);
                ns.Write(data1, 0, data1.Length);
                ns.Flush();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối đến server"+ ex.Message);
                return false;
            }
        }

        private string ketqua()
        {
            NetworkStream ns = tcpClient.GetStream();
            byte[] data2 = new byte[1024];

            try
            {
                int bytesRead = ns.Read(data2, 0, data2.Length);
                string result = Encoding.ASCII.GetString(data2, 0, bytesRead);
                byte[] quit = Encoding.ASCII.GetBytes("quit");
                ns.Write(quit, 0, quit.Length);
                ns.Close();
                tcpClient.Close();
                return result.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không nhận được dữ liệu từ server " + ex.Message);
                return null;
            }
        }


    }
}




