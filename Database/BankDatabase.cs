using BankAccountApp.App;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp.Database
{
    internal class BankDatabase
    {
        private readonly string connectionString;

        public BankDatabase()
        {
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BankAccountApp");

            Directory.CreateDirectory(folder);

            string databasePath = Path.Combine(folder, "BankAccountDB.db");

            connectionString = $"Data Source={databasePath}";

            CreateTable();
        }

        //public void TestConnection()
        //{
        //    using (SqliteConnection connection = new SqliteConnection(connectionString))
        //    {
        //        connection.Open();

        //    }

        //}


        private void CreateTable()
        {
            using (SqliteConnection connection =
                   new SqliteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    CREATE TABLE IF NOT EXISTS Accounts
                    (
                        AccountNumber TEXT PRIMARY KEY,
                        Owner TEXT NOT NULL,
                        AccountType TEXT NOT NULL,
                        InterestRate REAL NULL,
                        Balance INTEGER NOT NULL DEFAULT 0
                    );";

                using (SqliteCommand command =
                       new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateAccount(BankAccount account)
        {
            using (SqliteConnection connection =
                   new SqliteConnection(connectionString))
            {
                connection.Open();

                string query = @"
            INSERT INTO Accounts
            (AccountNumber, Owner, AccountType, InterestRate, Balance)
            VALUES
            ($accountNumber, $owner, $accountType, $interestRate, $balance);
        ";

                using (SqliteCommand command =
                       new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "$accountNumber",
                        account.AccountNumber.ToString()
                    );

                    command.Parameters.AddWithValue(
                        "$owner",
                        account.Owner
                    );

                    command.Parameters.AddWithValue(
                        "$accountType",
                        account is SavingsAccount ? "Savings" : "Regular"
                    );

                    if (account is SavingsAccount savings)
                    {
                        command.Parameters.AddWithValue(
                            "$interestRate",
                            savings.InterestRate
                        );
                    }
                    else
                    {
                        command.Parameters.AddWithValue(
                            "$interestRate",
                            DBNull.Value
                        );
                    }

                    command.Parameters.AddWithValue(
                        "$balance",
                        decimal.ToInt64(account.Balance * 100)
                    );

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<BankAccount> GetAllAccounts()
        {
            List<BankAccount> accounts = new List<BankAccount>();

            using (SqliteConnection connection =
                   new SqliteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Accounts";

                using (SqliteCommand command =
                       new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string owner = reader["Owner"].ToString();

                            Guid accountNumber = Guid.Parse(
                                reader["AccountNumber"].ToString()
                            );

                            decimal balance =
                                Convert.ToInt64(reader["Balance"]) / 100m;

                            string accountType =
                                reader["AccountType"].ToString();

                            BankAccount account;

                            if (accountType == "Savings")
                            {
                                decimal interestRate =
                                    Convert.ToDecimal(reader["InterestRate"]);

                                account = new SavingsAccount(owner, interestRate);
                            }
                            else
                            {
                                account = new BankAccount(owner);
                            }

                            // Restore the original account number and balance
                            account.AccountNumber = accountNumber;
                            account.RestoreBalance(balance);

                            accounts.Add(account);
                        }
                    }
                }
            }

            return accounts;
        }

        public void UpdateBalance(BankAccount account)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string query = @"
            UPDATE Accounts
            SET Balance = $balance
            WHERE AccountNumber = $accountNumber;
        ";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "$balance",
                        decimal.ToInt64(account.Balance * 100)
                    );

                    command.Parameters.AddWithValue(
                        "$accountNumber",
                        account.AccountNumber.ToString()
                    );

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
