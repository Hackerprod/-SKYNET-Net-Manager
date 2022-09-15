using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkynetChat;
using mshtml;
using Microsoft.VisualBasic.CompilerServices;
using SKYNET.Properties;
using System.IO;
using SKYNET.Controls;
using System.Diagnostics;
using System.Web.Script.Serialization;
using SKYNET.Types;
using System.Xml.Linq;

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
            HTTP.AppendLine("<div id='pagewrap'>");
            HTTP.AppendLine("<section class='chatbox'>");
            HTTP.AppendLine("<ul id='message'>");

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
                    //imagePath = Path.Combine(Common.GetPath(), "Data", "Images", deviceBox.Device.Guid + ".jpg");
                }

                imagePath =  $"http://{deviceBox.Device.IPAddress}:28082/Avatar";
            }


            if (true)
            //if (MessageContent.Sender == Environment.UserName)
            {
                HTTP.AppendLine($"<div class='chat-container'>");
                HTTP.AppendLine($"<figure>");
                HTTP.AppendLine($"<img width='100%' height='100%' src='{imagePath}'>");
                HTTP.AppendLine($"</figure>");
                HTTP.AppendLine($"<div class='matt-line'>");
                HTTP.AppendLine($"<p>{MessageContent.Message}");
                HTTP.AppendLine($"<span class='pmessage-time'>{GetTime(MessageContent.Time)}</span>");
                HTTP.AppendLine($"</p>");
                HTTP.AppendLine($"</div>");
                HTTP.AppendLine($"</div>");


                HTTP.AppendLine($"<li class='first'>");
                HTTP.AppendLine($"{MessageContent.Message}");
                HTTP.AppendLine($"<div class='done-container'>");
                HTTP.AppendLine($"<span class='message-time'>12:45 PM</span>");
                HTTP.AppendLine($"<svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 45 45' width='25' height='20'>");
                HTTP.AppendLine($"<path class='done-icon' d='M14.7 35.9 3.5 24.7l2.15-2.15 9.05 9.05 2.15 2.15Zm8.5 0L12 24.7l2.15-2.15 9.05 9.05 19.2-19.2 2.15 2.15Zm0-8.5-2.15-2.15L33.9 12.4l2.15 2.15Z'/>");
                HTTP.AppendLine($"</svg>");
                HTTP.AppendLine($"</div>");
                HTTP.AppendLine($"</li>");
            }
            else
            {
                HTTP.AppendLine($"<li class='first'>");
                HTTP.AppendLine($"{MessageContent.Message}");
                HTTP.AppendLine($"<div class='done-container'>");
                HTTP.AppendLine($"<span class='message-time'>12:45 PM</span>");
                HTTP.AppendLine($"<svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 45 45' width='25' height='20'>");
                HTTP.AppendLine($"<path class='done-icon' d='M14.7 35.9 3.5 24.7l2.15-2.15 9.05 9.05 2.15 2.15Zm8.5 0L12 24.7l2.15-2.15 9.05 9.05 19.2-19.2 2.15 2.15Zm0-8.5-2.15-2.15L33.9 12.4l2.15 2.15Z'/>");
                HTTP.AppendLine($"</svg>");
                HTTP.AppendLine($"</div>");
                HTTP.AppendLine($"</li>");
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

        public static string GetMyCSS()
        {
            return @"
* {
      box-sizing: border-box;
      margin: 0;
      padding: 0;
      list-style-type: none;
    }

    html {
      overflow: scroll;
      overflow-x: hidden;
    }

    ::-webkit-scrollbar {
      width: 0px;
      background: transparent;
    }

    ::-webkit-scrollbar-thumb {
      background: transparent;
    }

    body {
      font: normal 16px/1.5 'Libre Franklin', Helvetica, Georgia, sans-serif, serif;
      background-color-gradient(blue, green);
      height: 100vh;
      background: #2a3644;
    }

    #pagewrap {
      max-width: 360px;
      margin: 3vh auto;
      box-shadow: 0 10px 20px rgba(0, 0, 0, 0.19), 0 6px 6px rgba(0, 0, 0, 0.23);
    }

    .chatbox {
      background-color: #1D2733;
      padding: 10px 20px;
      width: 100%;
      height: 350px;
      overflow-y: scroll;
    }

    .time {
      text-align: center;
      font-size: .70em;
      color: #666;
      margin-top: 30%;
      letter-spacing: 1.2px;
      word-spacing: 2px;
    }

    #message {
      width: 100%;
    }

    .matt-line {
      max-width: 70%;
      min-width: 10%;
      font-size: .85em;
      position: relative;
      margin-left: 60px;
      animation: scaler 150ms ease-out;
    }

    .chat-container {
      position: relative;
    }

    .chat-container figure {
      position: absolute;
      bottom: 0;
      width: 40px;
      height: 40px;
      border-radius: 50%;
      overflow: hidden;
      box-shadow: rgba(68, 68, 68, 0.616) 0px 0px 9px;
    }

    .matt-line p:after {
      content: '';
      display: block;
      position: relative;
      left: -20px;
      bottom: -10px;
      width: 0;
      border-width: 0 10px 10px;
      border-style: solid;
      border-color: #444 transparent;
    }

    .matt-line p {
      background-color: #444;
      color: #fff;
      padding: 10px;
      border-radius: 10px;
      word-wrap: break-word;
      font-weight: 500;
      position: relative;
    }

    #message:before,
    #message:after {
      content: '';
      display: block;
      clear: both;
    }

    #message li {
      background-color: #e5eaec;
      color: #222;
      font-size: .85em;
      border-radius: 10px;
      position: relative;
      padding: 10px 30px 30px;
      margin: 20px 0;
      max-width: 70%;
      min-width: 10%;
      float: right;
      word-wrap: break-word;
      clear: both;
      animation: scaler 150ms ease-out;
      font-weight: 500;
    }

    .done-container {
      position: absolute;
      right: 30px;
      bottom: 2px;
    }

    .done-container .message-time {
      color: #666;
      margin-right: 5px;
      font-size: .70em;
    }

    .done-container svg {
      position: absolute;
      top: -2px;
    }

    #message .first:after {
      content: '';
      display: block;
      position: absolute;
      right: -10px;
      top: 0;
      width: 0;
      border-width: 10px 10px 0;
      border-style: solid;
      border-color: #e5eaec transparent;
    }


    .reply {
      padding: 15px 0;
      background-color: #f5f8f9;
      display: -webkit-box;
      display: -ms-flexbox;
      display: flex;
      -webkit-box-pack: justify;
      -ms-flex-pack: justify;
      justify-content: space-between;
    }

    .reply:before,
    .reply:after {
      content: '';
      display: block;
      clear: both;
    }

    .material-icons,
    input,
    button {
      float: left;
      margin: 3px;
      -webkit-box-flex: 1;
      -ms-flex: 1 1 0;
      flex: 1 1 0;
    }


    .material-icons {
      color: #444;
      font-size: 1.8em;
      padding-top: 10px;
      transform: rotate(-60deg);
      cursor: pointer;
    }

    input {
      width: 72%;
      padding: 10px;
      border: none;
      font-size: 1.2em;
      background-color: inherit;
    }

    input:focus,
    button:focus {
      outline: 0;
    }

    button {
      background-color: #222;
      color: #fff;
      padding: 15px 10px;
      width: 20%;
      vertical-align: middle;
      border: none;
      cursor: pointer;
      letter-spacing: 1.2px;
    }

    .scroll {
      position: absolute;
      bottom: 0;
    }

    .done-icon {
      fill: blueviolet;
      width: 20px;
      height: 20px;
    }

    .pmessage-time {
      position: absolute;
      bottom: 2px;
      right: 9px;
      color: #a7a7a7;
      font-size: .70em;
    }


    @keyframes scaler {
      0% {
        transform: scale(0)
      }

      100% {
        transform: scale(1)
      }
    }

            ";
        }

    }
}
