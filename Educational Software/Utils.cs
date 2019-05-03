using Microsoft.Win32;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Educational_Software
{
    public static class Utils
    {
        //changes webbrowser-control's default version of IE 7 to the installed version
        public static void fixEmulatedIEVersion()
        {
            int BrowserVer, RegVal;

            // get the installed IE version
            using (WebBrowser Wb = new WebBrowser())
                BrowserVer = Wb.Version.Major;

            // set the appropriate IE version
            if (BrowserVer >= 11)
                RegVal = 11001;
            else if (BrowserVer == 10)
                RegVal = 10001;
            else if (BrowserVer == 9)
                RegVal = 9999;
            else if (BrowserVer == 8)
                RegVal = 8888;
            else
                RegVal = 7000;

            // set the actual key
            using (RegistryKey Key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", RegistryKeyPermissionCheck.ReadWriteSubTree))
                if (Key.GetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe") == null)
                    Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, RegistryValueKind.DWord);
        }

        public static void forEachNode(this TreeView rootNode, Action<TreeNode> action)
        {
            foreach (TreeNode child in rootNode.Nodes)
                child.forEachNode(action);
        }

        public static void forEachNode(this TreeNode node, Action<TreeNode> action)
        {
            action(node);
            foreach (TreeNode child in node.Nodes)
                child.forEachNode(action);
        }

        // ScintillaNET styles for Python, modified from https://gist.github.com/jacobslusser/29c10e73a8d4baf3745a#file-pythonrecipe-cs
        public static void configureStylesForPython(this Scintilla scintilla)
        {
            // Reset the styles
            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Default].Font = "Consolas";
            scintilla.Styles[Style.Default].Size = 12;
            scintilla.Styles[Style.Default].BackColor = Color.Cornsilk;
            scintilla.StyleClearAll(); // i.e. Apply to all

            // Set the lexer
            scintilla.Lexer = Lexer.Python;

            // Line numbers
            scintilla.Margins[0].Width = 22;
            scintilla.Margins[0].Type = MarginType.Number;
            scintilla.Margins[0].Sensitive = false;
            scintilla.Styles[Style.LineNumber].BackColor = Color.LightBlue;

            // Some space between line numbers and code
            scintilla.Margins[1].Width = 5;
            scintilla.Margins[1].Type = MarginType.Color;
            scintilla.Margins[1].Sensitive = false;
            scintilla.Margins[1].BackColor = Color.LightGray;

            // Set the styles
            scintilla.Styles[Style.Python.Default].ForeColor = Color.FromArgb(0x80, 0x80, 0x80);
            scintilla.Styles[Style.Python.CommentLine].ForeColor = Color.FromArgb(0x00, 0x7F, 0x00);
            scintilla.Styles[Style.Python.CommentLine].Italic = true;
            scintilla.Styles[Style.Python.Number].ForeColor = Color.FromArgb(0x00, 0x7F, 0x7F);
            scintilla.Styles[Style.Python.Number].Bold = true;
            scintilla.Styles[Style.Python.String].ForeColor = Color.FromArgb(0x7F, 0x00, 0x7F);
            scintilla.Styles[Style.Python.Character].ForeColor = Color.FromArgb(0x7F, 0x00, 0x7F);
            scintilla.Styles[Style.Python.Word].ForeColor = Color.FromArgb(0x00, 0x00, 0x7F);
            scintilla.Styles[Style.Python.Word].Bold = true;
            scintilla.Styles[Style.Python.Triple].ForeColor = Color.FromArgb(0x7F, 0x00, 0x00);
            scintilla.Styles[Style.Python.TripleDouble].ForeColor = Color.FromArgb(0x7F, 0x00, 0x00);
            scintilla.Styles[Style.Python.ClassName].ForeColor = Color.FromArgb(0x00, 0x00, 0xFF);
            scintilla.Styles[Style.Python.ClassName].Bold = true;
            scintilla.Styles[Style.Python.DefName].ForeColor = Color.Orange;
            scintilla.Styles[Style.Python.DefName].Bold = true;
            scintilla.Styles[Style.Python.Operator].Bold = true;
            scintilla.Styles[Style.Python.CommentBlock].ForeColor = Color.FromArgb(0x7F, 0x7F, 0x7F);
            scintilla.Styles[Style.Python.CommentBlock].Italic = true;
            scintilla.Styles[Style.Python.StringEol].ForeColor = Color.FromArgb(0x00, 0x00, 0x00);
            scintilla.Styles[Style.Python.StringEol].BackColor = Color.FromArgb(0xE0, 0xC0, 0xE0);
            scintilla.Styles[Style.Python.StringEol].FillLine = true;
            scintilla.Styles[Style.Python.Word2].ForeColor = Color.FromArgb(0x40, 0x70, 0x90);
            scintilla.Styles[Style.Python.Decorator].ForeColor = Color.FromArgb(0x80, 0x50, 0x00);

            // Keyword lists:
            // 0 "Keywords",
            // 1 "Highlighted identifiers"
            var keywords = "and as assert break class continue def del elif else except exec finally for from global if import in is lambda not or pass print raise return try while with yield";
            scintilla.SetKeywords(0, keywords);
            scintilla.SetKeywords(1, "None True False");
            scintilla.Styles[Style.Python.Word2].ForeColor = Color.DarkOrange;
        }

        // https://github.com/jacobslusser/ScintillaNET/wiki/Find-and-Highlight-Words
        public static void highlightWord(this Scintilla scintilla, string word, Color color)
        {
            // Indicators 0-7 could be in use by a lexer
            // so we'll use indicator 8 to highlight words.
            const int NUM = 8;

            // Remove all uses of our indicator
            scintilla.IndicatorCurrent = NUM;
            scintilla.IndicatorClearRange(0, scintilla.TextLength);

            // Update indicator appearance
            scintilla.Indicators[NUM].Style = IndicatorStyle.StraightBox;
            scintilla.Indicators[NUM].ForeColor = color;
            scintilla.Indicators[NUM].OutlineAlpha = 50;
            scintilla.Indicators[NUM].Alpha = 30;

            // Search the document
            scintilla.TargetStart = 0;
            scintilla.TargetEnd = scintilla.TextLength;
            scintilla.SearchFlags = SearchFlags.None;
            while (scintilla.SearchInTarget(word) != -1)
            {
                // Mark the search results with the current indicator
                scintilla.IndicatorFillRange(scintilla.TargetStart, scintilla.TargetEnd - scintilla.TargetStart);
                // Search the remainder of the document
                scintilla.TargetStart = scintilla.TargetEnd;
                scintilla.TargetEnd = scintilla.TextLength;
            }
        }
    }
}
