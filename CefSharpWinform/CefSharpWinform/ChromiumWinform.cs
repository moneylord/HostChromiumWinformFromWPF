using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;
using System.Globalization;
using System.Windows.Forms;

namespace CefSharpWinform
{
    public partial class ChromiumWinform: UserControl
    {
        public ChromiumWinform()
        {
            InitializeComponent();
            InitializeChromium();
        }

        #region Chromium
        public ChromiumWebBrowser chromeBrowser;

        public void InitializeChromium()
        {
            var cefPath = Application.StartupPath + @"\";

            CefSettings settings = new CefSettings();

            // Copy from Wpf version
            settings.LocalesDirPath = System.IO.Path.Combine(Application.StartupPath, "locales");
            settings.Locale = CultureInfo.CurrentCulture.EnglishName;
            settings.CachePath = System.IO.Path.Combine(cefPath, "cache");
            settings.LogFile = System.IO.Path.Combine(cefPath, "CefLog.txt");
            settings.LogSeverity = CefSharp.LogSeverity.Info;
            settings.BrowserSubprocessPath = System.IO.Path.Combine(cefPath, "CefSharp.BrowserSubprocess.exe");
            settings.SetOffScreenRenderingBestPerformanceArgs();

            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("www.google.com");            
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;            
        }
        #endregion

        #region Method
        public void ExecuteJavaScriptAsync(string _json, string scriptUrl = "about:blank", int startLine = 1)
        {
            chromeBrowser.GetBrowser().MainFrame.ExecuteJavaScriptAsync(_json, scriptUrl, startLine);
        }
        
        public void RegisterJsObject(string name, object objectToBind, BindingOptions options = null)
        {
            chromeBrowser.RegisterJsObject(name, objectToBind);
        }
        #endregion

        #region
        private IContextMenuHandler _menuHandler;
        public IContextMenuHandler MenuHandler
        {
            get { return _menuHandler; }
            set
            {
                _menuHandler = value;
            }
        }

        private string _url = string.Empty;
        public string URL
        {
            get { return _url; }
            set { _url = value; }
        }
        #endregion
    }
}
