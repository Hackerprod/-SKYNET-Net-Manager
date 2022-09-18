using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using mshtml;
using Microsoft.VisualBasic.CompilerServices;
using System.IO;
using SKYNET.Types;

namespace SKYNET.GUI
{
    public partial class SKYNET_WebChat : UserControl
    {
        public SKYNET_WebChat()
        {
            InitializeComponent();

            InternetExplorerBrowserEmulation.SetBrowserEmulationVersion();

            webChat.Navigate("about:blank");

            while (webChat.Document == null || webChat.Document.Body == null)
                Application.DoEvents();

            StringBuilder HTTP = new StringBuilder();
            HTTP.AppendLine("<html><head></head>");
            HTTP.AppendLine($"<body bgcolor={ColorTranslator.ToHtml(Color.FromArgb(43, 54, 68))}>");
            HTTP.AppendLine("<main>");
            HTTP.AppendLine("<ul id='chat'>");

            webChat.Document.OpenNew(true).Write(HTTP.ToString());

            webChat.ScriptErrorsSuppressed = true;

            IHTMLStyleSheet2 instance = (IHTMLStyleSheet2)((IHTMLDocument2)webChat.Document.DomDocument).createStyleSheet("", 0);
            NewLateBinding.LateSet(instance, null, "cssText", new object[1] { GetMyCSS() }, null, null);
            HtmlElement htmlElement = webChat.Document.GetElementsByTagName("head")[0];
            HtmlElement htmlElement2 = webChat.Document.CreateElement("script");
            htmlElement.AppendChild(htmlElement2);

        }

        public void WriteChat(ChatMessage ChatMessage)
        {
            string message = GetMessageBody(ChatMessage);

            Common.InvokeAction(webChat, delegate
            {
                webChat.Document.Write(message);
                webChat.Document.Window.ScrollTo(0, webChat.Document.Body.ScrollRectangle.Height);
            });
        }

        public static string GetMessageBody(ChatMessage MessageContent)
        {
            StringBuilder HTTP = new StringBuilder();

            string imagePath = Path.Combine(Common.GetPath(), "Data", "Images", "Default.jpg");

            var deviceBox = DeviceManager.GetBoxFromIP(MessageContent.Addresses);
            if (deviceBox != null)
            {
                if (File.Exists(Path.Combine(Common.GetPath(), "Data", "Images", deviceBox.Device.Guid + ".jpg")))
                {
                    imagePath = Path.Combine(Common.GetPath(), "Data", "Images", deviceBox.Device.Guid + ".jpg");
                }
            }

            //if (MessageContent.Sender == Environment.UserName)
            {
                HTTP.AppendLine($"<li class='me'>");
                HTTP.AppendLine($"<div class='entete'>");
                HTTP.AppendLine($"<h2 class='Time'>{GetTime(MessageContent.Time)}</h2>");
                HTTP.AppendLine($"<h3 class='Sender'>{MessageContent.Sender}</h3>");
                HTTP.AppendLine($"</div>");
                HTTP.AppendLine($"<div class='triangle'></div>");
                HTTP.AppendLine($"<div class='message'>");
                HTTP.AppendLine($"{MessageContent.Message}");
                HTTP.AppendLine($"</div>");
                HTTP.AppendLine($"</li>");
            }
            //else
            {
                HTTP.AppendLine($"<li class='you'>");
                HTTP.AppendLine($"<div class='entete'>");
                HTTP.AppendLine($"<h3 class='Sender'>{MessageContent.Sender}</h3>");
                HTTP.AppendLine($"<h2 class='Time'>{GetTime(MessageContent.Time)}</h2>");
                HTTP.AppendLine($"</div>");
                HTTP.AppendLine($"<div class='triangle'></div>");
                HTTP.AppendLine($"<div class='message'>");
                HTTP.AppendLine($"{MessageContent.Message}");
                HTTP.AppendLine($"</div>");
                HTTP.AppendLine($"</li>");
            }
            HTTP.AppendLine("</br>");
            return HTTP.ToString();
        }

        private static string GetTime(DateTime dateTime)
        {
            string time = dateTime.ToString("hh:mm");

            if (int.TryParse(dateTime.ToString("HH"), out int hour))
            {
                if (hour >= 12)
                    time += " PM";
                else
                    time += " AM";
            }
            return time;
        }

        public static string GetMyCSS()
        {
            return @"

*{
	box-sizing:border-box;
}

body{
	background-color:#2B3644;
	font:12px 'Open Sans', sans-serif; 
}

main{
	width:100%;
	height:100%;
	display:inline-block;
	vertical-align:top;
}

.Time{
	font:10px 'Open Sans', sans-serif;
    color:#999999;
	display:inline-block;
	font-weight:normal;
}

.Sender{
	font:12px 'Open Sans', sans-serif;
    color:#fff;
	display:inline-block;
	font-weight:normal;
}

#chat{
	padding-left:0;
	margin:0;
	list-style-type:none;
	overflow-y:scroll;
	height:100%;
}
#chat li{
	padding:0px 100px 0px 0px;
}

#chat .message{
	padding:10px;
	color:#fff;
	line-height:25px;
	max-width:90%;
	display:inline-block;
	text-align:left;
	border-radius:5px;
    font:13px 'Open Sans', sans-serif; 
}
#chat .me{
	text-align:right;
}
#chat .you .message{
	background-color:#58b666;
}
#chat .me .message{
	background-color:#6fbced;
}
#chat .triangle{
	width: 0;
	height: 0;
	border-style: solid;
	border-width: 10px 8px 10px 8px;
}

#chat .you .triangle{
		border-color: transparent transparent #58b666 transparent;
		margin-left:15px;
        margin-top:-5px;
}
#chat .me .triangle{
		border-color: transparent transparent #6fbced transparent;
		margin-left:95%;
        margin-top:-5px;
}




            ";
        }

    }
}
