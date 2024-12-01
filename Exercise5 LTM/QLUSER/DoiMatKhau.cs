using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net.Http;

namespace QLUSER
{
    public partial class DoiMatKhau : Form
    {
        ClassQLUSER user=new ClassQLUSER();
        Formuser formuser1;
        private IPAddress ipAddress;
                TcpClient tcpClient = new TcpClient();
        private string username1;

        public DoiMatKhau(Formuser formuser,string username,string diachiip)
        {
            InitializeComponent();
            formuser1 = formuser;      
            username1 = username;
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
            { MessageBox.Show("Lỗi không thể lấy được địa chỉ IP của server" + ex.Message); }
        }

        private void btn_sendEmail_Click(object sender, EventArgs e)
        {
            string mk =tb_mkhientai.Text;
            string newmk=tb_mkmoi.Text;
            string xnnewmk=tb_xacnhanmk.Text;
            if(newmk!=xnnewmk)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không trùng khớp");
                return;
            }

            string hople=user.ValidatePassword(newmk);
            if(hople != "Hợp lệ")
            {
                MessageBox.Show(hople);
                return;
            }

            UpdatePasswordInDatabase(username1,mk, newmk);
        }

        private void UpdatePasswordInDatabase(string username, string mkhientai,string newPassword)
        {
            try
            {
                ClassQLUSER data = new ClassQLUSER();
                string hasspasshientai = data.HashPassword(mkhientai);
                string hashPassword = data.HashPassword(newPassword);
                if (ketnoi(hasspasshientai, hashPassword, username))
                {
                    string serverResponse = ketqua();
                    if (serverResponse == "1") { MessageBox.Show("Đổi mật khẩu thành công"); }
                    else if (serverResponse != "0")
                    {
                        MessageBox.Show(serverResponse);
                    }
                    else { MessageBox.Show("Đổi mật khẩu thất bại"); }
                }
                else
                {
                    MessageBox.Show("Kết nối đến server thất bại.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating password: " + ex.Message);
            }
        }
        private bool ketnoi(string mkhientai,string hashpwd, string username)
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(ipAddress, 8080);
                MessageBox.Show("Kết nối thành công!");
                NetworkStream ns = tcpClient.GetStream();
                string TEXT = "DMKM|" + mkhientai +"|" + hashpwd + "|" + username;
                byte[] data1 = Encoding.ASCII.GetBytes(TEXT);
                ns.Write(data1, 0, data1.Length);
                ns.Flush();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối đến server" + ex.Message);
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
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
