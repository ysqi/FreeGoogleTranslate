using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace EasyTransaction
{ 
    /// <summary>
    /// 翻译工具
    /// </summary>
    internal class TranslateTool
    {
        private Uri googleCNURL = new Uri("http://translate.google.cn/");
        private WebBrowser WebBrowser;
        public TranslateTool(WebBrowser wb)
        {
            if (wb == null)
            {
                throw new ArgumentNullException("入参不能为空");
            }
            this.WebBrowser = wb;
        }


        public void Start()
        {
            this.WebBrowser.DocumentCompleted -= WebBrowser_DocumentCompleted;
            this.WebBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
            this.WebBrowser.Navigate(googleCNURL);
        }

        /// <summary>
        /// 文档加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           if (e.Url.AbsolutePath== "blank")
            {
                return;
            }
            if (e.Url != googleCNURL)
            {
                if (DialogResult.Yes == MessageBox.Show("导航不能离开谷歌翻译：" + googleCNURL.ToString() + ",是否自动跳转", "提示", MessageBoxButtons.YesNo))
                {
                    this.WebBrowser.Navigate(googleCNURL);
                    return;
                }

            }
            else
            {
                //注册脚本
                this.RegJs();
            }
        }

        /// <summary>
        /// 注册获取Token的脚本
        /// </summary>
        public void RegJs()
        {
            //嵌入脚本
            var script = this.WebBrowser.Document.CreateElement("script");
            script.SetAttribute("type", "text/javascript");
            script.SetAttribute("text", "function getTk(d){return window.oM(d);}");
            this.WebBrowser.Document.Body.AppendChild(script);
        }

        /// <summary>
        /// 默认agent不需要重复获取
        /// </summary>
        private string agent;
        /// <summary>
        /// 一个很BT的获取IE默认UserAgent的方法
        /// </summary>
        private string GetDefaultUserAgent()
        {
            if (string.IsNullOrWhiteSpace(agent))
            {
                object window = this.WebBrowser.Document.Window.DomWindow;
                Type wt = window.GetType();
                object navigator = wt.InvokeMember("navigator", BindingFlags.GetProperty,
                    null, window, new object[] { });
                Type nt = navigator.GetType();
                object userAgent = nt.InvokeMember("userAgent", BindingFlags.GetProperty,
                    null, navigator, new object[] { });
                agent = userAgent.ToString();
            }
            return agent;
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string GetToken(string text)
        {
            text = text.Trim();
            if (text.Length == 0)
            {
                throw new ArgumentException("要翻译的内容不能为空");
            }
            try
            {
                var result = this.WebBrowser.Document.InvokeScript("getTk", new object[] { text });
                if (result == null)
                {
                    throw new Exception("获取Token失败，请确认已注册");
                }
                var token= result.ToString();
                if (token.StartsWith("&tk=")==false){
                    throw new Exception("获取Token失败，格式应该为&tk=X.X而实际为:"+token);
                }
                return token;
            }
            catch (Exception)
            {
                throw new Exception("获取Token失败，可能注册失败，或者Google的获取Token算法已修改，可以检测JS文件： desktop_module_main.js 中是否还存在方法oM(d)");
            }

        }
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="cookie">cookie</param>
        /// <returns></returns>
        private string Get(string url, ref CookieContainer cookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "get";
            request.ContentType = "application/json; charset=UTF-8";

            request.Referer = this.WebBrowser.Document.Url.ToString();// "http://translate.google.cn/";
            request.Host = "translate.google.cn";
            request.Headers.Add("Accept-Encoding", "gzip, deflate");
            request.Headers.Add("Accept-Language", "zh-Hans-CN,zh-Hans;q=0.5");
            request.UserAgent = GetDefaultUserAgent();

            if (cookie == null)
            {
                cookie = new CookieContainer();
                cookie.SetCookies(request.RequestUri, this.WebBrowser.Document.Cookie);
            }
            request.CookieContainer = cookie;
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {

                using (var myResponseStream = response.GetResponseStream())
                {
                    var myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("UTF-8"));
                    string retString = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                    return retString;
                }

            }
        }

        /// <summary>
        /// 全局保存Cookie
        /// </summary>
        private CookieContainer cookie;
        /// <summary>
        /// 执行翻译
        /// </summary>
        /// <param name="text"></param> 
        /// <param name="fromLan"></param>
        /// <param name="toLan"></param>
        /// <returns></returns>
        public string Translate(string text, string fromLan = "auto", string toLan = "zh-CN")
        {
            var url = "http://translate.google.cn/translate_a/single?client=t&sl=auto&tl=zh-CN&hl=en&dt=at&dt=bd&dt=ex&dt=ld&dt=md&dt=qca&dt=rw&dt=rm&dt=ss&dt=t&ie=UTF-8&oe=UTF-8&source=btn&ssel=0&tsel=0&kc=0";

            var tk = GetToken(text);
            url += tk + "&q=" + Uri.EscapeDataString(text);

            return Get(url, ref cookie);

        }
    }
}
