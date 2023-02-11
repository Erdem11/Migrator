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
        public TextBox OutReader { get; set; }
        public Solution Solution { get; }
        public ListBox LstTask { get; }
        public TextBox TxtTaskDefinition { get; }

        public Dictionary<string, string> taskDic = new Dictionary<string, string>(); 

        private bool _isCompleted = false;
        private string _batFileName = Guid.NewGuid() + ".bat";


        public PowerEf(Solution solution, ListBox lstTask, TextBox txtTaskDefinition, TextBox txtTaskOutput)
        {
            Solution = solution;
            LstTask = lstTask;
            TxtTaskDefinition = txtTaskDefinition;
            OutReader = txtTaskOutput;
        }

        private void Cmd_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            OutReader.Invoke(new MethodInvoker(delegate
            {
                OutReader.Text += e.Data + Environment.NewLine;
                OutReader.SelectionStart = OutReader.TextLength;
                OutReader.ScrollToCaret();
            }));
            Console.WriteLine(e.Data);
        }

        private Process Cmd(List<string> commands)
        {
            using (StreamWriter batFile = new StreamWriter(_batFileName))
            {
                foreach (string command in commands)
                {
                    batFile.WriteLine(command);
                }
            }

            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/c " + _batFileName);
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.WindowStyle = ProcessWindowStyle.Normal;

            Process cmd = new Process();
            cmd.EnableRaisingEvents = true;
            cmd.StartInfo = processStartInfo;
            cmd.Start();

            cmd.OutputDataReceived += Cmd_OutputDataReceived;
            cmd.BeginOutputReadLine();
            cmd.BeginErrorReadLine();
            cmd.Exited += Cmd_Exited;

            return cmd;
        }

        private void Cmd_Exited(object sender, EventArgs e)
        {
            File.Delete(_batFileName);
            _isCompleted = true;
        }

        private void ClearTaskList()
        {
            taskDic.Clear();
            LstTask.Items.Clear();
        }
        private void AddToTask(string taskName, string taskDefinition)
        {
            taskDic.Add(taskName, taskDefinition);
            TxtTaskDefinition.Text = taskDefinition;
            LstTask.Items.Add(taskName);
        }
    }
}
