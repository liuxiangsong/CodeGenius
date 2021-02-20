using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using WeifenLuo.WinFormsUI.Docking;
using Microsoft.VisualBasic;
using LibraryGenius;

namespace CodeGenius
{
    public partial class StringBuilderTool : DockContent
    {
        public StringBuilderTool()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (chkReverse.Checked == false)
            {
                this.GenerateStringBuilder();
            }
            else
            {
                GenerateString();
            }
        }

        private void GenerateStringBuilder()
        {
            string strBuilderName = this.txtSBObj.Text.Trim();
            string strTemp = "\");\rsb.AppendLine(\"";
            if (string.IsNullOrEmpty(strBuilderName) == false)
            {
                strTemp = strTemp.Replace("sb", strBuilderName);
            }
            string strBefore = this.rtxBefore.Text;
            string strAfter = this.rtxAfter.Text;
            try
            {
                string strBackslash = "[+=_9_(-_)7]";    //反斜杠
                string strQuotes = "{^s^8!(7)(6_=)}";    //双引号
                strAfter = strBefore.Replace("\\", strBackslash);   //把字符串\替换成strBackslash
                strAfter = strAfter.Replace("\"", strQuotes);      //把字符串"替换成strQuotes
                strAfter = strAfter.Replace("\r\n", "\r").Replace("\n", "\r");   //把\r\n替换为\r，把\n替换为\r
                strAfter = strAfter.Replace("\r", strTemp);
                strAfter = strTemp.Replace("\");\r", "") + strAfter + "\");";
                strAfter = strAfter.Replace("\"\"", "");
                strAfter = strAfter.Replace(strBackslash, "\\\\");        //还原成双反斜杠
                strAfter = strAfter.Replace(strQuotes, "\\\"");           //还原成反斜杠加双引号 
                this.rtxAfter.Text = strAfter.Replace("    ", "\\t");     //把四个空格换成Tab符
                this.rtxAfter.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerateString()
        {
            StringBuilder builder = new StringBuilder();
            string strBuilderName = this.txtSBObj.Text.Trim();
            string strTemp = "sb.AppendLine(\"";
            if (string.IsNullOrEmpty(strBuilderName) == false)
            {
                strTemp = strTemp.Replace("sb", strBuilderName);
            }
            string[] rows = this.rtxBefore.Lines;
            string strText = string.Empty;
            foreach (string str in rows)
            { 
                if (str.Trim().Length == 0) continue;
                if (str.Trim().StartsWith(strTemp.TrimEnd('"')) == false)
                {
                    MessageBox.Show("无法转化，请检查是否是反向生成\r或StringBuilder对象名称正确。");
                    return;
                }
                strText = str.Trim().Replace("\\\\", "\\").Replace("\\\"", "\"");
                if (str.Trim().StartsWith(strTemp) == true)
                {
                    strText = strText.Remove(strText.IndexOf(strTemp), strTemp.Length);
                    builder.AppendLine(strText.Remove(strText.LastIndexOf("\");")));
                }
                else
                {
                    strText = strText.Remove(strText.IndexOf(strTemp.TrimEnd('"')), strTemp.Length-1);
                    builder.AppendLine(strText.Remove(strText.LastIndexOf(");")));
                }
            }
            this.rtxAfter.Text = builder.ToString().Replace("\\t", "    ");  //把Tab符还原成四个空格
            this.rtxAfter.Focus();
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(rtxAfter.Text);            
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject() != null)
            {
                this.rtxBefore.Text = Clipboard.GetDataObject().GetData(DataFormats.UnicodeText).ToString();
            }
        }

        #region 调整剪贴板上的内容编码
        private void btnClipboardFix_Click(object sender, EventArgs e)
        {
            IDataObject dataObject = Clipboard.GetDataObject();
            if (dataObject.GetDataPresent(DataFormats.Rtf))
            {
                string data = dataObject.GetData(DataFormats.Rtf) as string;
                string str2 = Regex.Replace(data, @"\\uinput2(?<uc>\\u-?\d*)\s..", m => m.Groups["uc"].Value + "?");
                DataObject obj3 = new DataObject();
                foreach (string str3 in dataObject.GetFormats())
                {
                    obj3.SetData(str3, (str3 == "Rich Text Format") ? str2 : dataObject.GetData(str3));
                }
                Clipboard.SetDataObject(obj3, true);
            }
        }
        #endregion

        #region 简繁体转化
        private void btnChtToChs_Click(object sender, EventArgs e)
        {
            this.rtxAfter.Text = EncodingUtil.LanguageToSimplified(rtxBefore.Text);
        }

        private void btnChsToCht_Click(object sender, EventArgs e)
        {
            this.rtxAfter.Text = EncodingUtil.LanguageToTraditional(rtxBefore.Text);
        }

        //#region 繁體轉簡體
        //private static string LanguageToSimplified(String LanguageItem)
        //{
        //    return  Strings.StrConv(LanguageItem, VbStrConv.SimplifiedChinese, 0); 
        //}

        //private static string LanguageToTraditional(String LanguageItem)
        //{
        //    return Strings.StrConv(LanguageItem, VbStrConv.TraditionalChinese, 0);
        //}
        //#endregion

        private void btnTextCompare_Click(object sender, EventArgs e)
        {
            string message;
            if (this.rtxAfter.Text.Trim() == this.rtxBefore.Text.Trim())
            {
                message = "待转化文本与转化后文本内容【相同】";
            }
            else
            {
                message = "待转化文本与转化后文本内容【不相同】";
            }
            MessageBox.Show(message);
        }
        #endregion

    }
}
