using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CodeQLAlertTrigger
{
    public class DataAccess
    {
        private Dictionary<string, string> _users = new Dictionary<string, string>();
        private const string SqlConnectionString = "";
        private const string SqlConnectionString2 = "Server=localhost;Database=SecurityDb;User Id=sa;Password=MyP@ssw0rd2!;";

        public DataAccess()
        {
        }

        public bool IsValidUser(string username, string password)
        {
            PopulateUsers();
            // Should access the database but we wont
            if (!_users.ContainsKey(username))
            {
                return false;
            }

            return _users[username] == password;
        }

        string GeneratePassword()
        {
            // https://codeql.github.com/codeql-query-help/csharp/cs-insecure-randomness/
            // BAD: Password is generated using a cryptographically insecure RNG
            Random gen = new Random();
            string password = "mypassword" + gen.Next();
            return password;
        }
        
        private void PopulateUsers()
        {
            try
            {
                using (var conn = new SqlConnection())
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "select username,password from users";
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        _users.Add(rdr.GetString(0), rdr.GetString(1));

                    }
                }
            } catch
            {
                // Accept DB failure, populate pre-filled
                _users.Add("user1", "password1");
                _users.Add("user2", "password2");
                _users.Add("user3", "password3");
                _users.Add("user4", "password4");
                _users.Add("user5", "password5");

            }
        }
    }
}
