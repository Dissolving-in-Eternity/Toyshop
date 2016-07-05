using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace Toyshop
{
    static class AccountManager
    {
        public enum AccountType { ADMIN, USER }

        [Serializable]
        private struct AccountData
        {
            public AccountType rights;
            public object passwordHash;
            public bool active;
        }

        private static Dictionary<string, AccountData> credentials;
        private static AccountData currentUserData;

        private static string login;
        public static string Name
        {
            get
            {
                return GetNameFromLogin(login);
            }
            private set
            {
                login = value;
            }
        }
        public static AccountType GetRights() { return currentUserData.rights; }
        public static bool Active { get { return currentUserData.active; } }
        

        static AccountManager()
        {
            credentials = LoadCredentials();

            //If failed to open file then create one
            if(credentials == null)
            {
                credentials = new Dictionary<string, AccountData>();
                CreateNewAccount("admin", "admin".GetHashCode(), true);
                CreateNewAccount("John Doe", string.Empty.GetHashCode());
                CreateNewAccount("Shipilova A.A.", string.Empty.GetHashCode());
                CreateNewAccount("Frank Sinatra", string.Empty.GetHashCode());
                CreateNewAccount("Mary Poppins", string.Empty.GetHashCode());
            }
        }

        private static Dictionary<string, AccountData> LoadCredentials()
        {
            string path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "accounts");
            if (!File.Exists(path))
                return null;

            using (Stream stream = File.Open(path, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (Dictionary<string, AccountData>)binaryFormatter.Deserialize(stream);
            }
        }

        public static string GetNameFromLogin(string login)
        {
            if (credentials[login.ToLower()].rights == AccountType.ADMIN)
                return login;

            OleDbDataAdapter ad = new OleDbDataAdapter($"SELECT Sellers.FullName FROM Sellers WHERE Sellers.FullName LIKE '{login}'", Utils.connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt.Rows[0][0].ToString();
        }

        public static bool CreateNewAccount(string login, object passwordHash, bool adminRights = false)
        {
            string loginLower = login.ToLower();
            if (credentials.ContainsKey(loginLower))
            {
                //If there is an active account with given login then fail creation
                if(credentials[loginLower].active)
                    return false;
                //If there is deactivated account then reactivate it
                else
                {
                    var data = credentials[loginLower];
                    data.active = true;
                    data.rights = adminRights ? AccountType.ADMIN : AccountType.USER;
                    data.passwordHash = passwordHash;
                    credentials[loginLower] = data;
                }
            }
            //Create new account
            else
            {
                AccountData accountData = new AccountData();
                accountData.active = true;
                accountData.rights = adminRights ? AccountType.ADMIN : AccountType.USER;
                accountData.passwordHash = passwordHash;
                credentials.Add(loginLower, accountData);
            }

            SaveCredentials();

            //Create appropriate seller in database
            //But only if it's not an admin. Admins cannot be sellers
            if (!adminRights)
            {
                string insertString = $@"INSERT INTO Sellers VALUES ('{login}')";
                OleDbCommand insertCommand = new OleDbCommand(Utils.FixReservedWords(insertString), Utils.connection);

                try
                {
                    Utils.connection.Open();
                    insertCommand.ExecuteNonQuery();
                }
                //There will be SQL error if user was deactivated, because users are not removed from database with deactivation
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show($"User {login} successfully reactivated", "User reactivated",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                finally { Utils.connection.Close(); }
            }

            return true;
        }

        public static bool DeleteAccount(string login)
        {
            //Can't delete myself
            login = login.ToLower();
            if (Name == login)
                return false;

            //Deactivate in credentials
            var data = credentials[login];
            data.active = false;
            credentials[login] = data;
            SaveCredentials();

            //Remove from database if possible
            //Only if it's not an admin. Admins never get database entry
            if (data.rights == AccountType.USER)
            {
                string deleteString = $@"DELETE FROM Sellers WHERE FullName LIKE '{login}'";
                OleDbCommand deleteCommand = new OleDbCommand(Utils.FixReservedWords(deleteString), Utils.connection);

                try
                {
                    Utils.connection.Open();
                    deleteCommand.ExecuteNonQuery();
                }
                //If row is used in other tables then there will be SQL deletion error
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show($"Seller {login} left in database for legacy purposes.", "User deactivated",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                finally { Utils.connection.Close(); }
            }

            return true;
        }

        public static void SetNewPassword(string login, object newPassHash)
        {
            login = login.ToLower();
            var data = credentials[login];
            data.passwordHash = newPassHash;
            credentials[login] = data;
            SaveCredentials();
        }

        public static bool Login(string login, object passwordHash)
        {
            login = login.ToLower();
            if(credentials.ContainsKey(login) && credentials[login].passwordHash.Equals(passwordHash))
            {
                currentUserData = credentials[login];
                Name = login;
                return true;
            }

            return false;
        }

        public static List<string> GetRegisteredActiveUsers()
        {
            return (from x in credentials where x.Value.active == true select x.Key).ToList();
        }

        private static void SaveCredentials()
        {
            string path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "accounts");
            using (Stream stream = File.Open(path, FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, credentials);
            }
        }
    }
}
