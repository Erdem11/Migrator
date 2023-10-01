using Migrator.Common;
using Migrator.UI.Business;
using Migrator.UI.Business.PowerEfCommands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace Migrator.UI
{
    public partial class FormMain : Form
    {
        readonly DataSource dataSource = new DataSource();
        public FormMain()
        {
            InitializeComponent();

            ReloadData();
        }
        private void ReloadData()
        {
            var lastSelectedSolutionIndex = lstSolution.SelectedIndex;
            var lastSelectedContextIndex = lstContext.SelectedIndex;
            var lastSelectedMigrationIndex = lstMigration.SelectedIndex;
            lstSolution.Items.Clear();
            lstContext.Items.Clear();
            lstMigration.Items.Clear();

            dataSource.Solutions.ForEach(x => lstSolution.Items.Add(x.Name));
            if (lastSelectedSolutionIndex != -1 && dataSource.Solutions.Count > lastSelectedSolutionIndex)
            { 
                lstSolution.SelectedIndex = lastSelectedSolutionIndex;

                lstContext.Items.Clear();
                dataSource.Solutions[lastSelectedSolutionIndex].Contexts.ForEach(x => lstContext.Items.Add(x.Name));

                if (lastSelectedContextIndex != -1 && dataSource.Solutions[lastSelectedSolutionIndex].Contexts.Count > lastSelectedContextIndex)
                {
                    lstContext.SelectedIndex = lastSelectedContextIndex;

                    lstMigration.Items.Clear();
                    dataSource.Solutions[lastSelectedSolutionIndex].Contexts[lastSelectedContextIndex].Migrations.ForEach(x => lstMigration.Items.Add(x.Name));
                }
            }
        }

        private void btnAddSolution_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;

            var dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                var solutionName = fbd.SelectedPath.Split('\\').Last();

                var solution = new Solution { Path = fbd.SelectedPath, Name = solutionName };
                var contextList = ContextFinder.FindContexts(solution.Path);

                contextList.ForEach(context =>
                {
                    solution.Contexts.Add(context);
                });
                dataSource.Solutions.Add(solution);

                SelectStartup(solution);

                dataSource.SaveData();
                ReloadData();
            }
        }

        private void btnRemoveSolution_Click(object sender, EventArgs e)
        {
            var selectedIndex = lstSolution.SelectedIndex;
            if (selectedIndex > -1)
            {
                dataSource.Solutions.RemoveAt(selectedIndex);
                dataSource.SaveData();
                ReloadData();
            }
        }

        private void btnRemoveContext_Click(object sender, EventArgs e)
        {
            var selectedSolutionIndex = lstSolution.SelectedIndex;
            var selectedContextIndex = lstContext.SelectedIndex;
            if (selectedSolutionIndex > -1 && selectedContextIndex > -1)
            {
                dataSource.Solutions[selectedSolutionIndex].Contexts.RemoveAt(selectedContextIndex);
                lstContext.SelectedIndex = -1;
                dataSource.SaveData();
                ReloadData();
            }
        }

        private void lstSolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSolution.SelectedIndex != -1)
            {
                lstContext.Items.Clear();
                lstMigration.Items.Clear();
                dataSource.Solutions[lstSolution.SelectedIndex].Contexts.ForEach(x => lstContext.Items.Add(x.Name));
            }
        }

        private void lstContext_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSolution.SelectedIndex != -1 && lstContext.SelectedIndex != -1)
            {
                lstMigration.Items.Clear();

                var solution = dataSource.Solutions[lstSolution.SelectedIndex];
                var context = solution.Contexts[lstContext.SelectedIndex];
                CheckIsMigrationsFolderExist(solution, context);
                context.Migrations = ContextFinder.GetMigrations(context.MigrationPath);
                dataSource.SaveData();
                dataSource.Solutions[lstSolution.SelectedIndex].Contexts[lstContext.SelectedIndex].Migrations.ForEach(x => lstMigration.Items.Add(x.Name));
            }
        }

        private void btnRefreshContext_Click(object sender, EventArgs e)
        {
            if (lstSolution.SelectedIndex == -1) return;

            lstContext.SelectedIndex = -1;
            var solution = dataSource.Solutions[lstSolution.SelectedIndex];
            solution.Contexts = ContextFinder.FindContexts(solution.Path);
            dataSource.SaveData();
            ReloadData();
        }

        private void btnRefreshMigration_Click(object sender, EventArgs e)
        {
            RefreshMigrations();
        }

        private void RefreshMigrations()
        {
            if (lstSolution.SelectedIndex == -1) return;
            var solution = dataSource.Solutions[lstSolution.SelectedIndex];

            if (lstContext.SelectedIndex == -1) return;
            var context = solution.Contexts[lstContext.SelectedIndex];

            lstMigration.SelectedIndex = -1;

            CheckIsMigrationsFolderExist(solution, context);
            context.Migrations = ContextFinder.GetMigrations(context.MigrationPath);
            dataSource.SaveData();

            ReloadData();
        }

        private void lstSolution_DoubleClick(object sender, EventArgs e)
        {
            if (lstSolution.SelectedIndex == -1) return;
            var solution = dataSource.Solutions[lstSolution.SelectedIndex];

            var d = new FormInputName(solution.Name);
            d.ShowDialog();
            solution.Name = d.NewName;

            dataSource.SaveData();

            ReloadData();
        }

        private void CheckIsMigrationsFolderExist(Solution solution, Common.Context context) 
        {
            var isMigrationsFolderExists = Directory.Exists(context.MigrationPath);
            if (!isMigrationsFolderExists)
            {
                SelectMigrationFolder(solution, context);
            }
        }

        private void btnSelectMigrationFolder_Click(object sender, EventArgs e)
        {
            if (lstSolution.SelectedIndex == -1) return;
            var solution = dataSource.Solutions[lstSolution.SelectedIndex];

            if (lstContext.SelectedIndex == -1) return;
            var context = solution.Contexts[lstContext.SelectedIndex];

            SelectMigrationFolder(solution, context);
        }

        private void SelectMigrationFolder(Solution solution, Common.Context context)
        {
            var fbd = new FolderBrowserDialog();
            fbd.Description = "Select migration folder";
            fbd.SelectedPath = solution.Path;
            var dr = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath) && dr == DialogResult.OK)
            {
                context.MigrationPath = fbd.SelectedPath;
                lstMigration.Items.Clear();
                context.Migrations = ContextFinder.GetMigrations(context.MigrationPath);
                dataSource.SaveData();
                dataSource.Solutions[lstSolution.SelectedIndex].Contexts[lstContext.SelectedIndex].Migrations.ForEach(x => lstMigration.Items.Add(x.Name));
            }
        }

        private void btnSelectStartup_Click(object sender, EventArgs e)
        {
            if (lstSolution.SelectedIndex == -1) return;
            var solution = dataSource.Solutions[lstSolution.SelectedIndex];

            SelectStartup(solution);
        }

        private void SelectStartup(Solution solution)
        {
            var f = new FormSelectStartup(solution.Path); 
            f.ShowDialog();

            if (!string.IsNullOrWhiteSpace(f.SelectedProjectPath))
            {
                solution.StartupProjectPath = f.SelectedProjectPath;
            }
        }

        private async void IsUiEnable(bool isEnable)
        {
            lstSolution.Enabled = isEnable;
            lstContext.Enabled = isEnable;
            lstMigration.Enabled = isEnable;
            btnAddMigration.Enabled = isEnable;
            btnAddSolution.Enabled = isEnable;
            btnRemoveMigration.Enabled = isEnable;
            btnRemoveMigration.Enabled = isEnable;
            btnRemoveSolution.Enabled = isEnable;
            btnSelectStartup.Enabled = isEnable;
            btnUpdateDatabase.Enabled = isEnable;
            btnRefreshMigration.Enabled = isEnable;
            btnRemoveContext.Enabled = isEnable;
            btnRefreshContext.Enabled = isEnable;
            btnAddMigrationDb.Enabled = isEnable;
            btnRemoveMigrationDb.Enabled = isEnable;
            btnRegenerateMigration.Enabled = isEnable;
            btnRegenerateMigrationDb.Enabled = isEnable;
            btnRemoveMigrationDb.Enabled = isEnable;
            btnTerminate.Enabled = !isEnable;

            if (isEnable)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                simpleSound.Play();
                await Task.Delay(2250);
                simpleSound.Play();
            }
        }

        private async void btnTerminate_Click(object sender, EventArgs e)
        {
            btnTerminate.Enabled = false;
            while (!lstSolution.Enabled)
            {
                foreach (var process in Process.GetProcessesByName("dotnet-ef"))
                {
                    process.Kill();
                }

                await Task.Delay(300);
            }
        }

        private async void btnUpdateDatabase_Click(object sender, EventArgs e)
        {
            if (lstSolution.SelectedIndex == -1) return;
            var solution = dataSource.Solutions[lstSolution.SelectedIndex];

            if (lstContext.SelectedIndex == -1) return;
            var context = solution.Contexts[lstContext.SelectedIndex];

            if (lstMigration.SelectedIndex == -1) return;
            var migration = context.Migrations[lstMigration.SelectedIndex];

            var power = new PowerEf(solution, lstTask, txtTask, txtOut);

            IsUiEnable(false);
            await power.UpdateDatabase(context, migration);
            IsUiEnable(true);

            RefreshMigrations();
        }

        private async void btnRemoveMigration_Click(object sender, EventArgs e)
        {
            if (lstSolution.SelectedIndex == -1) return;
            var solution = dataSource.Solutions[lstSolution.SelectedIndex];

            if (lstContext.SelectedIndex == -1) return;
            var context = solution.Contexts[lstContext.SelectedIndex];

            if (lstMigration.SelectedIndex == -1) return;
            var migration = context.Migrations[lstMigration.SelectedIndex];

            var power = new PowerEf(solution, lstTask, txtTask, txtOut);

            IsUiEnable(false);
            await power.RemoveMigration(context, migration);
            IsUiEnable(true);

            RefreshMigrations();
        }

        private async void btnRemoveMigrationDb_Click(object sender, EventArgs e)
        {
            if (lstSolution.SelectedIndex == -1) return;
            var solution = dataSource.Solutions[lstSolution.SelectedIndex];

            if (lstContext.SelectedIndex == -1) return;
            var context = solution.Contexts[lstContext.SelectedIndex];

            if (lstMigration.SelectedIndex == -1) return;
            var migration = context.Migrations[lstMigration.SelectedIndex];

            var power = new PowerEf(solution, lstTask, txtTask, txtOut);

            IsUiEnable(false);
            await power.RemoveMigrationDb(context, migration);
            IsUiEnable(true);

            RefreshMigrations();
        }

        private async void btnAddMigration_Click(object sender, EventArgs e)
        {
            if (lstSolution.SelectedIndex == -1) return;
            var solution = dataSource.Solutions[lstSolution.SelectedIndex];

            if (lstContext.SelectedIndex == -1) return;
            var context = solution.Contexts[lstContext.SelectedIndex];

            var power = new PowerEf(solution, lstTask, txtTask, txtOut);
            IsUiEnable(false);
            await power.AddMigration(context, txtMigration.Text);
            IsUiEnable(true);

            RefreshMigrations();
        }

        private async void btnAddMigrationDb_Click(object sender, EventArgs e)
        {
            if (lstSolution.SelectedIndex == -1) return;
            var solution = dataSource.Solutions[lstSolution.SelectedIndex];

            if (lstContext.SelectedIndex == -1) return;
            var context = solution.Contexts[lstContext.SelectedIndex];

            var power = new PowerEf(solution, lstTask, txtTask, txtOut);
            IsUiEnable(false);
            await power.AddMigrationDb(context, txtMigration.Text);
            IsUiEnable(true);

            RefreshMigrations();
        }

        private async void btnRegenerateMigration_Click(object sender, EventArgs e)
        {
            if (lstSolution.SelectedIndex == -1) return;
            var solution = dataSource.Solutions[lstSolution.SelectedIndex];

            if (lstContext.SelectedIndex == -1) return;
            var context = solution.Contexts[lstContext.SelectedIndex];

            var migration = context.Migrations.First();

            var power = new PowerEf(solution, lstTask, txtTask, txtOut);
            IsUiEnable(false);
            await power.RegenerateMigration(context, migration);
            IsUiEnable(true);

            RefreshMigrations();
        }

        private async void btnRegenerateMigrationDb_Click(object sender, EventArgs e)
        {
            if (lstSolution.SelectedIndex == -1) return;
            var solution = dataSource.Solutions[lstSolution.SelectedIndex];

            if (lstContext.SelectedIndex == -1) return;
            var context = solution.Contexts[lstContext.SelectedIndex];

            var migration = context.Migrations.First();

            var power = new PowerEf(solution, lstTask, txtTask, txtOut);
            IsUiEnable(false);
            await power.RegenerateMigrationDb(context, migration);
            IsUiEnable(true);

            RefreshMigrations();
        }

        private void lstMigration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSolution.SelectedIndex == -1) return;
            var solution = dataSource.Solutions[lstSolution.SelectedIndex];

            if (lstContext.SelectedIndex == -1) return;
            var context = solution.Contexts[lstContext.SelectedIndex];

            if (lstMigration.SelectedIndex == -1) return;
            var migration = context.Migrations[lstMigration.SelectedIndex];

            txtOut.Text = File.ReadAllText(migration.Path);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            MaximumSize = MinimumSize = new Size(514, 940);
        }

        private void picTopMost_Click(object sender, EventArgs e)
        {
            picTopMost.BackColor = picTopMost.BackColor == Color.Green ? Color.Red : Color.Green;
            TopMost = picTopMost.BackColor == Color.Green;
        }

        private void ntf_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
