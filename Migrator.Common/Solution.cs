using System;
using System.Collections.Generic;
using System.Text;

namespace Migrator.Common
{
    public class Solution
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string StartupProjectPath { get; set; }
        public List<Context> Contexts { get; set; } = new List<Context>();
    }

    public class Context 
    {
        public string Name { get; set; }
        public string ContextPath { get; set; }
        public string ProjectPath { get; set; }
        public string MigrationPath { get; set; }
        public List<Migration> Migrations { get; set; } = new List<Migration>();
    }

    public class Migration 
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Path { get; set; }
    }
}
