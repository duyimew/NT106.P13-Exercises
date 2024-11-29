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

namespace QLUSER
{
    public partial class ForgotPass : Form
    {
        public ForgotPass()
        {
            InitializeComponent();
        }

        private void btn_sendEmail_Click(object sender, EventArgs e)
        {
            string email = tb_email.Text;

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email address.");
                return;
            }

            string newPassword = GenerateRandomPassword();
            bool success = UpdatePasswordInDatabase(email, newPassword);

            if (success)
            {
                SendEmail(email, newPassword);
            }
            else
            {
                MessageBox.Show("Email not found in the system.");
            }
        }

        private string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$%";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private bool UpdatePasswordInDatabase(string email, string newPassword)
        {
            try
            {
                ClassQLUSER data = new ClassQLUSER();
                SqlConnection connectionDB = data.ConnectToDatabase();
                if (connectionDB == null)
                {
                    return false;
                }

                string hashPassword = data.HashPassword(newPassword);
                string query = "UPDATE Users SET Password = @password WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, connectionDB);
                cmd.Parameters.AddWithValue("@password", hashPassword);
                cmd.Parameters.AddWithValue("@Email", email);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating password: " + ex.Message);
                return false;
            }
        }

        public void SendEmail(string recipientEmail, string newPassword)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("chatapp710@gmail.com");
                mail.To.Add(recipientEmail);
                mail.Subject = "Password Reset Request";
                mail.Body = $"Your new password is: {newPassword}";

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("chatapp710@gmail.com", "mmymzuivyjhhqmtw"),
                    EnableSsl = true,
                };

                smtpClient.Send(mail);
                MessageBox.Show("The new password has been sent to your email.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
            

        }
    }
}
