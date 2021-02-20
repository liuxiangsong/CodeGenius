using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TextTemplating;
using System.CodeDom.Compiler;

namespace CodeGenius.CodeEngine
{
    public class TemplateGenerator
    {
        private string m_ErrorMessage;
        /// <summary>
        /// 生成失敗時的錯誤提示信息
        /// </summary>
        public string ErrorMessage
        {
            get { return m_ErrorMessage; }
        }

        /// <summary>
        /// 按模版生成代碼
        /// </summary>
        /// <param name="templateContent">模版內容</param>
        /// <param name="host"></param>
        /// <returns>返回生成的內容。
        /// 注：生成失敗時返回String.Empty,錯誤內容賦值給屬性ErrorMessage</returns>
        public string Generate(string templateContent, TemplateHost host)
        {
            Engine engine = new Engine(); 
            //Transform the text template.
            string output = engine.ProcessTemplate(templateContent, host);
            StringBuilder sb = new StringBuilder();
            foreach (CompilerError error in host.Errors)
            {
                sb.AppendLine(error.ToString());
            }
            m_ErrorMessage = sb.ToString();
            if (host.Errors.Count>0)
                return string.Empty;
            return output;
        }
    }
}
