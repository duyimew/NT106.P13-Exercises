﻿using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
namespace QLUSER
{
    internal class ClassQLUSER
    {
        public SqlConnection ConnectToDatabase()
        {
            CheckDB();
            string connectionString = "Server=localhost;Database=mydatabase;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public void CreateDBandTable(SqlConnection connection)
        {
            string fileNameToSearch = "CreateDataBaselt3.sql";
            string projectDirectory = GetProjectRootDirectory();
            string filePath = FindFile(fileNameToSearch, projectDirectory);

            if (!string.IsNullOrEmpty(filePath))
            {
                ExecuteSqlFile(filePath, connection);
            }
            else
            {
                MessageBox.Show("Không tìm thấy file SQL với tên: " + fileNameToSearch);
            }
        }

        public string GetProjectRootDirectory()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.Parent.FullName;
            return projectDirectory;
        }

        private string FindFile(string fileName, string directory)
        {
            try
            {
                foreach (string file in Directory.GetFiles(directory, fileName, SearchOption.TopDirectoryOnly))
                {
                    return file;
                }

                foreach (string subDirectory in Directory.GetDirectories(directory))
                {
                    try
                    {
                        foreach (string file in Directory.GetFiles(subDirectory, fileName, SearchOption.TopDirectoryOnly))
                        {
                            return file;
                        }

                        string result = FindFile(fileName, subDirectory);
                        if (!string.IsNullOrEmpty(result))
                        {
                            return result;
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Lỗi khi tìm kiếm file trong thư mục: {subDirectory}");
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch (DirectoryNotFoundException)
            {
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi tìm kiếm file");
            }
            return null;
        }

        private void ExecuteSqlFile(string filePath, SqlConnection connection)
        {
            try
            {
                string script = File.ReadAllText(filePath);
                string[] commands = script.Split(new string[] { "go" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string command in commands)
                {
                    if (!string.IsNullOrWhiteSpace(command))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("File SQL đã được thực thi thành công.");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi chạy lệnh SQL");
            }
        }

        public void CheckDB()
        {
            string connectionstring = "Server=localhost;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                string checkdb = "SELECT COUNT(*) FROM sys.databases WHERE name='mydatabase'";
                SqlCommand checkdbcommand = new SqlCommand(checkdb, connection);
                int dbexists = (int)checkdbcommand.ExecuteScalar();
                if (dbexists == 0)
                {
                    CreateDBandTable(connection);
                }
            }
        }
        public string HashPassword(string password)
        {
            try
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    StringBuilder builder = new StringBuilder();
                    foreach (byte b in bytes)
                    {
                        builder.Append(b.ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi hash mật khẩu");
                return null;
            }
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public string GenerateToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_which_is_long_enough_32_bytes")); // Đặt một secret key an toàn, tối thiểu 32 bytes
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, username),
        new Claim(JwtRegisteredClaimNames.Exp, DateTime.UtcNow.AddMinutes(30).ToString())
    };

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_which_is_long_enough_32_bytes"));
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string find(string name)
        {
            string fileNameToSearch = name;
            string projectDirectory = GetProjectRootDirectory();
            string filePath = FindFile(fileNameToSearch, projectDirectory);

            if (!string.IsNullOrEmpty(filePath))
            {
                return filePath;
            }
            else
            {
                MessageBox.Show("Không tìm thấy file SQL với tên: " + fileNameToSearch);
                return null;
            }
        }       
    }
}
