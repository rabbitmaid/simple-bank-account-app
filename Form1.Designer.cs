namespace BankAccountApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            OwnerTxt = new TextBox();
            label1 = new Label();
            label2 = new Label();
            BankAccountGrid = new DataGridView();
            CreateAccountBtn = new Button();
            DepositBtn = new Button();
            WithdrawBtn = new Button();
            AmountNum = new NumericUpDown();
            InterestRateNum = new NumericUpDown();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)BankAccountGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AmountNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InterestRateNum).BeginInit();
            SuspendLayout();
            // 
            // OwnerTxt
            // 
            OwnerTxt.Location = new Point(91, 27);
            OwnerTxt.Name = "OwnerTxt";
            OwnerTxt.Size = new Size(177, 23);
            OwnerTxt.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 30);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 1;
            label1.Text = "Owner:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 220);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 3;
            label2.Text = "Amount:";
            // 
            // BankAccountGrid
            // 
            BankAccountGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            BankAccountGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BankAccountGrid.Location = new Point(293, 27);
            BankAccountGrid.Name = "BankAccountGrid";
            BankAccountGrid.Size = new Size(351, 168);
            BankAccountGrid.TabIndex = 4;
            // 
            // CreateAccountBtn
            // 
            CreateAccountBtn.Location = new Point(28, 113);
            CreateAccountBtn.Name = "CreateAccountBtn";
            CreateAccountBtn.Size = new Size(240, 23);
            CreateAccountBtn.TabIndex = 5;
            CreateAccountBtn.Text = "Create Account";
            CreateAccountBtn.UseVisualStyleBackColor = true;
            CreateAccountBtn.Click += CreateAccountBtn_Click;
            // 
            // DepositBtn
            // 
            DepositBtn.Location = new Point(293, 217);
            DepositBtn.Name = "DepositBtn";
            DepositBtn.Size = new Size(105, 23);
            DepositBtn.TabIndex = 6;
            DepositBtn.Text = "Deposit";
            DepositBtn.UseVisualStyleBackColor = true;
            DepositBtn.Click += DepositBtn_Click;
            // 
            // WithdrawBtn
            // 
            WithdrawBtn.Location = new Point(415, 217);
            WithdrawBtn.Name = "WithdrawBtn";
            WithdrawBtn.Size = new Size(105, 23);
            WithdrawBtn.TabIndex = 7;
            WithdrawBtn.Text = "Withdraw";
            WithdrawBtn.UseVisualStyleBackColor = true;
            WithdrawBtn.Click += WithdrawBtn_Click;
            // 
            // AmountNum
            // 
            AmountNum.Location = new Point(91, 217);
            AmountNum.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            AmountNum.Minimum = new decimal(new int[] { 999999999, 0, 0, int.MinValue });
            AmountNum.Name = "AmountNum";
            AmountNum.Size = new Size(177, 23);
            AmountNum.TabIndex = 8;
            // 
            // InterestRateNum
            // 
            InterestRateNum.Location = new Point(143, 69);
            InterestRateNum.Name = "InterestRateNum";
            InterestRateNum.Size = new Size(125, 23);
            InterestRateNum.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 72);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 10;
            label3.Text = "Interest rate (%):";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(670, 258);
            Controls.Add(label3);
            Controls.Add(InterestRateNum);
            Controls.Add(AmountNum);
            Controls.Add(WithdrawBtn);
            Controls.Add(DepositBtn);
            Controls.Add(CreateAccountBtn);
            Controls.Add(BankAccountGrid);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(OwnerTxt);
            Name = "Form1";
            Text = "BankAccountApp";
            ((System.ComponentModel.ISupportInitialize)BankAccountGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)AmountNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)InterestRateNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox OwnerTxt;
        private Label label1;
        private Label label2;
        private DataGridView BankAccountGrid;
        private Button CreateAccountBtn;
        private Button DepositBtn;
        private Button WithdrawBtn;
        private NumericUpDown AmountNum;
        private NumericUpDown InterestRateNum;
        private Label label3;
    }
}
