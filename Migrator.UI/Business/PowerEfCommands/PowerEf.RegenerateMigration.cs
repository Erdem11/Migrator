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
        public async Task RegenerateMigration(Context context, Migration migration)
        {
            OutReader.Text = "";

            var directoryCommand = $"cd \"{context.ProjectPath}\"";
            var commands = new List<string> { directoryCommand };
            commands.Add($"dotnet ef --startup-project \"{Solution.StartupProjectPath}\" migrations remove --context {context.Name}");
            commands.Add($"dotnet ef --startup-project \"{Solution.StartupProjectPath}\" migrations add {migration.Name} --context {context.Name}");

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

        public async Task RegenerateMigrationDb(Context context, Migration migration)
        {
            OutReader.Text = "";

            var migrationIndex = context.Migrations.IndexOf(migration);
            var stopMigration = context.Migrations[migrationIndex + 1];

            var directoryCommand = $"cd \"{context.ProjectPath}\"";
            var commands = new List<string> { directoryCommand };
            commands.Add($"dotnet ef --startup-project \"{Solution.StartupProjectPath}\" database update {stopMigration.FullName.Substring(0, stopMigration.FullName.Length - 3)} --context {context.Name}");
            commands.Add($"dotnet ef --startup-project \"{Solution.StartupProjectPath}\" migrations remove --context {context.Name}");
            commands.Add($"dotnet ef --startup-project \"{Solution.StartupProjectPath}\" migrations add {migration.Name} --context {context.Name}");
            commands.Add($"dotnet ef --startup-project \"{Solution.StartupProjectPath}\" database update --context {context.Name}");

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
