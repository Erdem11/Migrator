using Migrator.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Migrator.UI.Business
{
    internal static class ContextFinder
    {
        private const string ContextFilePostfix = "Context.cs";
        private const string MigrationsDirectoryName = "Migrations";
        private const string MigrationDateFormat = "yyyyMMddHHmmss";
        public static List<Context> FindContexts(string basePath)
        {
            var contexts = new List<Context>();
            CheckCurrentDirectoryFiles(contexts, basePath);

            CheckDirectory(contexts, basePath);

            return contexts;
        }

        private static void CheckDirectory(List<Context> contexts, string path)
        {

            var directories = Directory.GetDirectories(path);
            CheckCurrentDirectoryFiles(contexts, path);

            foreach (var directory in directories)
            {
                CheckDirectory(contexts, directory);
            }
        }

        private static void CheckCurrentDirectoryFiles(List<Context> contexts, string path)
        {
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                if (file.EndsWith(ContextFilePostfix))
                {
                    var projectPath = GetProjectPath(path);
                    var migrationPath = GetMigrationPath(path, projectPath);
                    var context = new Context
                    {
                        Name = file.Split('\\').Last().Split('.').First(),
                        ContextPath = file,
                        ProjectPath = projectPath,
                        MigrationPath = migrationPath,
                        Migrations = GetMigrations(migrationPath)
                    };
                    contexts.Add(context);
                }
            }
        }

        public static List<Migration> GetMigrations(string migrationPath)
        {
            var migrations = Directory.GetFiles(migrationPath).Select(IsMigrationFile).ToList();
            migrations.RemoveAll(x => x == null);

            migrations = migrations.OrderByDescending(x => x.FullName).ToList();

            return migrations;
        }

        private static Migration IsMigrationFile(string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            if (fileName.EndsWith(".Designer.cs")) return null;

            if (!fileName.EndsWith(".cs")) return null;

            var fileNameParts = fileName.Split('_');

            //20190529071410_Identitiy.ApplicationUserCountry.Designer
            //yyyyMMddHHmmss
            var isProperDate = DateTime.TryParseExact(fileNameParts[0], MigrationDateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _);
            if (!isProperDate) return null;

            var migrationName = Path.GetFileNameWithoutExtension(filePath).Split('.').Last();

            var isMigrationNameHasDatePart = migrationName.Length > MigrationDateFormat.Length && DateTime.TryParseExact(migrationName.Substring(0, MigrationDateFormat.Length), MigrationDateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _);
            migrationName = isMigrationNameHasDatePart ? migrationName.Substring(MigrationDateFormat.Length + 1) : migrationName;

            var migration = new Migration { FullName = fileName, Name = migrationName, Path = filePath };

            return migration;
        }

        private static string GetMigrationPath(string path, string projectPath)
        {
            var migrationsDirectory = SearchForMigrationsDirectory(path);
            if (migrationsDirectory == "")
            {
                migrationsDirectory = SearchForMigrationsDirectory(projectPath);
            }

            if (migrationsDirectory == "")
            {
                migrationsDirectory = Directory.CreateDirectory(Path.Combine(path, MigrationsDirectoryName)).FullName;
            }

            return migrationsDirectory;
        }

        private static string SearchForMigrationsDirectory(string path)
        {
            var directories = Directory.GetDirectories(path);

            foreach (var directory in directories)
            {
                if (directory.EndsWith(MigrationsDirectoryName))
                {
                    return directory;
                }

                SearchForMigrationsDirectory(directory);
            }

            return "";
        }

        private static string GetProjectPath(string path)
        {
            var files = Directory.GetFiles(path);
            var isProjectDirectory = files.Any(x => x.EndsWith(".csproj"));

            if (isProjectDirectory)
            {
                return path;
            }

            var parentPath = Directory.GetParent(path).FullName;
            return GetProjectPath(parentPath);
        }
    }
}
