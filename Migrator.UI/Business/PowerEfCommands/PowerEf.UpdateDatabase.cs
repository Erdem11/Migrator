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
        public async Task UpdateDatabase(Context context, Migration migration)
        {
            OutReader.Text = "";

            var directoryCommand = $"cd \"{context.ProjectPath}\"";
            var command = $"dotnet ef --startup-project \"{Solution.StartupProjectPath}\" database update {migration.FullName.Substring(0, migration.FullName.Length - 3)} --context {context.Name}";

            var commands = new List<string> { directoryCommand, command };

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
