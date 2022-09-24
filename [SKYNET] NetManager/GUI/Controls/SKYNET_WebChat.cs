using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using mshtml;
using Microsoft.VisualBasic.CompilerServices;
using System.IO;
using SKYNET.Types;
using System.Net;
using System.Linq;

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

            HTTP.AppendLine($"<div id='chat-messages'>");

            webChat.Document.OpenNew(true).Write(HTTP.ToString());

            webChat.ScriptErrorsSuppressed = true;

            IHTMLStyleSheet2 instance = (IHTMLStyleSheet2)((IHTMLDocument2)webChat.Document.DomDocument).createStyleSheet("", 0);
            NewLateBinding.LateSet(instance, null, "cssText", new object[1] { GetCSS() }, null, null);
            HtmlElement htmlElement = webChat.Document.GetElementsByTagName("head")[0];
            HtmlElement htmlElement2 = webChat.Document.CreateElement("script");
            IHTMLScriptElement iHTMLScriptElement = (IHTMLScriptElement)htmlElement2.DomElement;
            //iHTMLScriptElement.text = GetJS();
            htmlElement.AppendChild(htmlElement2);
        }

        public void WriteChat(ChatMessage ChatMessage, bool Me, bool Done = true)
        {
            string message = GetMessageBody(ChatMessage, Me, Done);

            Common.InvokeAction(webChat, delegate
            {
                webChat.Document.Write(message);
            });

            Common.InvokeAction(webChat, delegate
            {
                webChat.Document.Window.ScrollTo(0, webChat.Document.Body.ScrollRectangle.Height);
            });
        }

        public static string GetMessageBody(ChatMessage MessageContent, bool Me, bool Done = true)
        {
            StringBuilder HTTP = new StringBuilder();

            if (Me)
            {
                string fill = Done ? "#86C6FD" : "#ED827C";
                HTTP.AppendLine($"<div class='message right'>");
                HTTP.AppendLine($"<img src='http://127.0.0.1:28082/Avatar' />");
                HTTP.AppendLine($"<div class='bubble me'>");
                HTTP.AppendLine($"{MessageContent.Message}");
                HTTP.AppendLine($"<div class='corner'></div>");
                HTTP.AppendLine($"<p class='Time-me'>{GetTime(MessageContent.Time)}<p>");

                HTTP.AppendLine($"<svg class='check' xmlns='http://www.w3.org/2000/svg' viewBox='0 0 45 45' width='22' height='17'>");
                HTTP.AppendLine($"<path d='M14.7 35.9 3.5 24.7l2.15-2.15 9.05 9.05 2.15 2.15Zm8.5 0L12 24.7l2.15-2.15 9.05 9.05 19.2-19.2 2.15 2.15Zm0-8.5-2.15-2.15L33.9 12.4l2.15 2.15Z' fill='{fill}'/>");
                HTTP.AppendLine($"</svg>");

                HTTP.AppendLine($"</div>");
                HTTP.AppendLine($"</div>");
            }
            else
            {
                string url = "";
                if (MessageContent.Address != null)
                {
                    url = $"http://{MessageContent.Address}:28082/Avatar";
                }
                else
                {
                    url = $"http://127.0.0.1:28082/DefaultAvatar";
                }

                HTTP.AppendLine($"<div class='message'>");
                HTTP.AppendLine($"<img src='{url}'/>");
                HTTP.AppendLine($"<div class='bubble you'>");
                HTTP.AppendLine($"<h4 class='Sender'>{MessageContent.Sender}</h4>");
                HTTP.AppendLine($"{MessageContent.Message}");
                HTTP.AppendLine($"<h4 class='Time-you'>{GetTime(MessageContent.Time)}<h4>");
                HTTP.AppendLine($"<div class='corner'></div>");
                HTTP.AppendLine($"</div>");
                HTTP.AppendLine($"</div>");
            }



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

        public static string GetCSS()
        {
            return @"

body {
    background: #111A25;
    font:12px 'Open Sans', sans-serif; 

    scrollbar-face-color:#52a1f2;
    scrollbar-highligh-color:#1d2733;
    scrollbar-3dligh-color:#1d2733;
    scrollbar-darkshadow-color:#1d2733;
    scrollbar-shadow-color:#73b5f8;
    scrollbar-track-color:#1d2733;
    scrollbar-arrow-color:#52a1f2;
}
#chatview{
    background:#111A25;
}
#chat-messages{
    width:98%;
    height:100%; 
}
#chat-messages div.message{
    padding:0 0 40px 55px;
    clear:both;
    margin-bottom:40px;
}
#chat-messages div.message.right{
    padding: 0 58px 30px 0;
    margin-right: -19px;
    margin-left: 19px;
}
.message img{
    float: left;
    margin-left: -38px;
    border-radius: 50%;
    width: 30px;
    //margin-top:20px;
}
#chat-messages div.message.right img{
    float: right; 
    margin-left: 0;
    margin-right: -38px; 
}
.message .bubble{ 
    font-size:12px;
    font-weight:300;
    border-radius:5px 5px 5px 0px;
    color:#fff;
    position:relative;
    float:left;
    max-width:75%;
    min-width: 15%;
    word-wrap: break-word;
}

.me{ 
    background:#3E618A;
    padding:12px 13px;
}

.you{ 
    background:#232E3B;
    padding:25px 12px 5px 12px;
}

#chat-messages div.message.right .bubble{
    float:right;
    border-radius:5px 5px 0px 5px ;
}

.bubble .corner{
    position:absolute;
    width:7px;
    height:7px;
    left:-5px;
    bottom:0;
  
    border-width: 10px 8px 13px 8px;
    border-style: solid;
    border-color: transparent transparent #232E3B transparent;
}
div.message.right .corner{
    border-color: transparent transparent #3E618A transparent;
    left:auto;
    right:-5px;
}
.bubble span{
    color: ;
    font-size: 11px;
    position: absolute;
    right: 0;
    bottom: -22px;
}

.Sender{
    color:#85DE6B;
    position: absolute;
    top:-10px;
}

.Time-you{
    color:#6D7F8F;
    position: absolute;
    bottom:-6px;
    right: 10px;
    font-size:10px;
}

.Time-me{
    color:#8FBCDF;
    position: absolute;
    bottom:-6px;
    right: 30px;
    font-size:10px;
}

.check{
    color: red;
    position: absolute;
    bottom:3px;
    right: 5px;
}

            ";
        }
    }
}
