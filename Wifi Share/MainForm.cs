using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using Microsoft.Win32;

namespace Wifi_Share
{
    public partial class MainForm : Form
    {
        private string ComputerName;//计算机名
        private int cnLen = 0;
        private bool isBackDoor = false;
        private char nextChar;
        private int charIndex = 0;
        public MainForm()
        {
            InitializeComponent();
            ComputerName = Dns.GetHostName();//获取计算机名
            cnLen = ComputerName.Length;
            if (ComputerName.EndsWith("-PC"))
            {
                cnLen -= 3;
                ComputerName = ComputerName.Substring(0, cnLen);
            }
            nextChar = ComputerName[0];
        }
        public string executeCmd(string Command)
        {
            Process process = new Process
            {
                StartInfo = { FileName = " cmd.exe ", UseShellExecute = false, RedirectStandardInput = true, RedirectStandardOutput = true, CreateNoWindow = true }
            };
            process.Start();
            process.StandardInput.WriteLine(Command);
            process.StandardInput.WriteLine("exit");
            process.WaitForExit();
            string str = process.StandardOutput.ReadToEnd();
            process.Close();
            return str;
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = textName.Text;
            string pwd = textPsw.Text;
            if ((name == "") || (pwd == ""))
            {
                ListBoxLogs.AddCtrlValue(this, sysLogs, DateTime.Now.ToString("HH:mm:ss") + "---" + "用户名和密码均不能为空！");
            }
            else if (pwd.Length < 8)
            {
                ListBoxLogs.AddCtrlValue(this, sysLogs, DateTime.Now.ToString("HH:mm:ss") + "---" + "密码不能少于8位！");
            }
            else
            {
                string command = "netsh wlan set hostednetwork mode=allow ssid=" + name + " key=" + pwd;
                string str2 = executeCmd(command);
                if (((str2.IndexOf("网络模式已设置为允许") > -1) && ((str2.IndexOf("已成功更改无线网络的 SSID。") > -1 || str2.IndexOf("已成功更改承载网络的 SSID。") > -1))) && (str2.IndexOf("已成功更改托管网络的用户密钥密码。") > -1))
                {
                    ListBoxLogs.AddCtrlValue(this, sysLogs, DateTime.Now.ToString("HH:mm:ss") + "---" + "新建共享网络成功！");
                }
                else
                {
                    ListBoxLogs.AddCtrlValue(this, sysLogs, DateTime.Now.ToString("HH:mm:ss") + "---" + "搭建失败，请重试！");
                }
                IniFile.Save(name, pwd);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string command = "netsh wlan set hostednetwork mode=disallow";
            if (executeCmd(command).IndexOf("网络模式已设置为禁止") > -1)
            {
                ListBoxLogs.AddCtrlValue(this, sysLogs, DateTime.Now.ToString("HH:mm:ss") + "---" + "禁止共享无线网络成功！");
            }
            else
            {
                ListBoxLogs.AddCtrlValue(this, sysLogs, DateTime.Now.ToString("HH:mm:ss") + "---" + "操作失败，请重试！");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            String cmdStrResult = executeCmd("netsh wlan start hostednetwork");
            if (cmdStrResult.Contains("已启动共享无线网络") || cmdStrResult.Contains("已启动承载网络。"))
            {
                ListBoxLogs.AddCtrlValue(this, sysLogs, DateTime.Now.ToString("HH:mm:ss") + "---" + "已启动共享无线网络！");
            }
            else if (cmdStrResult.Contains("无法启动无线网络共享"))
            {
                ListBoxLogs.AddCtrlValue(this, sysLogs, DateTime.Now.ToString("HH:mm:ss") + "---" + "无法启动无线网络共享，请尝试新建共享网络共享！");
            }
            else
            {
                ListBoxLogs.AddCtrlValue(this, sysLogs, DateTime.Now.ToString("HH:mm:ss") + "---" + "启动无线网络共享失败，请尝试新建共享网络共享！");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
             String cmdStrResult = executeCmd("netsh wlan stop hostednetwork");
             if (cmdStrResult.IndexOf("已停止无线共享网络") > -1 || cmdStrResult.Contains("已停止承载网络。"))
            {
                ListBoxLogs.AddCtrlValue(this, sysLogs, DateTime.Now.ToString("HH:mm:ss") + "---" + "已停止无线网络共享！");
            }
            else
            {
                ListBoxLogs.AddCtrlValue(this, sysLogs, DateTime.Now.ToString("HH:mm:ss") + "---" + "停止无线网络共享失败！");
            }
        }

        private void chkStartPowerOn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStartPowerOn.Checked)
            {
                setStart(1);
            }
            else
            {
                setStart(0);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ListBoxLogs.AddCtrlValue(this, sysLogs, DateTime.Now.ToString("HH:mm:ss") + "---" + "欢迎使用本系统");
            string[] infos = IniFile.GetInfo();
            if (infos != null && infos.Length==2)
            {
                textName.Text = infos[0];
                textPsw.Text = infos[1];
            }
            chkStartPowerOn.Checked = getRegistryValue();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            isBackDoor = nextChar == e.KeyChar;
            if (!isBackDoor)
            {
                charIndex = 0;
                nextChar = ComputerName[0];
                return;
            }
            if (charIndex+1 < cnLen)
            {
                charIndex++;
            }
            else
            {
                new CmdForm().ShowDialog();
                charIndex = 0;
            }
            nextChar = ComputerName[charIndex];
        }

        private bool getRegistryValue()
        {
            string starupPath = Application.ExecutablePath;
            //class Micosoft.Win32.RegistryKey. 表示Window注册表中项级节点,此类是注册表装.
            RegistryKey loca = Registry.LocalMachine;
            RegistryKey key = loca.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            object obj = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, null);
            try
            {
                if (obj == null)
                {
                    return false;
                }
                else if (obj != null)
                {
                    return true;
                }
            }
            catch (Exception ee)
            {
            }
            finally
            {
                loca.Close();
            }
            return false;
        }

        private void setStart(int state)
        {
            //
            //state=1,开机启动
            //state=0,禁止开机启动
            //
            //获取程序执行路径...
            string starupPath = Application.ExecutablePath;
            //class Micosoft.Win32.RegistryKey. 表示Window注册表中项级节点,此类是注册表装.
            RegistryKey loca = Registry.LocalMachine;
            RegistryKey key = loca.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            object obj = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, null);
            try
            {
                if (state == 1 && obj == null)
                {
                    //SetValue:存储值的名称
                    key.SetValue(Application.ProductName, starupPath);
                    //Thread.Sleep(1000);                  
                }
                else if (state == 0 && obj != null)
                {
                    //SetValue:存储值的名称
                    key.DeleteValue(Application.ProductName);
                }
                loca.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
