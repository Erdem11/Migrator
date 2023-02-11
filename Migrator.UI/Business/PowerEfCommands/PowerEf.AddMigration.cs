using Migrator.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migrator.UI.Business.PowerEfCommands
{
    internal partial class PowerEf
    {
        public async Task AddMigration(Context context, string migrationName)
        {
            OutReader.Text = "";

            var directoryCommand = $"cd \"{context.ProjectPath}\"";
            var command = $"dotnet ef --startup-project \"{Solution.StartupProjectPath}\" migrations add {migrationName} --context {context.Name}";

            var commands = new List<string> { directoryCommand, command };

            ClearTaskList();
            AddToTask("Add Migration - " + migrationName, string.Join(Environment.NewLine, commands));

            LstTask.SelectedIndexChanged += LstTask_SelectedIndexChanged;

            var cmd = Cmd(commands);

            while (!_isCompleted)
            {
                await Task.Delay(100);
            }
            LstTask.SelectedIndexChanged -= LstTask_SelectedIndexChanged;
        }

        public async Task AddMigrationDb(Context context, string migrationName)
        {
            OutReader.Text = "";

            var directoryCommand = $"cd \"{context.ProjectPath}\"";
            var command = $"dotnet ef --startup-project \"{Solution.StartupProjectPath}\" migrations add {migrationName} --context {context.Name}";

            var commands = new List<string> { directoryCommand, command };

            commands.Add($"dotnet ef --startup-project \"{ Solution.StartupProjectPath}\" database update --context {context.Name}");

            ClearTaskList();
            AddToTask("Add Migration - " + migrationName, string.Join(Environment.NewLine, commands));

            LstTask.SelectedIndexChanged += LstTask_SelectedIndexChanged;

            var cmd = Cmd(commands);

            while (!_isCompleted)
            {
                await Task.Delay(100);
            }
            LstTask.SelectedIndexChanged -= LstTask_SelectedIndexChanged;
        }

        private void LstTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LstTask.SelectedIndex == -1) return;

            TxtTaskDefinition.Text = taskDic[LstTask.Items[LstTask.SelectedIndex].ToString()];
        }
    }
}
