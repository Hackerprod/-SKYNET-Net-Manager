using System;
using System.Diagnostics;
using System.IO;

public static class CMDHelper
{
    private static Process proc = null;

    public static void Execute(string cmd)
    {
        proc = new Process();
        proc.StartInfo.CreateNoWindow = true;
        proc.StartInfo.FileName = "cmd.exe";
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardInput = true;
        proc.StartInfo.RedirectStandardOutput = true;
        proc.StartInfo.RedirectStandardError = true;

        // proc.OutputDataReceived += new DataReceivedEventHandler(sortProcess_OutputDataReceived);
        proc.Start();
        StreamWriter cmdWriter = proc.StandardInput;
        proc.BeginOutputReadLine();
        if (!String.IsNullOrEmpty(cmd))
        {
            cmdWriter.WriteLine(cmd);
        }
        cmdWriter.Close();
        proc.Close();
    }


    private static void sortProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (!String.IsNullOrEmpty(e.Data))
        {
            //this.BeginInvoke(new Action(() => { this.listBox1.Items.Add(e.Data); }));
        }
    }
}
