namespace GuiGame {
    partial class HareAndTortoiseForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.boardTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.playersDataGridView = new System.Windows.Forms.DataGridView();
            this.resetButton = new System.Windows.Forms.Button();
            this.singleStepGroupBox = new System.Windows.Forms.GroupBox();
            this.noRadiobutton = new System.Windows.Forms.RadioButton();
            this.yesRadioButton = new System.Windows.Forms.RadioButton();
            this.nextPlayerButton = new System.Windows.Forms.Button();
            this.rollDiceButton = new System.Windows.Forms.Button();
            this.playersLabel = new System.Windows.Forms.Label();
            this.numberOfPlayersComboBox = new System.Windows.Forms.ComboBox();
            this.numberOfPlayersLabel = new System.Windows.Forms.Label();
            this.gameTitleLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.playerTokenImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameTextColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneyTextColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winnerCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).BeginInit();
            this.singleStepGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.boardTableLayoutPanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.playersDataGridView);
            this.splitContainer.Panel2.Controls.Add(this.resetButton);
            this.splitContainer.Panel2.Controls.Add(this.singleStepGroupBox);
            this.splitContainer.Panel2.Controls.Add(this.nextPlayerButton);
            this.splitContainer.Panel2.Controls.Add(this.rollDiceButton);
            this.splitContainer.Panel2.Controls.Add(this.playersLabel);
            this.splitContainer.Panel2.Controls.Add(this.numberOfPlayersComboBox);
            this.splitContainer.Panel2.Controls.Add(this.numberOfPlayersLabel);
            this.splitContainer.Panel2.Controls.Add(this.gameTitleLabel);
            this.splitContainer.Panel2.Controls.Add(this.exitButton);
            this.splitContainer.Size = new System.Drawing.Size(884, 664);
            this.splitContainer.SplitterDistance = 668;
            this.splitContainer.TabIndex = 3;
            // 
            // boardTableLayoutPanel
            // 
            this.boardTableLayoutPanel.AutoSize = true;
            this.boardTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.boardTableLayoutPanel.ColumnCount = 6;
            this.boardTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.boardTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.boardTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.boardTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.boardTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.boardTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.boardTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boardTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.boardTableLayoutPanel.Name = "boardTableLayoutPanel";
            this.boardTableLayoutPanel.RowCount = 7;
            this.boardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.boardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.boardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.boardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.boardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.boardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.boardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.boardTableLayoutPanel.Size = new System.Drawing.Size(668, 664);
            this.boardTableLayoutPanel.TabIndex = 0;
            // 
            // playersDataGridView
            // 
            this.playersDataGridView.AllowUserToAddRows = false;
            this.playersDataGridView.AllowUserToDeleteRows = false;
            this.playersDataGridView.AutoGenerateColumns = false;
            this.playersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.playerTokenImageColumn,
            this.nameTextColumn,
            this.moneyTextColumn,
            this.winnerCheckBoxColumn});
            this.playersDataGridView.DataSource = this.playerBindingSource;
            this.playersDataGridView.Location = new System.Drawing.Point(0, 132);
            this.playersDataGridView.Name = "playersDataGridView";
            this.playersDataGridView.RowHeadersVisible = false;
            this.playersDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.playersDataGridView.Size = new System.Drawing.Size(191, 155);
            this.playersDataGridView.TabIndex = 12;
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.Location = new System.Drawing.Point(33, 609);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 11;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // singleStepGroupBox
            // 
            this.singleStepGroupBox.Controls.Add(this.noRadiobutton);
            this.singleStepGroupBox.Controls.Add(this.yesRadioButton);
            this.singleStepGroupBox.Location = new System.Drawing.Point(18, 343);
            this.singleStepGroupBox.Name = "singleStepGroupBox";
            this.singleStepGroupBox.Size = new System.Drawing.Size(159, 82);
            this.singleStepGroupBox.TabIndex = 10;
            this.singleStepGroupBox.TabStop = false;
            this.singleStepGroupBox.Text = "Single Step";
            // 
            // noRadiobutton
            // 
            this.noRadiobutton.AutoSize = true;
            this.noRadiobutton.Location = new System.Drawing.Point(37, 46);
            this.noRadiobutton.Name = "noRadiobutton";
            this.noRadiobutton.Size = new System.Drawing.Size(39, 17);
            this.noRadiobutton.TabIndex = 1;
            this.noRadiobutton.TabStop = true;
            this.noRadiobutton.Text = "No";
            this.noRadiobutton.UseVisualStyleBackColor = true;
            this.noRadiobutton.CheckedChanged += new System.EventHandler(this.singleStepRadioButton_CheckedChanged);
            // 
            // yesRadioButton
            // 
            this.yesRadioButton.AutoSize = true;
            this.yesRadioButton.Location = new System.Drawing.Point(37, 23);
            this.yesRadioButton.Name = "yesRadioButton";
            this.yesRadioButton.Size = new System.Drawing.Size(43, 17);
            this.yesRadioButton.TabIndex = 0;
            this.yesRadioButton.TabStop = true;
            this.yesRadioButton.Text = "Yes";
            this.yesRadioButton.UseVisualStyleBackColor = true;
            this.yesRadioButton.CheckedChanged += new System.EventHandler(this.singleStepRadioButton_CheckedChanged);
            // 
            // nextPlayerButton
            // 
            this.nextPlayerButton.Enabled = false;
            this.nextPlayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextPlayerButton.Location = new System.Drawing.Point(18, 455);
            this.nextPlayerButton.Name = "nextPlayerButton";
            this.nextPlayerButton.Size = new System.Drawing.Size(159, 77);
            this.nextPlayerButton.TabIndex = 9;
            this.nextPlayerButton.Text = "Click Next Player\'s Roll";
            this.nextPlayerButton.UseVisualStyleBackColor = true;
            this.nextPlayerButton.Visible = false;
            this.nextPlayerButton.Click += new System.EventHandler(this.nextPlayerButton_Click);
            // 
            // rollDiceButton
            // 
            this.rollDiceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rollDiceButton.Enabled = false;
            this.rollDiceButton.Location = new System.Drawing.Point(76, 557);
            this.rollDiceButton.Name = "rollDiceButton";
            this.rollDiceButton.Size = new System.Drawing.Size(75, 23);
            this.rollDiceButton.TabIndex = 8;
            this.rollDiceButton.Text = "Roll Dice";
            this.rollDiceButton.UseVisualStyleBackColor = true;
            this.rollDiceButton.Click += new System.EventHandler(this.rollDiceButton_Click);
            // 
            // playersLabel
            // 
            this.playersLabel.AutoSize = true;
            this.playersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playersLabel.Location = new System.Drawing.Point(57, 94);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(91, 25);
            this.playersLabel.TabIndex = 6;
            this.playersLabel.Text = "Players";
            // 
            // numberOfPlayersComboBox
            // 
            this.numberOfPlayersComboBox.FormattingEnabled = true;
            this.numberOfPlayersComboBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.numberOfPlayersComboBox.Location = new System.Drawing.Point(123, 55);
            this.numberOfPlayersComboBox.Name = "numberOfPlayersComboBox";
            this.numberOfPlayersComboBox.Size = new System.Drawing.Size(37, 21);
            this.numberOfPlayersComboBox.TabIndex = 5;
            this.numberOfPlayersComboBox.SelectedIndexChanged += new System.EventHandler(this.numberOfPlayersComboBox_SelectedIndexChanged);
            // 
            // numberOfPlayersLabel
            // 
            this.numberOfPlayersLabel.AutoSize = true;
            this.numberOfPlayersLabel.Location = new System.Drawing.Point(25, 63);
            this.numberOfPlayersLabel.Name = "numberOfPlayersLabel";
            this.numberOfPlayersLabel.Size = new System.Drawing.Size(93, 13);
            this.numberOfPlayersLabel.TabIndex = 4;
            this.numberOfPlayersLabel.Text = "Number of Players";
            // 
            // gameTitleLabel
            // 
            this.gameTitleLabel.AutoSize = true;
            this.gameTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameTitleLabel.ForeColor = System.Drawing.Color.Red;
            this.gameTitleLabel.Location = new System.Drawing.Point(-2, 21);
            this.gameTitleLabel.Name = "gameTitleLabel";
            this.gameTitleLabel.Size = new System.Drawing.Size(201, 25);
            this.gameTitleLabel.TabIndex = 3;
            this.gameTitleLabel.Text = "Hare and Tortoise";
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Location = new System.Drawing.Point(119, 609);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // timer
            // 
            this.timer.Interval = 120;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // playerTokenImageColumn
            // 
            this.playerTokenImageColumn.DataPropertyName = "PlayerTokenImage";
            this.playerTokenImageColumn.HeaderText = "Colour";
            this.playerTokenImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.playerTokenImageColumn.Name = "playerTokenImageColumn";
            this.playerTokenImageColumn.ReadOnly = true;
            this.playerTokenImageColumn.Width = 50;
            // 
            // nameTextColumn
            // 
            this.nameTextColumn.DataPropertyName = "Name";
            this.nameTextColumn.HeaderText = "Name";
            this.nameTextColumn.Name = "nameTextColumn";
            this.nameTextColumn.Width = 65;
            // 
            // moneyTextColumn
            // 
            this.moneyTextColumn.DataPropertyName = "Money";
            this.moneyTextColumn.HeaderText = "$";
            this.moneyTextColumn.Name = "moneyTextColumn";
            this.moneyTextColumn.ReadOnly = true;
            this.moneyTextColumn.Width = 30;
            // 
            // winnerCheckBoxColumn
            // 
            this.winnerCheckBoxColumn.DataPropertyName = "Winner";
            this.winnerCheckBoxColumn.HeaderText = "Winner";
            this.winnerCheckBoxColumn.Name = "winnerCheckBoxColumn";
            this.winnerCheckBoxColumn.ReadOnly = true;
            this.winnerCheckBoxColumn.Width = 45;
            // 
            // playerBindingSource
            // 
            this.playerBindingSource.DataSource = typeof(SharedGameClasses.Player);
            // 
            // HareAndTortoiseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 664);
            this.Controls.Add(this.splitContainer);
            this.Name = "HareAndTortoiseForm";
            this.Text = "Hare and Tortoise";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).EndInit();
            this.singleStepGroupBox.ResumeLayout(false);
            this.singleStepGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label gameTitleLabel;
        private System.Windows.Forms.GroupBox singleStepGroupBox;
        private System.Windows.Forms.RadioButton noRadiobutton;
        private System.Windows.Forms.RadioButton yesRadioButton;
        private System.Windows.Forms.Button nextPlayerButton;
        private System.Windows.Forms.Button rollDiceButton;
        private System.Windows.Forms.Label playersLabel;
        private System.Windows.Forms.ComboBox numberOfPlayersComboBox;
        private System.Windows.Forms.Label numberOfPlayersLabel;
        private System.Windows.Forms.TableLayoutPanel boardTableLayoutPanel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.DataGridView playersDataGridView;
        private System.Windows.Forms.BindingSource playerBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn playerTokenImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameTextColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneyTextColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn winnerCheckBoxColumn;
        private System.Windows.Forms.Timer timer;
    }
}

