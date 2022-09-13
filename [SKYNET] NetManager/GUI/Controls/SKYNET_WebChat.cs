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
        public string ChatID;
        public ChatMessage LastMessage;
        public StringBuilder MessageHistory;

        List<ChatMessage> ChatMessages;

        public SKYNET_WebChat()
        {
            InitializeComponent();
            ChatMessages = new List<ChatMessage>();
            MessageHistory = new StringBuilder();

            StartWebBrowser();
        }

        private void StartWebBrowser()
        {
            webChat.AllowWebBrowserDrop = true; //Picha pero me carga lo que suelto
            webChat.Navigate("about:blank");
            while (webChat.Document == null || webChat.Document.Body == null)
                Application.DoEvents();

            /*if (File.Exists(HistoryFile))
            {
                string DocumentText = File.ReadAllText(HistoryFile);
                webChat.Document.OpenNew(true).Write(DocumentText);

            }
            else
            {

            }*/

            webChat.Document.OpenNew(true).Write($"<html>\n<head>\n" +
                               $"{GetHtmlIEVersion()}\n" +
                               //$"<style>{GetBackgroundImage()}</style>\n" +
                               //                                       $"<link rel=\"stylesheet\" href=\"c:/telegram.css\" >\n" +
                               $"</head>\n<body class=\"non_osx non_msie is_2x\" bgcolor={ColorTranslator.ToHtml(BackColor)}\"><br>\n" +
                               $"<div class=\"im_history_col_wrap im_history_loaded\" style=\"\">\n" +
                               $"<div class=\"im_history_messages im_history_messages_group\" style=\"\">\n");



            webChat.ScriptErrorsSuppressed = true; 

            AssignStyleSheet(webChat);
        }

        public void AssignStyleSheet(WebBrowser wBrowser)
        {
            IHTMLStyleSheet2 instance = (IHTMLStyleSheet2)((IHTMLDocument2)wBrowser.Document.DomDocument).createStyleSheet("", 0);

            NewLateBinding.LateSet(instance, null, "cssText", new object[1]
            {
                GetResetCSS() + "\r\n" + GetMainCSS() + "\r\n"
            }, null, null);

            HtmlElement htmlElement = wBrowser.Document.GetElementsByTagName("head")[0];
            HtmlElement htmlElement2 = wBrowser.Document.CreateElement("script");
            IHTMLScriptElement iHTMLScriptElement = (IHTMLScriptElement)htmlElement2.DomElement;

            //iHTMLScriptElement.text = GetJavascript();

            htmlElement.AppendChild(htmlElement2);
        }

        public void WriteChat(ChatMessage ChatMessage, bool isLoadingHistory = false)
        {
            string message = GetMessageBody(ChatMessage, true);

            MessageHistory.Append(message);

            webChat.Document.Write(message);
            //webChat.Document.Write(content);
            webChat.Document.Window.ScrollTo(0, webChat.Document.Body.ScrollRectangle.Height);
            WireUpButtonEvents();

            if (isLoadingHistory)
                return;

        }


        public void WireUpButtonEvents()
        {

            HtmlElementCollection elements = webChat.Document.GetElementsByTagName("IMG");
            for (int i = 0; i < elements.Count; i++)
            {
                HtmlElement el = elements[i];
                el.AttachEventHandler("ondblclick", (sender, args) => OnElementClicked(el, EventArgs.Empty));
            }
            HtmlElementCollection body = webChat.Document.GetElementsByTagName("BODY");
            for (int i = 0; i < body.Count; i++)
            {
                HtmlElement el = body[i];
                el.AttachEventHandler("onclick", (sender, args) => OnElementSelect(el, EventArgs.Empty));
            }

        }
        protected void OnElementClicked(object sender, EventArgs args)
        {
            HtmlElement el = sender as HtmlElement;
            string elType = el.GetAttribute("type");
            string elName = el.GetAttribute("name");
            string elValue = el.GetAttribute("value");

            //HtmlHelper.OpenFile(modCommon.convertURI(el.Id));

        }
        protected void OnElementSelect(object sender, EventArgs args)
        {
            //Hecho por mi
            string selection = webChat.Document.InvokeScript("getSelectionText").ToString();
            if (!string.IsNullOrEmpty(selection))
            {
                Clipboard.Clear();
                Clipboard.SetText(selection, TextDataFormat.UnicodeText);
            }
        }

        public static string GetHtmlIEVersion()
        {
            string str = "";
            try
            {
                if (Conversions.ToInteger(Conversions.ToString(InternetExplorerBrowserEmulation.GetInternetExplorerMajorVersion())) == 11)
                {
                    str = string.Format("<meta http-equiv='X-UA-Compatible' content='IE=edge'>");
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            return str;
        }

        public static string GetResetCSS()
        {
            XElement xElement = new XElement(XName.Get("css", ""));
            xElement.Add("\nhtml,body,div,span,applet,object,iframe,h1,h2,h3,h4,h5,h6,p,blockquote,pre,a,abbr,acronym,address,big,cite,code,del,dfn,em,img,ins,kbd,q,s,samp,small,strike,strong,sub,sup,tt,var,b,u,i,center,dl,dt,dd,ol,ul,li,fieldset,form,label,legend,table,caption,tbody,tfoot,thead,tr,th,td,article,aside,canvas,details,embed,figure,figcaption,footer,header,hgroup,menu,nav,output,ruby,section,summary,time,mark,audio,video{margin:0;padding:0;border:0;font-size:100%;font:inherit;vertical-align:baseline}article,aside,details,figcaption,figure,footer,header,hgroup,menu,nav,section{display:block}body{line-height:1}ol,ul{list-style:none}blockquote,q{quotes:none}blockquote:before,blockquote:after,q:before,q:after{content:'';content:none}table{border-collapse:collapse;border-spacing:0}\n           ");
            return xElement.Value;
        }
        public static string GetMainCSS()
        {
            XElement xElement = new XElement(XName.Get("string", ""));
            xElement.Add("\n*, *:before, *:after {\nbox-sizing: border-box;\n}\nbody{\n/*margin-top: 0px;*/\nmargin: 0px 8px;\noverflow-y: auto;\noverflow-x: hidden;\nFONT-FAMILY: Segoe UI;\nfont-size:10pt;\n\n/*white-space: pre;\nwhite-space: pre-line;\nwhite-space: pre-wrap;\nword-wrap: break-word;*/\nbackground-color:#ffffff;\n}\naudio{\nwidth:260px;\noverflow: hidden;\n}\npre{\nmargin:0px;\npadding:0px;\nfont-family: Segoe UI;\nfont-size:10pt;\n/*white-space: pre-line;*/\nwhite-space: pre-wrap;\nword-wrap: break-word;\nline-height:20px;\n}\npre a{\ncursor:pointer;\n}\np {\nmargin:0px;\npadding:0px;\nline-height:20px;\n}\n.seal{\nbackground-color: #6CB3FF;\nwidth:100%;\nheight:100%; \nz-index:1000;\ntop:0; \nleft:0; \nposition:absolute; \ncursor:pointer;\nvertical-align:middle;\nmargin:0 auto;\nbackground-position:center center;\nbackground-repeat:no-repeat;\n}\n#greybk {\nbackground-color:#f7f7f7;\nclear: both;\nwidth: 100%;\n/*display: inline;*/\nfloat: left;\n}\n#whitebk {\nbackground-color:#fcfcfc;\nclear: both;\nwidth: 100%;\n/*display: inline;*/\nfloat: left;\n}\n.showmore{\ncolor:#0078ca;FONT-FAMILY: Segoe UI;font-size:12px;\ncursor:pointer;\ntext-decoration: underline;\nclear:both;\nwidth: 70%\nfloat: left;\n}\n.nickname{\nclear:both;color:#A1A1A1;FONT-FAMILY: Segoe UI;font-size:14px;\nfloat:left;\nwidth:70%;\n}\n.currentusernickname{\nclear:both;color:#319aff;FONT-FAMILY: Segoe UI;font-size:14px;\nfloat:left;\nwidth:70%;\n}\n.msg_time, .msg_timeorange{\npadding:2px 0p 0px 5px;\nclear:right;\nfloat:right;\nFONT-FAMILY: Segoe UI;\nfont-size:12px;\ncolor:#A1A1A1;\ntext-align:right;\nmargin-top: 1px;\n}\n.msg_timeorange{\ncolor:#f98c01\n}\n.msg_timeannounce{\npadding:2px 0p 0px 5px;\nclear:right;\nfloat:right;\nFONT-FAMILY: Segoe UI;\nfont-size:12px;\ncolor:#A1A1A1;\nwidth:20%;\ntext-align:right;\n} \n.msg_container{\nclear:both;\npadding-bottom:4px;\n}\n.msg_body{\ncolor:#000000;FONT-FAMILY: Segoe UI;font-size:10pt;\nfloat:left;\ndisplay:inline;\nword-wrap: break-word;\nmargin:0px 0px 3px 3px;\npadding:0px 2px 2px 2px;\nmax-width:90%;\nbox-sizing: border-box;\nposition:relative;\n}\n.msg_body a{\ncolor:#0066cc;\ntext-decoration:underline;\ncursor:hand;\n}\na.mention-user{\nbackground-color:#689F38;\ntext-decoration:none;\ncolor:white;\npadding:2px;\nborder-radius:5px;\n}\n.msg_alertstatus_main{\nwidth:100%;\nfloat:left;\ntext-align:center;\npadding:10px 0px;\n}\n.radius_box{\nborder-radius: 25px;\nborder: 2px solid grey;\npadding:2px 10px 3px 10px;\ndisplay: inline-block;\n}\n.radius_box img{\nvertical-align:text-bottom;\n}\n.msg_alertstatus{\ncolor:#555555;FONT-FAMILY: Segoe UI;font-size:9pt;\n/*position:absolute;\ntop:50%;\nleft:20%;*/\ntext-align:center;\n/*background-color:#FFFE5F;*/\npadding:0px 0px 0px 2px;\nword-wrap: break-word;\n/*vertical-align: top;*/\n}\n.msg_alertstatus img{\npadding-right:3px;\nvertical-align: text-bottom;\n}\n.msg_request_main\n{\nbackground-color: #FFFFCE;\npadding:5px;\nposition:relative;\nclear:both;\nmargin-top:25px;\nmargin-left:15px;\nbox-shadow: 10px 10px 5px #ded7de;\nborder-color: #cecfce;\nborder-style:solid;\nwidth:90%;\nborder-width: 1px 0px 0px 1px;\n}\n\n.msg_leftgc{\ndisplay:block;\nwhite-space: nowrap;\noverflow: visible;\ncolor:#A1A1A1;FONT-FAMILY: Segoe UI;font-size:11px;\n/*float:right;*/\ntext-align:right;\nfont-weight: bold;\npadding-bottom:5px;\n\n}\n.msg_signout{\ncolor:#0072c6;FONT-FAMILY: Segoe UI;font-size:12px;\nfloat:right;\nfont-weight: bold;\npadding-bottom:5px;\n}\n.unreadmsg{\nfloat:right;padding:5px 6px 0px 0px;width:18px;\n}\n.datefont{\nfont-size:17px;\nfont-weight:bold;\ncolor:#686667;\ntext-align:center;\nword-wrap:break-word;\n}\n.todaydatefont{\nfont-size:13px;\nfont-weight:bold;\ncolor:#686667;\ntext-align:center;\nword-wrap:break-word;\n}\n.monthfont{\nfont-size:12px;\nfont-weight:bold;\ncolor:#686667;\ntext-align:left;\nword-wrap:break-word;\n}\n.datebox{\nwidth:  38px; \nclear:both;\nbackground-color: #e0e0e0; \ntext-align:center;\ntext-color:#686667;\nfont-family:arial;\nword-wrap:break-word;\nfloat:right;\nmargin-bottom:-1px;\n}\n.todaydatebox, .yesterdaydatebox{\npadding:5px;\nclear:both;\nbackground-color: #e0e0e0; \ntext-align:center;\ntext-color:#686667;\nfont-family:arial;\nword-wrap:break-word;\nfloat:right;\nmargin-top:13px;\nmargin-bottom:-1px;\n}\n.dashedline{\nclear:both;            \nborder-bottom: 1px dashed #d8d8d8;\nfloat:right;\nwidth:100%;\nclear:both;\nbackground-color:transparent;\n}\n.dateheader, .todaydateheader{\nfloat:left;\nwidth:100%;\n}\n.logdateheader, .todaylogdateheader{\ndisplay:inline;\n}\n.highlighttext{\nbackground-color: lime;\nfont-weight: bold;\ntext-color:white;\n}\n.logfromnamea{\npadding-top:4px;\nvertical-align:middle;\ncolor:#397dba;\nFONT-FAMILY: Segoe UI;\nfont-size:14px;\nfloat:left;\nwidth:70%;\nword-wrap: break-word;\nmargin:0px 0px 3px 3px;\npadding:0px 2px 2px 2px;\n}\n.logfromname{\npadding-top:4px;\npadding-bottom:2px;  \nvertical-align:middle;\ncolor:#397dba;\nFONT-FAMILY: Segoe UI;\nfont-size:14px;\nclear:both;\ndisplay:box;\n}\n.logfromName img{\nvertical-align:middle;\n}\n.logfromnamea img{\nvertical-align: top;\n}\n.logdateorange{\ncolor:#ff9104;\nFONT-FAMILY: Segoe UI;\nfont-size:11px;\nfont-weight:italic;\n/*float:left;*/\ndisplay:inline;\npadding-top:5px;\nclear:both;\nheight:25px;\nwidth:49%;\nvertical-align:top;\n}\n.logdate{\nwidth:51%;\ndisplay:inline;\ntext-align:right;\nfloat:right;\n}\nimg.middle{\nborder-radius:50%;\nvertical-align:middle;\n}\n\nimg.bottom{\nvertical-align:bottom;\n}\n.logdate .todaydatebox, .logdate .yesterdaydatebox{\nmargin-top:0px;\n}\n/*** Bullets ***/\n.bullet{\nclear:both;\nfloat:left;\ndisplay:inline;\nposition:relative;\nwidth:5px;\nheight:10pt;\nmargin:0px 0px 0px 15px;\noverflow:hidden;\nvertical-align:top;\n}\n.bullet img{\nvertical-align:middle;\nposition:absolute;\nleft: 0px;\nbottom:0px;\ntop:3px;\nmargin-top:1px;\n}\n.bullet img.non-delivered{\n}\n.bullet img.server-delivered{\nmargin-left: -6px;\n}\n.bullet img.delivered{\nmargin-left: -12px;\n}\n.bullet img.read{\nmargin-left: -18px;\n}\n.bullet img.unread{\nmargin-left: -24px;\n}\n.bullet img.edit-non-delivered, .bullet img.edit-server-delivered{\nmargin-left: -31px;\n}\n.bullet img.edit-delivered{\nmargin-left: -41px;\n}\n.bullet img.edit{\nmargin-left: -51px;\n}\n.bullet img.o_edit{\nmargin-left: -61px;\n}\n.bullet img.delete{\nmargin-left: -72px;\n}\n.bullet img.lock-non-delivered, .bullet img.lock-server-delivered{\nmargin-left: -82px;\n}\n.bullet img.lock-delivered{\nmargin-left: -92px;\n}\n.bullet img.lock{\nmargin-left: -102px;\n}\n.bullet img.o_lock{\nmargin-left: -112px;\n}\n.edit_bullet{\nheight:12pt;\nwidth:9px;\nmargin-left:12px;\nmargin-top:-1px;\n}\n.lock_bullet{\nheight:12px;\nwidth:12px;\nmargin-left:12px;\nmargin-top: -3px;\n}\n.sep, .bottom_sep, .bottom_8_sep{\npadding: 0 0 0 0;\nclear:both;\n}\n.bottom_sep{\npadding-bottom:4px;            \n}\n.bottom_8_sep{\npadding-bottom:8px;\n}\n.filebullet{\nvertical-align:top;            \n}\n.ack-bullet {\nwidth:16px;\nheight:20px;\nfloat:right;\nclear:none;\ndisplay:inline;\nposition:absolute;\nright:6px;\nz-index:1000;\n}\n.ack-bullet img.unsel {\ncursor:pointer;\n}\n.ack-bullet img.sel, .ack-bullet img.unsel:hover {\nmargin-left:-16px;\n}\n/*** End Bullets ***/\n/*** Emotions ***/\n.emotion{\nwidth:16px;\nheight:16px;\noverflow:hidden;\nposition:relative;\ndisplay: inline-block;\n/*float:left;*/\n}\n.emotion img{\nposition:absolute;\nleft:-5px;\ntop:-5px;\n}\n.e_whistle{\nwidth:17px;\nheight:17px;\n}\n.e_brb{\nwidth:17px;\nheight:17px;\n}\n.e_secret{\nwidth:19px;\nheight:19px;\n}\n/*First Row*/\n.emotion img.smile{\n}\n.emotion img.very_happy{\nmargin-left:-25px;\n}\n.emotion img.baring_teeth{\nmargin-left:-50px;\n}\n.emotion img.winking{\nmargin-left:-75px;\n}\n.emotion img.shocked{\nmargin-left:-100px;\n}\n.emotion img.omg{\nmargin-left:-125px;\n}\n.emotion img.tonque_out{\nmargin-left:-150px;\n}\n.emotion img.nerd{\nmargin-left:-175px;\n}\n/*Second Row*/\n.emotion img.angry{\nmargin-top:-25px;\n}\n.emotion img.ashamed{\nmargin-left:-25px;\nmargin-top:-25px;\n}\n.emotion img.i_dont_know{\nmargin-left:-50px;\nmargin-top:-25px;\n}\n.emotion img.confused{\nmargin-left:-75px;\nmargin-top:-25px;\n}\n.emotion img.crying{\nmargin-left:-100px;\nmargin-top:-25px;\n}\n.emotion img.sad{\nmargin-left:-125px;\nmargin-top:-25px;\n}\n.emotion img.dont_tell_anyone{\nmargin-left:-150px;\nmargin-top:-25px;\n}\n.emotion img.bye{\nmargin-left:-175px;\nmargin-top:-25px;\n}\n/*Third Row*/\n.emotion img.thinking{\nmargin-top:-51px;\n}\n.emotion img.sorry{\nmargin-left:-25px;\nmargin-top:-51px;\n}\n.emotion img.sleepy{\nmargin-left:-50px;\nmargin-top:-51px;\n}\n.emotion img.sick{\nmargin-left:-75px;\nmargin-top:-51px;\n}\n.emotion img.cool{\nmargin-left:-100px;\nmargin-top:-51px;\n}\n.emotion img.angel{\nmargin-left:-125px;\nmargin-top:-51px;\n}\n.emotion img.devil{\nmargin-left:-150px;\nmargin-top:-51px;\n}\n.emotion img.party{\nmargin-left:-175px;\nmargin-top:-51px;\n}\n/*Forth Row*/\n.emotion img.whistle{\nmargin-top:-78px;\n}\n.emotion img.brb{\nmargin-left:-25px;\nmargin-top:-78px;\n}\n.emotion img.secret{\nmargin-left:-50px;\nmargin-top:-78px;\n}\n.emotion img.headache{\nmargin-left:-75px;\nmargin-top:-78px;\n}\n.emotion img.gift{\nmargin-left:-100px;\nmargin-top:-78px;\n}\n.emotion img.birthday_cake{\nmargin-left:-125px;\nmargin-top:-78px;\n}\n.emotion img.heart{\nmargin-left:-150px;\nmargin-top:-78px;\n}\n.emotion img.broken_heart{\nmargin-left:-175px;\nmargin-top:-78px;\n}\n/*Fifth Row*/\n.emotion img.star{\nmargin-top:-106px;\n}\n.emotion img.clock{\nmargin-left:-25px;\nmargin-top:-103px;\n}\n.emotion img.coffee{\nmargin-left:-50px;\nmargin-top:-105px;\n}\n.emotion img.food{\nmargin-left:-75px;\nmargin-top:-105px;\n}\n.emotion img.money{\nmargin-left:-100px;\nmargin-top:-105px;\n}\n.emotion img.clapping_hands{\nmargin-left:-125px;\nmargin-top:-105px;\n}\n.emotion img.fingers_crossed{\nmargin-left:-150px;\nmargin-top:-105px;\n}\n.emotion img.snail{\nmargin-left:-175px;\nmargin-top:-105px;\n}\n/*Sixth Row*/\n.emotion img.rose{\nmargin-top:-130px;\n}\n.emotion img.wilted_rose{\nmargin-left:-25px;\nmargin-top:-130px;\n}\n.emotion img.play{\nmargin-left:-50px;\nmargin-top:-130px;\n}\n.emotion img.idea{\nmargin-left:-75px;\nmargin-top:-130px;\n}\n.emotion img.beer{\nmargin-left:-100px;\nmargin-top:-130px;\n}\n.emotion img.phone{\nmargin-left:-125px;\nmargin-top:-130px;\n}\n.emotion img.thumbs_up{\nmargin-left:-150px;\nmargin-top:-130px;\n}\n.emotion img.thumbs_down{\nmargin-left:-175px;\nmargin-top:-130px;\n}\n/*** End Emotions ***/\n.chat_cmd{\nbackground-color: #F2F2F2;\npadding:5px;\nposition:relative;\nclear:both;\nmargin-left:15px;\nwidth:90%;\n}\n.chat_cmd div{\npadding-bottom:8px;\n}\n.close_cmd{\nposition:absolute;\nright:5px;\ntop:0px;\ncursor:pointer;\n}\n.previous_message{\ntext-align:center;\n/*clear:both;\nfloat:left;\nwidth:100%;*/\npadding:5px 0px;\nposition:absolute;\ntop:-3px;\nleft: 49%;\npadding:0px;\nmargin:0px;\n}\n.previous_message span{\nbackground-color:transparent;\ncolor:#555151;\nfont-size:12px;\ncursor:pointer;\npadding:0px 4px 1px 4px;\n/*position:absolute;\ntop:-3px;\nleft: 49%;*/\n}\n.previous_message_img{\ntop:2px;\n}\n.previous_message img{\ndisplay:none;\n}\n.notify_container{\nfloat:left;\nclear:both;\nwidth:100%;\npadding:10px 0px;\n}\n.notify{\nfloat:left;\npadding:5px 0px 5px 5px;\nbackground-color:#C7EDFC;\ncolor:Black;\nwidth:100%;\nbox-sizing: border-box;\n}\n.notify .nickname{\ncolor:#000000;\n}\n#greybk.notify_container, #whitebk.notify_container{\npadding-top:0px;            \n}\n#greybk.n_success, #whitebk.n_success{\nbackground-color:#dff0d8;\n}\n.n_primary, #greybk.n_primary, #whitebk.n_primary{\nbackground-color: #428bca;\ncolor:#ffffff;\n}\n.n_primary .msg_time, #greybk.n_primary .msg_timeannounce, #whitebk.n_primary .msg_timeannounce{\ncolor:#cccccc;\n}\n.n_primary .msg_body, .n_primary .nickname, #greybk.n_primary .logfromnamea, #whitebk.n_primary .logfromnamea{\ncolor:#ffffff;\n}\n.n_primary .msg_body,\n.n_info .msg_body,\n.n_warning .msg_body,\n.n_danger .msg_body,\n.n_success .msg_body{\nmargin-left:0px;\npadding-left:0px;\n}\n.n_info, #greybk.n_info, #whitebk.n_info{\nbackground-color: #d9edf7;\n}\n.n_warning, #greybk.n_warning, #whitebk.n_warning{\nbackground-color: #fcf8e3;\n}\n.n_danger, #greybk.n_danger, #whitebk.n_danger{\nbackground-color: #f2dede;\n}\n.subject{\nborder:1px solid #A2E5FF;\nbackground-color:#C7EDFC;\npadding:5px 10px;\nwidth:100%;\nclear:both;\nbox-sizing: border-box;\n}\n.fixed, .lfixed{\nposition: fixed;\ntop: 0px;\nright: 0px;\nmargin-right: 8px;\nz-index:-1;\n\n/* IE7 and Below*/\n*position: absolute;\n*top: expression(this.offsetParent.scrollTop);\n/* End IE7 and Below*/\n}\n.lfixed{\nz-index:1000;\n}\n.fixed .datebox, .fixed .todaydatebox, .fixed .yesterdaydatebox,\n.lfixed .datebox, .lfixed .todaydatebox, .lfixed .yesterdaydatebox{\nopacity: 0.4;\nfilter: alpha(opacity=40); /* For IE8 and earlier */\n}\n.file_container{\n/*display:inline-block;\nwidth:100%;*/\n}\n.plugin_file {\nmax-height: 200px;\nmax-width: 200px;\ncursor:pointer;\nvertical-align:top;\n}\n.top_load{\nposition:absolute;\ntop:3px;\nleft: 49%;\npadding:0px;\nmargin:0px;\ndisplay:none;\n}    \n/* Reply Message */\n.reply {\nborder-left:3px solid green;\npadding-left:5px;\nmargin-top:2px;\nmargin-bottom:5px;\ncursor:pointer;\nbackground-color:#f5f5f5;\nfloat:left;\nmax-width:100%;\nposition:relative;\nbox-sizing:border-box;\n}\n.forward{\nborder-left: 3px solid orange;\ncursor:default;\n}\n.reply_name {\ncolor:green;\nfont-size: 14px;\n}\n.reply_message {\ntext-overflow: ellipsis;\nwidth: 100%;\nheight:20px;\nwhite-space: nowrap;\noverflow: hidden;\ntext-overflow: ellipsis;\n}\n.reply_file {\nfloat:left;\ndisplay:none;\nheight:40px;\nvertical-align:middle; \ntext-align:center;\nposition:absolute;\n/*margin-right: 5px;*/\nleft: 4px;\ntop: 0px;\n}\n.reply_file img {\nposition: absolute;\nmargin: auto;\ntop: 0;\nleft: 0;\nright: 0;\nbottom: 0;\n}\n.reply_container{\nfloat:left;\nmax-width:100%;\nbox-sizing: border-box;\n}\n.reply_container .msg_time {\nfont-size: 10px;\npadding: 3px 10px 0px 10px;\nfloat:none;\n}\n/* End Reply Message */\n/*Acknowledgement*/\n.btn {\nbackground-image: none;\nborder: 1px solid #A0A0A2;\nborder-radius: 4px;\ncursor: pointer;\ndisplay: inline-block;\nfont-size: 14px;\nfont-weight: 400;\nline-height: 1.42857;\nmargin-bottom: 0;\npadding: 2px 4px;\ntext-align: center;\nvertical-align: middle;\nwhite-space: nowrap;\nbackground-color: #fff;\ncolor: #5A6066;\n}\n.btn-small {\nfont-size: 10px;\n}\n.btn-ack {\nmargin: 0px 0px 0px 3px;\nfloat: left;\n}\n.btn:hover {\ncolor: #333;\nbackground-color: #e6e6e6;\nborder-color: #adadad;\n}\n.btn:active {\ncolor: #333;\nbackground-color: #d4d4d4;\nborder-color: #8c8c8c;\n}\n.ack-status {\nfloat: left;\nwidth: 18px;\nheight: 19px;\nposition: relative;\noverflow: hidden;\nmargin-top:1px;\nmargin-left:5px;\n}\n.ack-status img {\nposition: absolute;\n}\n.ack-status img.s-inactive{\nleft: -21px;\ntop: -1px;\n}\n.ack-status img.s-active {\nleft: -41px;\ntop: -1px;\n}\n.ack-status img.r-active, .ack-status img.r-inactive, .ack-status img.s-inactive, .ack-status img.s-active {\ncursor: default;\n}\n.ack-status img.r-active, .ack-status img.r-inactive {\nleft: 0px;\n}\n.ack-s-status {\n/*float: right;*/\n}\n/*End Acknowledgement*/\n/*Acknowledgement Users*/\n.popover-container {\nposition:relative;float:left;\n}\n.popover-container.right {\nfloat:right;\n}\n.popover {\nbackground-clip: padding-box;\nbackground-color: #fff;\nborder: 1px solid rgba(0, 0, 0, 0.2);\nborder-radius: 6px;\nbox-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);\ndisplay: none;\nfont-size: 14px;\nfont-style: normal;\nfont-weight: 400;\nleft: 0;\nletter-spacing: normal;\nline-height: 1.42857;\nmax-width: 276px;\npadding: 1px;\nposition: absolute;\ntext-align: start;\ntext-decoration: none;\ntext-shadow: none;\ntext-transform: none;\ntop: -7;\nwhite-space: normal;\nword-break: normal;\nword-spacing: normal;\nword-wrap: normal;\nz-index: 1060;\n}\n.popover-container.right .popover{\nright:13px;\nleft:auto;\n*right: -2px;\n}\n.popover.top {\nmargin-top: -10px;\n}\n.popover.right {\nmargin-left: 10px;\n*margin-left: 0px;\n}\n.popover.bottom {\nmargin-top: 10px;\n}\n.popover.left {\nmargin-left: -10px;\n}\n.popover-content {\npadding: 9px 14px;\n}\n.popover > .arrow, .popover > .arrow::after {\nborder-color: transparent;\nborder-style: solid;\ndisplay: block;\nheight: 0;\nposition: absolute;\nwidth: 0;\n}\n.popover > .arrow {\nborder-width: 11px;\n}\n.popover > .arrow::after {\nborder-width: 10px;\ncontent: \"\";\n}\n.popover.top > .arrow {\nborder-bottom-width: 0;\nborder-top-color: rgba(0, 0, 0, 0.25);\nbottom: -11px;\nleft: 50%;\nmargin-left: -11px;\n}\n.popover.top > .arrow::after {\nborder-bottom-width: 0;\nborder-top-color: #fff;\nbottom: 1px;\ncontent: \" \";\nmargin-left: -10px;\n}\n.popover.right > .arrow {\nborder-left-width: 0;\nborder-right-color: rgba(0, 0, 0, 0.25);\nleft: -11px;\nmargin-top: -11px;\ntop: 50%;\n}\n.popover.right > .arrow::after {\nborder-left-width: 0;\nborder-right-color: #fff;\nbottom: -10px;\ncontent: \" \";\nleft: 1px;\n}\n.popover.bottom > .arrow {\nborder-bottom-color: rgba(0, 0, 0, 0.25);\nborder-top-width: 0;\nleft: 50%;\nmargin-left: -11px;\ntop: -11px;\n}\n.popover.bottom > .arrow::after {\nborder-bottom-color: #fff;\nborder-top-width: 0;\ncontent: \" \";\nmargin-left: -10px;\ntop: 1px;\n}\n.popover.left > .arrow {\nborder-left-color: rgba(0, 0, 0, 0.25);\nborder-right-width: 0;\nmargin-top: -11px;\nright: -11px;\ntop: 50%;\n}\n.popover.left > .arrow::after {\nborder-left-color: #fff;\nborder-right-width: 0;\nbottom: -10px;\ncontent: \" \";\nright: 1px;\n}\n.popover {\nright: auto;\nfont-size: 12px;\ncursor: auto;\n}\n.popover-content {\npadding: 4px 10px;\nmax-height: 200px;\noverflow-y: auto;\noverflow-x:hidden;\nwhite-space: nowrap;\n}\n.ack-list {\nlist-style-type: none;\nmargin: 0;\npadding: 0;\nwhite-space: nowrap;\n}\n.ack-list img {\nwidth: 24px;\nheight: 24px;\n}\n.ack-list li {\npadding: 2px 0;\nfloat:left;\nclear:left;\n}\n.ack-user{\n}\n.ack-date{\ncolor: #a8aab1;\nfont-size:8px;\nmargin-left:5px;\n}\n.ack-user-cnt{\ncolor: #a8aab1;\ndisplay: block;\nfont-size: 11px;\nmargin: 3px 0 0 2px;\n}\n.popover-container.right .ack-user-cnt {\nmargin: 2px 4px 0 0;\n}\n/*End Acknowledgement Users*/\n/*Starred Message*/\n.starred {\nfloat: left;\nwidth: 18px;\nheight: 19px;\noverflow: hidden;\nmargin-top:1px;\nmargin-left:5px;\ncursor:pointer;\n}\n/*End Starred Message*/\n.msg_body,.currentusernickname,.nickname,.single_inline_block, .s_file_block_size, .r_file_block_size, .reply_container{\nline-height:20px;\n}\n.file-description{\nclear:both;\n}\n");
            return xElement.Value;
        }

        public static string GetMessageBody(ChatMessage MessageContent, bool Avatar)
        {
            StringBuilder MessageBody = new StringBuilder();
            var box = DeviceManager.GetBoxFromIP(MessageContent.Addresses);

            //if (MessageContent.FromChatID == ChatSettings.UserID)
            //{
            //    //Cuerpo del Mensaje
            //    /*
            //    MessageBody.Append("<div class=\"im_history_message_wrap\" style=\"\">\n");
            //    MessageBody.Append("<div class=\"im_message_outer_wrap\">\n");
            //    MessageBody.Append("<div class=\"im_message_wrap clearfix\">\n");
            //    MessageBody.Append("<div ng-switch-default=\"\" class=\"im_content_message_wrap im_message_out\" >\n");
            //    MessageBody.Append("<a class=\"im_message_from_photo pull-left peer_photo_init\" >\n");
            //    MessageBody.Append($"<img class=\"im_message_from_photo\" src=\"{UserManager.GetUserAvatarFromID(ID, true)}\"></a>\n");
            //    MessageBody.Append("<div>\n");
            //    MessageBody.Append("<div class=\"im_message_body\" >\n");
            //    MessageBody.Append($"<div class=\"im_message_text\" dir=\"auto\">{Message}</div>\n");
            //    MessageBody.Append($"<div class=\"Time_Format\">{DateTime.Now.ToString("h:m tt")}</div>\n");
            //    MessageBody.Append("</div>\n");
            //    MessageBody.Append("<div class=\"im_message_keyboard\" style=\"display: none;\"></div>\n");
            //    MessageBody.Append("</div></div></div></div></div>\n");
            //    */

            //    // Cuerpo del Mensaje
            //    MessageBody.Append("<div class=\"im_history_message_wrap\" ><div class=\"im_message_outer_wrap\" >\n");
            //    MessageBody.Append("<div class=\"im_message_wrap clearfix\">\n");
            //    MessageBody.Append("<div class=\"im_content_message_wrap im_message_in\" >\n");
            //    if (Avatar)
            //    {
            //        string AvatarPath = "";
            //        if (box != null)
            //        {
            //            AvatarPath = DeviceManager.GetAvatarFromOrden(box.Device.Name);
            //        }
            //        else
            //        {
            //            AvatarPath = Path.Combine(Common.CurrentDirectory, "Data", "DefaultAvatar.jpg"));
            //        }

            //        MessageBody.Append("<a class=\"im_message_from_photo\" >\n");
            //        // Imagen del Usuario
            //        MessageBody.Append($"<img class=\"im_message_from_photo\" src=\"{AvatarPath}\">\n");
            //    }
            //    // Cuerpo del Mensaje
            //    MessageBody.Append("<div>\n");
            //    MessageBody.Append("<div class=\"im_message_body\" >\n");
            //    // Nombre de Usuario
            //    MessageBody.Append($"<a class=\"im_message_author user_color_8\">{UserName}</a>\n");
            //    // Cargo del Usuario
            //    MessageBody.Append($"<span class=\"im_message_author_admin\" style=\"display: none;\">{""/*Ocupation*/}</span>\n");
            //    // Texto del Mensaje
            //    MessageBody.Append($"<div class=\"im_message_text\" dir=\"auto\" id=\"{MessageContent.MessageID}\">{MessageContent.Content}</div>\n");
            //    MessageBody.Append($"<div class=\"Time_Format\">{GetTime(MessageContent.Time)}</div>\n");
            //    MessageBody.Append("</div></div></div></div></div></div>\n");

            //}
            //else
            {
                // Cuerpo del Mensaje
                MessageBody.Append("<div class=\"im_history_message_wrap\" ><div class=\"im_message_outer_wrap\" >\n");
                MessageBody.Append("<div class=\"im_message_wrap clearfix\">\n");
                MessageBody.Append("<div class=\"im_content_message_wrap im_message_in\" >\n");

                if (Avatar)
                {
                    MessageBody.Append("<a class=\"im_message_from_photo pull-left peer_photo_init\" >\n");

                    string AvatarPath = "";
                    if (box != null)
                    {
                        AvatarPath = DeviceManager.GetAvatarPath(box.Device);
                    }
                    else
                    {
                        AvatarPath = Path.Combine(Common.GetPath(), "Data", "DefaultAvatar.jpg");
                    }
                    MessageBody.Append($"<img class=\"im_message_from_photo Radius\" src=\"{AvatarPath}\"></a>\n");

                }
                // Cuerpo del Mensaje
                MessageBody.Append("<div>\n");
                MessageBody.Append("<div class=\"im_message_body\" >\n");
                // Nombre de Usuario
                string UserName = box == null ? MessageContent.Sender : box.Device.Name;
                MessageBody.Append($"<a class=\"im_message_author user_color_8\">{UserName}</a>\n");
                // Cargo del Usuario
                MessageBody.Append($"<span class=\"im_message_author_admin\" style=\"display: none;\">{""/*Ocupation*/}</span>\n");
                // Texto del Mensaje
                MessageBody.Append($"<div class=\"im_message_text\" dir=\"auto\">{MessageContent.Message}</div>\n");
                MessageBody.Append($"<div class=\"Time_Format\">{GetTime(MessageContent.Time)}</div>\n");
                MessageBody.Append("</div></div></div></div></div></div>\n");
            }

            return MessageBody.ToString();
        }

        private static object GetTime(object time)
        {
            throw new NotImplementedException();
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

    }
}
