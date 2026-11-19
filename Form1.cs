namespace BankAccountApp
{
    public partial class Form1 : Form
    {
        List<BankAccount> BankAccounts = new List<BankAccount>();
        private BankDatabase db = new BankDatabase();

        public Form1()
        {
            InitializeComponent();
        }

        //private void CreateAccountBtn_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(OwnerTxt.Text))
        //    {
        //        MessageBox.Show("Owner name required ", "Error Notice!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }


        //    if (InterestRateNum.Value > 0)
        //    {
        //        SavingsAccount savingsAccount = new SavingsAccount(OwnerTxt.Text, InterestRateNum.Value);
        //        BankAccounts.Add(savingsAccount);

        //    }
        //    else
        //    {
        //        BankAccount bankAccount = new BankAccount(OwnerTxt.Text);
        //        BankAccounts.Add(bankAccount);
        //    }

        //    RefreshApplication();
        //}


        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(OwnerTxt.Text))
            {
                MessageBox.Show("Owner name required",
                    "Error Notice!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            try
            {
                BankAccount account;

                if (InterestRateNum.Value > 0)
                {
                    account = new SavingsAccount(
                        OwnerTxt.Text,
                        InterestRateNum.Value
                    );
                }
                else
                {
                    account = new BankAccount(OwnerTxt.Text);
                }

                // Save the account to SQLite
                db.CreateAccount(account);

                // Add account to your existing list
                BankAccounts.Add(account);

                MessageBox.Show(
                    "Account created successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                RefreshApplication();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void DepositBtn_Click(object sender, EventArgs e)
        {
            if (BankAccountGrid.SelectedRows.Count > 0)
            {
                BankAccount selectedBankAccount = BankAccountGrid.SelectedRows[0].DataBoundItem as BankAccount;

                try
                {
                    string message = selectedBankAccount.Deposit(AmountNum.Value);
                    MessageBox.Show(message, "Amount deposit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (InvalidAmountException ex)
                {
                    MessageBox.Show(ex.Message, "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                RefreshApplication();
            }else
            {
                MessageBox.Show("Please select an account first.");
            }
        }

        private void WithdrawBtn_Click(object sender, EventArgs e)
        {
            if (BankAccountGrid.SelectedRows.Count > 0)
            {
                BankAccount selectedBankAccount = BankAccountGrid.SelectedRows[0].DataBoundItem as BankAccount;

                try
                {
                    string message = selectedBankAccount.Withdraw(AmountNum.Value);
                    MessageBox.Show(message, "Amount withdraw", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (InvalidAmountException ex)
                {
                    MessageBox.Show(ex.Message, "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                RefreshApplication();
            }else
            {
                MessageBox.Show("Please select an account first.");
            }
        }

        private void RefreshApplication()
        {
            BankAccountGrid.DataSource = null;
            BankAccountGrid.DataSource = BankAccounts;
            OwnerTxt.Text = string.Empty;
            AmountNum.Value = 0;
            InterestRateNum.Value = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BankAccounts = db.GetAllAccounts();
            RefreshApplication();
        }
    }
}
