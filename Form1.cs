using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RightClickWinApps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            const string userroot = "HKEY_CURRENT_USER";
            const string classroot = "HKEY_CLASSES_ROOT";
            const string shellwild = classroot + "\\*\\shell";
            const string shelldir = classroot + "\\Directory\\shell";
            const string commandshort = "cmd.exe /c takeown /f \"%1\" && icacls \"%1\" /grant administrators:F";
            const string command = "cmd.exe /c takeown /f \"%1\" /r /d y && icacls \"%1\" /grant administrators:F /t";
            Registry.SetValue(shellwild+"\\runas", "","Take Ownership",RegistryValueKind.String);
            Registry.SetValue(shellwild + "\\runas", "NoWorkingDirectory", "", RegistryValueKind.String);
            Registry.SetValue(shellwild + "\\runas\\command", "", commandshort, RegistryValueKind.String);
            Registry.SetValue(shellwild + "\\runas\\command", "IsolatedCommand", commandshort, RegistryValueKind.String);
            Registry.SetValue(shelldir + "\\runas", "", "Take Ownership", RegistryValueKind.String);
            Registry.SetValue(shelldir + "\\runas", "NoWorkingDirectory", "", RegistryValueKind.String);
            Registry.SetValue(shelldir + "\\runas\\command", "", command, RegistryValueKind.String);
            Registry.SetValue(shelldir + "\\runas\\command", "IsolatedCommand", command, RegistryValueKind.String);
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registry.ClassesRoot.DeleteSubKeyTree("\\Directory\\shell\\runas");
            Registry.ClassesRoot.DeleteSubKeyTree("\\*\\shell\\runas");
        }
    }
}
