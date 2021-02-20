using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LibraryGenius;
using System.Threading;

namespace CodeGenius
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
            //Application.Run(new TemplateManage());
            Application.ThreadException += new ThreadExceptionEventHandler(Program.Application_ThreadException);

            AssemblyHelper.InitializeToolStripAssembly();

            //MainFormOld app = MainFormOld.GetInstance();
            //Application.Run(app);
            Application.Run( MainFormDX.Instance);
            //if (app.mutex != null)
            //{
            //    Application.Run(app);
            //}
            //else
            //{
            //    MsgBox.ShowInformation("程序已经有一个实例在运行！");
            //}
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs ex)
        {
            LogHelper.Error(ex.Exception);
            string message = string.Format("{0}\r\n操作發生錯誤，是否需要退出系統？", ex.Exception.Message);
            if (DialogResult.Yes == MsgBox.ShowYesNoError(message))
            {
                Application.Exit();
            }
        }
    }
}
