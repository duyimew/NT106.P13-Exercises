using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net.Mail;

namespace QLUSER
{
    public partial class SERVER : Form
    {
        private Thread serverThread;
        private Thread clientThread;
        private bool isServerRunning = false;
        Socket listenerSocket;
        private IPAddress ipAddress;

        public SERVER()
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
                MessageBox.Show("Lỗi không thể lấy được địa chỉ IP: "+ ex.Message);
                }
        }
        
        private void btn_Listen_Click(object sender, EventArgs e)
        {
            try
            {
                CheckForIllegalCrossThreadCalls = false;
                serverThread = new Thread(new ThreadStart(StartUnsafeThread));
                serverThread.SetApartmentState(ApartmentState.STA);
                serverThread.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi chạy server: " + ex.Message);
            }
        }
        private void StartUnsafeThread()
        {
            try
            {
                listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listenerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                IPEndPoint ipepServer = new IPEndPoint(ipAddress, 8080);
                listenerSocket.Bind(ipepServer);
                listenerSocket.Listen(100);
                isServerRunning = true;
                MessageBox.Show("Server đang chạy và lắng nghe tại "+ipAddress+":8080");
                textBox1.Text = ipAddress.ToString();
                while (isServerRunning)
                {
                   try
                    {
                        
                        Socket clientSocket = listenerSocket.Accept();
                        this.Invoke((MethodInvoker)delegate { lv_ClientsView.Items.Add(new ListViewItem("New client connected")); });
                        clientThread = new Thread(() => HandleClient(clientSocket));
                        clientThread.Start();
                    }
                   catch (SocketException ex)
                    {
                     
                      if (ex.SocketErrorCode != SocketError.Interrupted)
                        {
                          MessageBox.Show("Socket error: " + ex.Message);
                        }
                    }
                }
                
            }
           catch (Exception ex)
            {
               MessageBox.Show("Lỗi chạy server: " + ex.Message);
            }
        }


        private void HandleClient(Socket clientSocket)
        {
            try
            {
                int bytesReceived;
                byte[] recv = new byte[1024];
                string text = "";
                while (clientSocket.Connected)
                {
                    bytesReceived = clientSocket.Receive(recv);
                    if (bytesReceived == 0) break;

                    text = Encoding.ASCII.GetString(recv, 0, bytesReceived);

                    if (text.Contains("DK"))
                    {
                        string[] str = text.Split('|');

                        int result = Dangky(str);
                        byte[] send = Encoding.ASCII.GetBytes(result.ToString());
                        clientSocket.Send(send);
                    }
                    else if (text.Contains("DN"))
                    {
                        string[] str = text.Split('|');
                        string[] result = Dangnhap(str);
                        string data = result[0] + "|" + result[1];
                        byte[] send = Encoding.ASCII.GetBytes(data);
                        clientSocket.Send(send);
                    }
                    else if (text.Contains("RQ"))
                    {
                        string[] str = text.Split('|');
                        string[] result = request(str);
                        string data = result[0] + "|" + result[1]+ "|" + result[2] + "|" + result[3];
                        byte[] send = Encoding.ASCII.GetBytes(data);
                        clientSocket.Send(send);
                    }
                    else if(text.Contains("FP"))
                    {
                        string[] str = text.Split('|');
                        string result = Forgotpass(str);
                        string data = result;
                        byte[] send = Encoding.ASCII.GetBytes(data);
                        clientSocket.Send(send);
                    }
                    else if(text.Contains("DMKM"))
                    {
                        string[] str = text.Split('|');
                        string result = DoiMatKhauMoi(str);
                        string data = result;
                        byte[] send = Encoding.ASCII.GetBytes(data);
                        clientSocket.Send(send);
                    }
                    else if (text == "quit")
                    {
                        lv_ClientsView.Items.Add(new ListViewItem("client disconnected"));
                        break;
                    }

                }
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
              catch(Exception ex)
            {
                  MessageBox.Show("Lỗi kết nối với client"+ex.Message);
            }
        }

        public int Dangky(string[] str)
        {
            try
            {
                ClassQLUSER data = new ClassQLUSER();
                SqlConnection connectionDB = data.ConnectToDatabase();
                if (connectionDB == null)
                {
                    return 0;
                }
                string checkUsername = "SELECT COUNT(*) FROM Users WHERE Username = @username";
                SqlCommand checkUsernameCmd = new SqlCommand(checkUsername, connectionDB);
                checkUsernameCmd.Parameters.AddWithValue("@username", str[1]);
                int user = (int)checkUsernameCmd.ExecuteScalar();
                if (user > 0)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại.");
                    return 0;
                }
                string CommandText = "SET DATEFORMAT dmy";
                SqlCommand CommandCmd = new SqlCommand(CommandText, connectionDB);
                CommandCmd.ExecuteNonQuery();
                string insert = "INSERT INTO Users (Username, Password, Email, FullName, Birthday) VALUES (@username, @password, @Email, @ten, @ngaysinh)";
                SqlCommand insertCmd = new SqlCommand(insert, connectionDB);
                insertCmd.Parameters.AddWithValue("@username", str[1]);
                insertCmd.Parameters.AddWithValue("@password", str[2]);
                insertCmd.Parameters.AddWithValue("@Email", str[3]);
                insertCmd.Parameters.AddWithValue("@ten", str[4]);
                insertCmd.Parameters.AddWithValue("@ngaysinh", str[5]);
                insertCmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi Đăng Ký: " + ex.Message);
                return 0;
            }
        }
        public string[] Dangnhap(string[] str)
        {
            string[] result = new string[2];
            result[0] = "0"; result[1] = "";
            try
            {
                ClassQLUSER data = new ClassQLUSER();
                SqlConnection connectionDB = data.ConnectToDatabase();
                if (connectionDB == null)
                {
                    return result;
                }
                string login = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password";
                SqlCommand loginCmd = new SqlCommand(login, connectionDB);
                loginCmd.Parameters.AddWithValue("@username", str[1]);
                loginCmd.Parameters.AddWithValue("@password", str[2]);
                int count = (int)loginCmd.ExecuteScalar();
                if (count == 1)
                {
                    result[0] = "1";
                    result[1] = data.GenerateToken(str[1]);
                    return result;

                }
                else
                {
                    return result;
                }
            }
            
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message);
                return result;
            }
        }
        public string[] request(string[] str)
        {
            string[] result = new string[4];
            result[0] = "0"; result[1] = "";
            result[2] = ""; result[3] = "";
            try
            {
                ClassQLUSER data = new ClassQLUSER();
                SqlConnection connectionDB = data.ConnectToDatabase();
                if (connectionDB == null)
                {
                    return result;
                }
                if (data.ValidateToken(str[2]))
                {
                    string strQuery = "SELECT Email, FullName, Birthday FROM Users WHERE Username = @username";
                    SqlCommand command = new SqlCommand(strQuery, connectionDB);
                    command.Parameters.AddWithValue("@username", str[1]);
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];
                        result[1] = row["Email"].ToString();
                        result[2] = row["FullName"].ToString();
                        DateTime birthday = DateTime.Parse(row["Birthday"].ToString());
                        result[3] = birthday.ToString("dd/MM/yyyy");
                        result[0] = "1";
                        return result;
                    }
                    else { return result; };

                }
                else { return result; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi yêu cầu server: " + ex.Message);
                return result;
            }
        }
        private string Forgotpass(string[] str)
        {
            string result = "0";
            
            try
            {
                ClassQLUSER data = new ClassQLUSER();
                SqlConnection connectionDB = data.ConnectToDatabase();
                if (connectionDB == null)
                {
                    return result;
                }
                string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                SqlCommand checkCmd = new SqlCommand(checkEmailQuery, connectionDB);
                checkCmd.Parameters.AddWithValue("@Email", str[1]);

                int emailExists = (int)checkCmd.ExecuteScalar();
                if (emailExists == 0)
                {
                    result ="Email khong ton tai";
                    return result;
                }
                string newpass = data.GenerateRandomPassword();
                string hashpass = data.HashPassword(newpass);
                string updateQuery = "UPDATE Users SET Password = @password WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(updateQuery, connectionDB);
                cmd.Parameters.AddWithValue("@password", hashpass);
                cmd.Parameters.AddWithValue("@Email", str[1]);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    result = "1";
                    data.SendEmail(str[1], newpass);
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi yêu cầu server: " + ex.Message);
                return result;
            }
        }

        private string DoiMatKhauMoi(string[] str)
        {
            string result = "0";
            string username = str[3];
            string mkHienTai = str[1];
            string hashPassMoi = str[2];

            try
            {
                ClassQLUSER data = new ClassQLUSER();
                SqlConnection connectionDB = data.ConnectToDatabase();
                if (connectionDB == null)
                {
                    return result;
                }
                string checkPasswordQuery = "SELECT Password FROM Users WHERE Username = @username";
                SqlCommand checkCmd = new SqlCommand(checkPasswordQuery, connectionDB);
                checkCmd.Parameters.AddWithValue("@username", username);

                string currentPasswordInDB = (string)checkCmd.ExecuteScalar();
                if (currentPasswordInDB == null || !currentPasswordInDB.Equals(mkHienTai))
                {
                    result = "Mat khau hien tai khong dung.";
                    return result;
                }

                string updateQuery = "UPDATE Users SET Password = @password WHERE Username = @username";
                SqlCommand cmd = new SqlCommand(updateQuery, connectionDB);
                cmd.Parameters.AddWithValue("@password", hashPassMoi);
                cmd.Parameters.AddWithValue("@username", username);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    result = "1";
                }
                else
                {
                    result="Khong the cap nhat mat khau.";
                    return result;
                }

                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        private void StopServer()
        {
            try
            {
                isServerRunning = false;
                listenerSocket.Close();
                serverThread.Join();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tắt server: " + ex.Message);
            }
        }

       


        public void btn_Exit_Click(object sender, EventArgs e)
        {
            StopServer();
            this.Close();
        }
    }
}
