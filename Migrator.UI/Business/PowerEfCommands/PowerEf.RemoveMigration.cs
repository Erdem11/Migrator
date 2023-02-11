using Migrator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrator.UI.Business.PowerEfCommands
{
    internal partial class PowerEf
    {
        public async Task RemoveMigration(Context context, Migration migration)
        {
            OutReader.Text = "";

            var migrationIndex = context.Migrations.IndexOf(migration);
            var stopMigration = context.Migrations[migrationIndex + 1];

            var directoryCommand = $"cd \"{context.ProjectPath}\"";

            var commands = new List<string> { directoryCommand };

            for (int i = 0; i < migrationIndex + 1; i++)
            {
                commands.Add($"dotnet ef --startup-project \"{Solution.StartupProjectPath}\" migrations remove --context {context.Name}");
            }

            ClearTaskList();
            AddToTask("Update Database - " + migration.Name, string.Join(Environment.NewLine, commands));

            LstTask.SelectedIndexChanged += LstTask_SelectedIndexChanged;

            var cmd = Cmd(commands);

            while (!_isCompleted)
            {
                await Task.Delay(100);
            }
            LstTask.SelectedIndexChanged -= LstTask_SelectedIndexChanged;
        }

        public async Task RemoveMigrationDb(Context context, Migration migration)
        {
            OutReader.Text = "";

            var migrationIndex = context.Migrations.IndexOf(migration);
            var stopMigration = context.Migrations[migrationIndex + 1];

            var directoryCommand = $"cd \"{context.ProjectPath}\"";
            var command = $"dotnet ef --startup-project \"{Solution.StartupProjectPath}\" database update {stopMigration.FullName.Substring(0, stopMigration.FullName.Length - 3)} --context {context.Name}";

            var commands = new List<string> { directoryCommand, command };

            for (int i = 0; i < migrationIndex + 1; i++)
            {
                commands.Add($"dotnet ef --startup-project \"{Solution.StartupProjectPath}\" migrations remove --context {context.Name}");
            }

            ClearTaskList();
            AddToTask("Update Database - " + migration.Name, string.Join(Environment.NewLine, commands));

            LstTask.SelectedIndexChanged += LstTask_SelectedIndexChanged;

            var cmd = Cmd(commands);

            while (!_isCompleted)
            {
                await Task.Delay(100);
            }
            LstTask.SelectedIndexChanged -= LstTask_SelectedIndexChanged;
        }
    }
}
