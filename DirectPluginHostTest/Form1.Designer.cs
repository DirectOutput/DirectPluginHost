namespace DirectPluginHostTest
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.PluginInit = new System.Windows.Forms.Button();
            this.PluginFinish = new System.Windows.Forms.Button();
            this.DataNumber = new System.Windows.Forms.TextBox();
            this.DataValue = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DataTableElementType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DataHostingApplication = new System.Windows.Forms.TextBox();
            this.DataTableFilename = new System.Windows.Forms.TextBox();
            this.DataGameName = new System.Windows.Forms.TextBox();
            this.PluginList = new System.Windows.Forms.DataGridView();
            this.PluginListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PluginListStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PluginListLastException = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.PluginHostStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PluginList)).BeginInit();
            this.SuspendLayout();
            // 
            // PluginInit
            // 
            this.PluginInit.Location = new System.Drawing.Point(599, 60);
            this.PluginInit.Name = "PluginInit";
            this.PluginInit.Size = new System.Drawing.Size(112, 23);
            this.PluginInit.TabIndex = 0;
            this.PluginInit.Text = "Init Plugins";
            this.PluginInit.UseVisualStyleBackColor = true;
            this.PluginInit.Click += new System.EventHandler(this.PluginInit_Click);
            // 
            // PluginFinish
            // 
            this.PluginFinish.Location = new System.Drawing.Point(599, 194);
            this.PluginFinish.Name = "PluginFinish";
            this.PluginFinish.Size = new System.Drawing.Size(112, 23);
            this.PluginFinish.TabIndex = 1;
            this.PluginFinish.Text = "Finish Plugins";
            this.PluginFinish.UseVisualStyleBackColor = true;
            this.PluginFinish.Click += new System.EventHandler(this.PluginFinish_Click);
            // 
            // DataNumber
            // 
            this.DataNumber.Location = new System.Drawing.Point(353, 133);
            this.DataNumber.Name = "DataNumber";
            this.DataNumber.Size = new System.Drawing.Size(100, 20);
            this.DataNumber.TabIndex = 2;
            // 
            // DataValue
            // 
            this.DataValue.Location = new System.Drawing.Point(493, 133);
            this.DataValue.Name = "DataValue";
            this.DataValue.Size = new System.Drawing.Size(100, 20);
            this.DataValue.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(599, 131);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Send Data";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(459, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Value:";
            // 
            // DataTableElementType
            // 
            this.DataTableElementType.FormattingEnabled = true;
            this.DataTableElementType.Items.AddRange(new object[] {
            "A",
            "B - Score digit",
            "C - Score",
            "D - Score led",
            "E - EM table element",
            "F",
            "G - General illumination",
            "H",
            "I",
            "K",
            "L - Lamp",
            "M - Mech",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S - Solenoid",
            "T",
            "U",
            "V",
            "W - Switch",
            "X",
            "Y",
            "Z",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "? - Unknown type"});
            this.DataTableElementType.Location = new System.Drawing.Point(114, 133);
            this.DataTableElementType.Name = "DataTableElementType";
            this.DataTableElementType.Size = new System.Drawing.Size(166, 21);
            this.DataTableElementType.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Table element type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hosting application:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Table filename:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Game name:";
            // 
            // DataHostingApplication
            // 
            this.DataHostingApplication.Location = new System.Drawing.Point(123, 19);
            this.DataHostingApplication.Name = "DataHostingApplication";
            this.DataHostingApplication.Size = new System.Drawing.Size(422, 20);
            this.DataHostingApplication.TabIndex = 12;
            // 
            // DataTableFilename
            // 
            this.DataTableFilename.Location = new System.Drawing.Point(123, 42);
            this.DataTableFilename.Name = "DataTableFilename";
            this.DataTableFilename.Size = new System.Drawing.Size(422, 20);
            this.DataTableFilename.TabIndex = 13;
            // 
            // DataGameName
            // 
            this.DataGameName.Location = new System.Drawing.Point(123, 68);
            this.DataGameName.Name = "DataGameName";
            this.DataGameName.Size = new System.Drawing.Size(422, 20);
            this.DataGameName.TabIndex = 14;
            // 
            // PluginList
            // 
            this.PluginList.AllowUserToAddRows = false;
            this.PluginList.AllowUserToDeleteRows = false;
            this.PluginList.AllowUserToOrderColumns = true;
            this.PluginList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PluginList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PluginListName,
            this.PluginListStatus,
            this.PluginListLastException});
            this.PluginList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.PluginList.Location = new System.Drawing.Point(13, 245);
            this.PluginList.MultiSelect = false;
            this.PluginList.Name = "PluginList";
            this.PluginList.ReadOnly = true;
            this.PluginList.RowHeadersVisible = false;
            this.PluginList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PluginList.Size = new System.Drawing.Size(733, 186);
            this.PluginList.TabIndex = 15;
            // 
            // PluginListName
            // 
            this.PluginListName.HeaderText = "Name";
            this.PluginListName.Name = "PluginListName";
            this.PluginListName.ReadOnly = true;
            // 
            // PluginListStatus
            // 
            this.PluginListStatus.HeaderText = "Status";
            this.PluginListStatus.Name = "PluginListStatus";
            this.PluginListStatus.ReadOnly = true;
            // 
            // PluginListLastException
            // 
            this.PluginListLastException.HeaderText = "Last exception";
            this.PluginListLastException.Name = "PluginListLastException";
            this.PluginListLastException.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Plugin host status:";
            // 
            // PluginHostStatus
            // 
            this.PluginHostStatus.AutoSize = true;
            this.PluginHostStatus.Location = new System.Drawing.Point(114, 199);
            this.PluginHostStatus.Name = "PluginHostStatus";
            this.PluginHostStatus.Size = new System.Drawing.Size(35, 13);
            this.PluginHostStatus.TabIndex = 17;
            this.PluginHostStatus.Text = "label8";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Loaded plugins:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 446);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PluginHostStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PluginList);
            this.Controls.Add(this.DataGameName);
            this.Controls.Add(this.DataTableFilename);
            this.Controls.Add(this.DataHostingApplication);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DataTableElementType);
            this.Controls.Add(this.DataValue);
            this.Controls.Add(this.DataNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.PluginFinish);
            this.Controls.Add(this.PluginInit);
            this.Name = "Form1";
            this.Text = "Plugin Host Tester";
            ((System.ComponentModel.ISupportInitialize)(this.PluginList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PluginInit;
        private System.Windows.Forms.Button PluginFinish;
        private System.Windows.Forms.TextBox DataNumber;
        private System.Windows.Forms.TextBox DataValue;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DataTableElementType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DataHostingApplication;
        private System.Windows.Forms.TextBox DataTableFilename;
        private System.Windows.Forms.TextBox DataGameName;
        private System.Windows.Forms.DataGridView PluginList;
        private System.Windows.Forms.DataGridViewTextBoxColumn PluginListName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PluginListStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PluginListLastException;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label PluginHostStatus;
        private System.Windows.Forms.Label label8;
    }
}

