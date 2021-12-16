using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

//using MyVideo;

public class Media
{
    private Timer timer1;

    public bool FileIsOpen;

    private string sCommand;

    private StringBuilder sBuffer = new StringBuilder(128);

    private bool m_Repeat;

    private bool m_Pause;

    private int seconds;

    public bool Pause
    {
        get
        {
            return m_Pause;
        }
        set
        {
            m_Pause = value;
            if (m_Pause)
            {
                sCommand = "pause MediaFile";
            }
            else
            {
                sCommand = "resume MediaFile";
            }
            mciSendString(sCommand, null, 0, IntPtr.Zero);
        }
    }

    public int Position
    {
        get
        {
            sCommand = "status MediaFile position";
            mciSendString(sCommand, sBuffer, sBuffer.Capacity, IntPtr.Zero);
            seconds = int.Parse(sBuffer.ToString());
            seconds /= 1000;
            return seconds;
        }
        set
        {
            seconds = value;
            seconds *= 1000;
            sCommand = "play MediaFile from " + seconds.ToString();
            mciSendString(sCommand, null, 0, IntPtr.Zero);
        }
    }

    public int Volume
    {
        get
        {
            if (Status() != "")
            {
                mciSendString("status MediaFile volume", sBuffer, sBuffer.Capacity, IntPtr.Zero);
                return int.Parse(sBuffer.ToString());
            }
            return 0;
        }
        set
        {
            if (value <= 1000)
            {
                mciSendString("setaudio MediaFile volume to " + value.ToString(), null, 0, IntPtr.Zero);
            }
            else
            {
                MessageBox.Show("Volume value must be smaller than 1000");
            }
        }
    }

    public bool Repeat
    {
        get
        {
            return m_Repeat;
        }
        set
        {
            m_Repeat = value;
        }
    }

    public event PositionEventHandler PositionChanged;

    [DllImport("winmm.dll")]
    private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

    [DllImport("Winmm.dll")]
    private static extern long PlaySound(byte[] data, IntPtr hMod, uint dwFlags);

    public Media()
    {
        timer1 = new Timer();
        timer1.Enabled = false;
        timer1.Interval = 100;
        timer1.Tick += timer1_Tick;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        PositionChangedEventArgs e2 = new PositionChangedEventArgs(Position);
        if (this.PositionChanged != null)
        {
            this.PositionChanged(this, e2);
        }
    }

    public void Close()
    {
        sCommand = "close MediaFile";
        mciSendString(sCommand, null, 0, IntPtr.Zero);
        timer1.Enabled = false;
        FileIsOpen = false;
    }

    public void Stop()
    {
        Position = 0;
        sCommand = "stop MediaFile";
        mciSendString(sCommand, null, 0, IntPtr.Zero);
        timer1.Enabled = false;
    }

    public void Open(string sFileName)
    {
        if (Status() == "playing")
        {
            Close();
        }
        sCommand = "open \"" + sFileName + "\" type mpegvideo alias MediaFile";
        mciSendString(sCommand, null, 0, IntPtr.Zero);
        FileIsOpen = true;
    }

    public void Open(string sFileName, PictureBox videobox)
    {
        if (Status() == "playing")
        {
            Close();
        }
        sCommand = "open \"" + sFileName + "\" type mpegvideo alias MediaFile style child parent " + videobox.Handle.ToInt32();
        mciSendString(sCommand, null, 0, IntPtr.Zero);
        sCommand = "put MediaFile window at 0 0 " + videobox.Width + " " + videobox.Height;
        mciSendString(sCommand, null, 0, IntPtr.Zero);
        FileIsOpen = true;
    }

    public void Play()
    {
        if (FileIsOpen)
        {
            sCommand = "play MediaFile";
            if (Repeat)
            {
                sCommand += " REPEAT";
            }
            mciSendString(sCommand, null, 0, IntPtr.Zero);
            timer1.Enabled = true;
        }
    }

    public void FullScreen()
    {
        sCommand = "play MediaFile FullScreen";
        mciSendString(sCommand, null, 0, IntPtr.Zero);
    }

    public int Duration()
    {
        sCommand = "status MediaFile length";
        mciSendString(sCommand, sBuffer, 128, IntPtr.Zero);
        int num = int.Parse(sBuffer.ToString());
        return num / 1000;
    }

    public string Status()
    {
        mciSendString("status MediaFile mode", sBuffer, sBuffer.Capacity, IntPtr.Zero);
        return sBuffer.ToString();
    }

    public string SecondsToTime(int seconds)
    {
        int num = seconds / 3600;
        int num2 = seconds / 60;
        num2 %= 60;
        seconds %= 60;
        return num.ToString("00") + ":" + num2.ToString("00") + ":" + seconds.ToString("00");
    }

    public void PlayWavResource(string wav)
    {
        string str = Assembly.GetExecutingAssembly().GetName().Name.ToString();
        Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(str + "." + wav);
        if (manifestResourceStream != null)
        {
            byte[] array = new byte[manifestResourceStream.Length];
            manifestResourceStream.Read(array, 0, (int)manifestResourceStream.Length);
            PlaySound(array, IntPtr.Zero, 5u);
        }
    }
}
public delegate void PositionEventHandler(object sender, PositionChangedEventArgs e);

public class PositionChangedEventArgs : EventArgs
{
    private int _position;

    public int newPosition => _position;

    public PositionChangedEventArgs(int num)
    {
        _position = num;
    }
}

