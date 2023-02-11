using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migrator.UI
{
    public partial class FormSelectStartup : Form
    {
        public string SelectedProjectPath { get; set; }
        private readonly string _solutionPath;
        public FormSelectStartup()
        {
            InitializeComponent();
        }
        public FormSelectStartup(string solutionPath)
        {
            _solutionPath = solutionPath;
            InitializeComponent();

            FindProjects(solutionPath);
        }

        private void FindProjects(string solutionPath)
        {
            var files = FindContexts(solutionPath);
            lstProject.Items.Clear();
            files.ForEach(x => lstProject.Items.Add(x.Substring(solutionPath.Length)));
        }

        public static List<string> FindContexts(string basePath)
        {
            var contexts = new List<string>();
            CheckCurrentDirectoryFiles(contexts, basePath);

            CheckDirectory(contexts, basePath);

            return contexts;
        }
        private static void CheckDirectory(List<string> contexts, string path)
        {

            var directories = Directory.GetDirectories(path);
            CheckCurrentDirectoryFiles(contexts, path);

            foreach (var directory in directories)
            {
                CheckDirectory(contexts, directory);
            }
        }

        private static void CheckCurrentDirectoryFiles(List<string> contexts, string path)
        {
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                if (file.EndsWith(".csproj"))
                {
                    var projectPath = Path.GetDirectoryName(file);
                    contexts.Add(projectPath);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstProject.SelectedIndex == -1) return;

            SelectedProjectPath = _solutionPath + lstProject.SelectedItems[0].ToString();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
