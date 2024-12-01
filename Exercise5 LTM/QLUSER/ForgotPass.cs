using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace QLUSER
{
    public partial class ForgotPass : Form
    {
        Dangnhap DN;
        TcpClient tcpClient = new TcpClient();
        private IPAddress ipAddress;
        public ForgotPass(Dangnhap dn, string diachiip)
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
            { MessageBox.Show("Lỗi không thể lấy được địa chỉ IP của server" + ex.Message); }
        }

        private void btn_sendEmail_Click(object sender, EventArgs e)
        {
            string email = tb_email.Text;

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email address.");
                return;
            }
            bool success = UpdatePasswordInDatabase(email);
            if (success)
            {
                MessageBox.Show("Xin vui lòng kiểm tra lại email để lấy mật khẩu mới.");
            }
            else MessageBox.Show("Đổi lại mật khẩu thất bại. Xin vui lòng thử lại sau");
        }



        private bool UpdatePasswordInDatabase(string email)
        {
            try
            {
                ClassQLUSER data = new ClassQLUSER();
                if (ketnoi(email))
                {
                    string serverResponse = ketqua();
                    if (serverResponse == "1") { return true; }
                    else if(serverResponse != "0") {
                        MessageBox.Show(serverResponse);
                        return false; }
                    else { return false; }
                }
                else
                {
                    MessageBox.Show("Kết nối đến server thất bại.");
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating password: " + ex.Message);
                return false;
            }
        }

        

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DN.Show();
            this.Close();
        }
        private bool ketnoi(string email)
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(ipAddress, 8080);
                MessageBox.Show("Kết nối thành công!");
                NetworkStream ns = tcpClient.GetStream();
                string TEXT = "FP|" + email;
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
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không nhận được dữ liệu từ server " + ex.Message);
                return null;
            }
        }
    }
}
