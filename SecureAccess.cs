using System;


namespace CodeQLAlertTrigger
{
    public class SecureAccess
    {
        private const string AdminUsername = "admin";
        private const string AdminPassword = "P@ssword123" ;
        private DataAccess _access = new DataAccess();

        public SecureAccess()
        {
            
        }

        public AccessLevel Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(password))
            {
                return AccessLevel.None;
            }

            // ToLowerInvariant
            if (username.ToLowerInvariant() == AdminUsername.ToLowerInvariant() && password.ToLowerInvariant() == AdminPassword.ToLowerInvariant())
            {
                return AccessLevel.Admin;
            }

            return _access.IsValidUser(username,password) ? AccessLevel.User : AccessLevel.None;
        }
    }

    public enum AccessLevel
    {
        None,
        User,
        Admin
    }
}