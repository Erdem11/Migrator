namespace Migrator.UI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lstSolution = new System.Windows.Forms.ListBox();
            this.lstContext = new System.Windows.Forms.ListBox();
            this.lstMigration = new System.Windows.Forms.ListBox();
            this.txtMigration = new System.Windows.Forms.TextBox();
            this.btnAddMigration = new System.Windows.Forms.Button();
            this.btnUpdateDatabase = new System.Windows.Forms.Button();
            this.btnRemoveMigration = new System.Windows.Forms.Button();
            this.btnAddSolution = new System.Windows.Forms.Button();
            this.btnRemoveSolution = new System.Windows.Forms.Button();
            this.btnRemoveContext = new System.Windows.Forms.Button();
            this.btnRefreshContext = new System.Windows.Forms.Button();
            this.btnRefreshMigration = new System.Windows.Forms.Button();
            this.btnSelectStartup = new System.Windows.Forms.Button();
            this.txtOut = new System.Windows.Forms.TextBox();
            this.lstTask = new System.Windows.Forms.ListBox();
            this.txtTask = new System.Windows.Forms.TextBox();
            this.btnTerminate = new System.Windows.Forms.Button();
            this.btnRemoveMigrationDb = new System.Windows.Forms.Button();
            this.btnAddMigrationDb = new System.Windows.Forms.Button();
            this.btnRegenerateMigrationDb = new System.Windows.Forms.Button();
            this.btnRegenerateMigration = new System.Windows.Forms.Button();
            this.picTopMost = new System.Windows.Forms.PictureBox();
            this.ntf = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnHide = new System.Windows.Forms.Button();
            this.btnSelectMigrationFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picTopMost)).BeginInit();
            this.SuspendLayout();
            // 
            // lstSolution
            // 
            this.lstSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSolution.FormattingEnabled = true;
            this.lstSolution.ItemHeight = 16;
            this.lstSolution.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.lstSolution.Location = new System.Drawing.Point(12, 96);
            this.lstSolution.Name = "lstSolution";
            this.lstSolution.Size = new System.Drawing.Size(141, 196);
            this.lstSolution.TabIndex = 0;
            this.lstSolution.SelectedIndexChanged += new System.EventHandler(this.lstSolution_SelectedIndexChanged);
            this.lstSolution.DoubleClick += new System.EventHandler(this.lstSolution_DoubleClick);
            // 
            // lstContext
            // 
            this.lstContext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstContext.FormattingEnabled = true;
            this.lstContext.ItemHeight = 16;
            this.lstContext.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.lstContext.Location = new System.Drawing.Point(12, 356);
            this.lstContext.Name = "lstContext";
            this.lstContext.Size = new System.Drawing.Size(141, 84);
            this.lstContext.TabIndex = 1;
            this.lstContext.SelectedIndexChanged += new System.EventHandler(this.lstContext_SelectedIndexChanged);
            // 
            // lstMigration
            // 
            this.lstMigration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMigration.FormattingEnabled = true;
            this.lstMigration.ItemHeight = 16;
            this.lstMigration.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.lstMigration.Location = new System.Drawing.Point(159, 96);
            this.lstMigration.Name = "lstMigration";
            this.lstMigration.Size = new System.Drawing.Size(330, 308);
            this.lstMigration.TabIndex = 2;
            this.lstMigration.SelectedIndexChanged += new System.EventHandler(this.lstMigration_SelectedIndexChanged);
            // 
            // txtMigration
            // 
            this.txtMigration.Location = new System.Drawing.Point(159, 12);
            this.txtMigration.Name = "txtMigration";
            this.txtMigration.Size = new System.Drawing.Size(286, 20);
            this.txtMigration.TabIndex = 3;
            // 
            // btnAddMigration
            // 
            this.btnAddMigration.Location = new System.Drawing.Point(159, 38);
            this.btnAddMigration.Name = "btnAddMigration";
            this.btnAddMigration.Size = new System.Drawing.Size(118, 23);
            this.btnAddMigration.TabIndex = 4;
            this.btnAddMigration.Text = "Add Migration";
            this.btnAddMigration.UseVisualStyleBackColor = true;
            this.btnAddMigration.Click += new System.EventHandler(this.btnAddMigration_Click);
            // 
            // btnUpdateDatabase
            // 
            this.btnUpdateDatabase.Location = new System.Drawing.Point(159, 67);
            this.btnUpdateDatabase.Name = "btnUpdateDatabase";
            this.btnUpdateDatabase.Size = new System.Drawing.Size(162, 23);
            this.btnUpdateDatabase.TabIndex = 5;
            this.btnUpdateDatabase.Text = "Update Database";
            this.btnUpdateDatabase.UseVisualStyleBackColor = true;
            this.btnUpdateDatabase.Click += new System.EventHandler(this.btnUpdateDatabase_Click);
            // 
            // btnRemoveMigration
            // 
            this.btnRemoveMigration.Location = new System.Drawing.Point(327, 67);
            this.btnRemoveMigration.Name = "btnRemoveMigration";
            this.btnRemoveMigration.Size = new System.Drawing.Size(118, 23);
            this.btnRemoveMigration.TabIndex = 6;
            this.btnRemoveMigration.Text = "Remove Migration";
            this.btnRemoveMigration.UseVisualStyleBackColor = true;
            this.btnRemoveMigration.Click += new System.EventHandler(this.btnRemoveMigration_Click);
            // 
            // btnAddSolution
            // 
            this.btnAddSolution.Location = new System.Drawing.Point(27, 10);
            this.btnAddSolution.Name = "btnAddSolution";
            this.btnAddSolution.Size = new System.Drawing.Size(126, 23);
            this.btnAddSolution.TabIndex = 7;
            this.btnAddSolution.Text = "Add Solution";
            this.btnAddSolution.UseVisualStyleBackColor = true;
            this.btnAddSolution.Click += new System.EventHandler(this.btnAddSolution_Click);
            // 
            // btnRemoveSolution
            // 
            this.btnRemoveSolution.Location = new System.Drawing.Point(12, 39);
            this.btnRemoveSolution.Name = "btnRemoveSolution";
            this.btnRemoveSolution.Size = new System.Drawing.Size(141, 23);
            this.btnRemoveSolution.TabIndex = 9;
            this.btnRemoveSolution.Text = "Remove Solution";
            this.btnRemoveSolution.UseVisualStyleBackColor = true;
            this.btnRemoveSolution.Click += new System.EventHandler(this.btnRemoveSolution_Click);
            // 
            // btnRemoveContext
            // 
            this.btnRemoveContext.Location = new System.Drawing.Point(12, 327);
            this.btnRemoveContext.Name = "btnRemoveContext";
            this.btnRemoveContext.Size = new System.Drawing.Size(141, 23);
            this.btnRemoveContext.TabIndex = 10;
            this.btnRemoveContext.Text = "Remove Context";
            this.btnRemoveContext.UseVisualStyleBackColor = true;
            this.btnRemoveContext.Click += new System.EventHandler(this.btnRemoveContext_Click);
            // 
            // btnRefreshContext
            // 
            this.btnRefreshContext.Location = new System.Drawing.Point(12, 298);
            this.btnRefreshContext.Name = "btnRefreshContext";
            this.btnRefreshContext.Size = new System.Drawing.Size(141, 23);
            this.btnRefreshContext.TabIndex = 11;
            this.btnRefreshContext.Text = "Refresh Contexts";
            this.btnRefreshContext.UseVisualStyleBackColor = true;
            this.btnRefreshContext.Click += new System.EventHandler(this.btnRefreshContext_Click);
            // 
            // btnRefreshMigration
            // 
            this.btnRefreshMigration.Location = new System.Drawing.Point(159, 410);
            this.btnRefreshMigration.Name = "btnRefreshMigration";
            this.btnRefreshMigration.Size = new System.Drawing.Size(162, 23);
            this.btnRefreshMigration.TabIndex = 12;
            this.btnRefreshMigration.Text = "Refresh Migrations";
            this.btnRefreshMigration.UseVisualStyleBackColor = true;
            this.btnRefreshMigration.Click += new System.EventHandler(this.btnRefreshMigration_Click);
            // 
            // btnSelectStartup
            // 
            this.btnSelectStartup.Location = new System.Drawing.Point(12, 67);
            this.btnSelectStartup.Name = "btnSelectStartup";
            this.btnSelectStartup.Size = new System.Drawing.Size(141, 23);
            this.btnSelectStartup.TabIndex = 13;
            this.btnSelectStartup.Text = "Select Startup Project";
            this.btnSelectStartup.UseVisualStyleBackColor = true;
            this.btnSelectStartup.Click += new System.EventHandler(this.btnSelectStartup_Click);
            // 
            // txtOut
            // 
            this.txtOut.BackColor = System.Drawing.Color.Black;
            this.txtOut.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOut.ForeColor = System.Drawing.Color.White;
            this.txtOut.Location = new System.Drawing.Point(12, 533);
            this.txtOut.Multiline = true;
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(477, 356);
            this.txtOut.TabIndex = 14;
            // 
            // lstTask
            // 
            this.lstTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTask.FormattingEnabled = true;
            this.lstTask.ItemHeight = 12;
            this.lstTask.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.lstTask.Location = new System.Drawing.Point(12, 463);
            this.lstTask.Name = "lstTask";
            this.lstTask.Size = new System.Drawing.Size(141, 64);
            this.lstTask.TabIndex = 16;
            // 
            // txtTask
            // 
            this.txtTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTask.Location = new System.Drawing.Point(12, 463);
            this.txtTask.Multiline = true;
            this.txtTask.Name = "txtTask";
            this.txtTask.ReadOnly = true;
            this.txtTask.Size = new System.Drawing.Size(477, 64);
            this.txtTask.TabIndex = 17;
            // 
            // btnTerminate
            // 
            this.btnTerminate.Location = new System.Drawing.Point(327, 410);
            this.btnTerminate.Name = "btnTerminate";
            this.btnTerminate.Size = new System.Drawing.Size(159, 23);
            this.btnTerminate.TabIndex = 18;
            this.btnTerminate.Text = "Terminate";
            this.btnTerminate.UseVisualStyleBackColor = true;
            this.btnTerminate.Click += new System.EventHandler(this.btnTerminate_Click);
            // 
            // btnRemoveMigrationDb
            // 
            this.btnRemoveMigrationDb.Location = new System.Drawing.Point(451, 67);
            this.btnRemoveMigrationDb.Name = "btnRemoveMigrationDb";
            this.btnRemoveMigrationDb.Size = new System.Drawing.Size(38, 23);
            this.btnRemoveMigrationDb.TabIndex = 19;
            this.btnRemoveMigrationDb.Text = "DB Remove Migration";
            this.btnRemoveMigrationDb.UseVisualStyleBackColor = true;
            this.btnRemoveMigrationDb.Click += new System.EventHandler(this.btnRemoveMigrationDb_Click);
            // 
            // btnAddMigrationDb
            // 
            this.btnAddMigrationDb.Location = new System.Drawing.Point(283, 39);
            this.btnAddMigrationDb.Name = "btnAddMigrationDb";
            this.btnAddMigrationDb.Size = new System.Drawing.Size(38, 23);
            this.btnAddMigrationDb.TabIndex = 20;
            this.btnAddMigrationDb.Text = "DB Add Migration";
            this.btnAddMigrationDb.UseVisualStyleBackColor = true;
            this.btnAddMigrationDb.Click += new System.EventHandler(this.btnAddMigrationDb_Click);
            // 
            // btnRegenerateMigrationDb
            // 
            this.btnRegenerateMigrationDb.Location = new System.Drawing.Point(451, 39);
            this.btnRegenerateMigrationDb.Name = "btnRegenerateMigrationDb";
            this.btnRegenerateMigrationDb.Size = new System.Drawing.Size(38, 23);
            this.btnRegenerateMigrationDb.TabIndex = 22;
            this.btnRegenerateMigrationDb.Text = "DB Regenerate Migration";
            this.btnRegenerateMigrationDb.UseVisualStyleBackColor = true;
            this.btnRegenerateMigrationDb.Click += new System.EventHandler(this.btnRegenerateMigrationDb_Click);
            // 
            // btnRegenerateMigration
            // 
            this.btnRegenerateMigration.Location = new System.Drawing.Point(327, 38);
            this.btnRegenerateMigration.Name = "btnRegenerateMigration";
            this.btnRegenerateMigration.Size = new System.Drawing.Size(118, 23);
            this.btnRegenerateMigration.TabIndex = 21;
            this.btnRegenerateMigration.Text = "Regenerate Migration";
            this.btnRegenerateMigration.UseVisualStyleBackColor = true;
            this.btnRegenerateMigration.Click += new System.EventHandler(this.btnRegenerateMigration_Click);
            // 
            // picTopMost
            // 
            this.picTopMost.BackColor = System.Drawing.Color.Green;
            this.picTopMost.Location = new System.Drawing.Point(0, -1);
            this.picTopMost.Name = "picTopMost";
            this.picTopMost.Size = new System.Drawing.Size(27, 40);
            this.picTopMost.TabIndex = 23;
            this.picTopMost.TabStop = false;
            this.picTopMost.Click += new System.EventHandler(this.picTopMost_Click);
            // 
            // ntf
            // 
            this.ntf.Icon = ((System.Drawing.Icon)(resources.GetObject("ntf.Icon")));
            this.ntf.Text = "Migrator";
            this.ntf.Visible = true;
            this.ntf.Click += new System.EventHandler(this.ntf_Click);
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(451, 10);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(38, 23);
            this.btnHide.TabIndex = 24;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnSelectMigrationFolder
            // 
            this.btnSelectMigrationFolder.Location = new System.Drawing.Point(12, 446);
            this.btnSelectMigrationFolder.Name = "btnSelectMigrationFolder";
            this.btnSelectMigrationFolder.Size = new System.Drawing.Size(141, 23);
            this.btnSelectMigrationFolder.TabIndex = 25;
            this.btnSelectMigrationFolder.Text = "Select Migration Folder";
            this.btnSelectMigrationFolder.UseVisualStyleBackColor = true;
            this.btnSelectMigrationFolder.Click += new System.EventHandler(this.btnSelectMigrationFolder_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 901);
            this.Controls.Add(this.btnSelectMigrationFolder);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.btnRegenerateMigrationDb);
            this.Controls.Add(this.btnRegenerateMigration);
            this.Controls.Add(this.btnAddMigrationDb);
            this.Controls.Add(this.btnRemoveMigrationDb);
            this.Controls.Add(this.btnTerminate);
            this.Controls.Add(this.txtTask);
            this.Controls.Add(this.lstTask);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.btnSelectStartup);
            this.Controls.Add(this.btnRefreshMigration);
            this.Controls.Add(this.btnRefreshContext);
            this.Controls.Add(this.btnRemoveContext);
            this.Controls.Add(this.btnRemoveSolution);
            this.Controls.Add(this.btnAddSolution);
            this.Controls.Add(this.btnRemoveMigration);
            this.Controls.Add(this.btnUpdateDatabase);
            this.Controls.Add(this.btnAddMigration);
            this.Controls.Add(this.txtMigration);
            this.Controls.Add(this.lstMigration);
            this.Controls.Add(this.lstContext);
            this.Controls.Add(this.lstSolution);
            this.Controls.Add(this.picTopMost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Migrator";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTopMost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSolution;
        private System.Windows.Forms.ListBox lstContext;
        private System.Windows.Forms.ListBox lstMigration;
        private System.Windows.Forms.TextBox txtMigration;
        private System.Windows.Forms.Button btnAddMigration;
        private System.Windows.Forms.Button btnUpdateDatabase;
        private System.Windows.Forms.Button btnRemoveMigration;
        private System.Windows.Forms.Button btnAddSolution;
        private System.Windows.Forms.Button btnRemoveSolution;
        private System.Windows.Forms.Button btnRemoveContext;
        private System.Windows.Forms.Button btnRefreshContext;
        private System.Windows.Forms.Button btnRefreshMigration;
        private System.Windows.Forms.Button btnSelectStartup;
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.ListBox lstTask;
        private System.Windows.Forms.TextBox txtTask;
        private System.Windows.Forms.Button btnTerminate;
        private System.Windows.Forms.Button btnRemoveMigrationDb;
        private System.Windows.Forms.Button btnAddMigrationDb;
        private System.Windows.Forms.Button btnRegenerateMigrationDb;
        private System.Windows.Forms.Button btnRegenerateMigration;
        private System.Windows.Forms.PictureBox picTopMost;
        private System.Windows.Forms.NotifyIcon ntf;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnSelectMigrationFolder;
    }
}

