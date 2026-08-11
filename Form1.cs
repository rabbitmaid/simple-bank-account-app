namespace BankAccountApp
{
    public partial class Form1 : Form
    {
        List<BankAccount> BankAccounts = new List<BankAccount>();

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OwnerTxt.Text))
            {
                MessageBox.Show("Owner name required ", "Error Notice!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if(InterestRateNum.Value > 0)
            {
                SavingsAccount savingsAccount = new SavingsAccount(OwnerTxt.Text, InterestRateNum.Value);
                BankAccounts.Add(savingsAccount);

            }else
            {
                BankAccount bankAccount = new BankAccount(OwnerTxt.Text);
                BankAccounts.Add(bankAccount);
            }

            RefreshApplication();
        }


        private void DepositBtn_Click(object sender, EventArgs e)
        {
            if (BankAccountGrid.SelectedRows.Count == 1)
            {
                BankAccount selectedBankAccount = BankAccountGrid.SelectedRows[0].DataBoundItem as BankAccount;

                try
                {
                    string message = selectedBankAccount.Deposit(AmountNum.Value);
                    MessageBox.Show(message, "Amount deposit", MessageBoxButtons.OK , MessageBoxIcon.Information);
                }
                catch (InvalidAmountException ex) {
                    MessageBox.Show(ex.Message, "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                RefreshApplication();
            }
        }

        private void WithdrawBtn_Click(object sender, EventArgs e)
        {
            if(BankAccountGrid.SelectedRows.Count == 1)
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
    }
}
