using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace QLUSER
{
    public partial class QLUSER : Form
    {
        SERVER SERVER;
        TcpClient tcpClient = new TcpClient();
        private IPAddress ipAddress;
        string diachiip = "";

        public QLUSER()
        {
            InitializeComponent();
            try
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
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi lấy địa chỉ IP server: " + ex.Message);
            }
        }

        private void btn_OpenServer_Click(object sender, EventArgs e)
        {
            try
            {
                SERVER = new SERVER();
                SERVER.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi tạo server:" + ex.Message);
            }
        }

        private void btn_OpenUser_Click(object sender, EventArgs e)
        {
            try
            {
                ClassQLUSER DATA = new ClassQLUSER();
                string filepath = DATA.find("token.txt");
                diachiip = tb_NhapIP.Text;
                if (ketnoi())
                {
                    if (File.Exists(filepath))
                    {
                        string[] userInfo = File.ReadAllLines(filepath)[0].Split('|');
                        string username = userInfo[0];
                        string token = userInfo[1];

                        if (DATA.ValidateToken(token))
                        {
                            Dangnhap dangnhap = new Dangnhap(diachiip);
                            FindBook findBook= new FindBook(username, token,dangnhap,diachiip);
                            findBook.Show();
                        }
                        else
                        {
                            MessageBox.Show("Token không hợp lệ. Vui lòng đăng nhập lại.");
                            Dangnhap dangnhap = new Dangnhap(diachiip);
                            dangnhap.Show();
                        }
                    }
                    else
                    {
                        Dangnhap dangnhap = new Dangnhap(diachiip);
                        dangnhap.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa tạo server! Xin vui lòng tạo server hoặc điền địa chỉ IP của server vào.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi tạo form người dùng" + ex.Message);
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("lỗi đóng form:" + ex.Message); }
        }
        private bool ketnoi()
        {
            try
            {
                tcpClient = new TcpClient();
                if (diachiip == "")
                    tcpClient.Connect(ipAddress, 8080);
                else tcpClient.Connect(diachiip, 8080);
                NetworkStream ns = tcpClient.GetStream();
                byte[] quit = Encoding.ASCII.GetBytes("quit");
                ns.Write(quit, 0, quit.Length);
                ns.Close();
                tcpClient.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
