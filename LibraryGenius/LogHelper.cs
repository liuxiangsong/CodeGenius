using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using log4net;
using System.Reflection;

namespace LibraryGenius
{
    public class LogHelper
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Debug(Exception ex)
        {
            Log.Debug(ex.Message, ex);
        }

        public static void Info(Exception ex)
        {
            Log.Info(ex.Message, ex);
        }

        public static void Warn(Exception ex)
        {
            Log.Warn(ex.Message, ex);
        }

        public static void Error(Exception ex)
        {
            Log.Error(ex.Message, ex);
        }

        public static void Fatal(Exception ex)
        {
            Log.Fatal(ex.Message, ex);
        }

        public static void Info(object message)
        {
            Log.Info(message);
        }

        //public static void Debug(object message, Exception ex)
        //{
        //    Log.Debug(message, ex);
        //}

        //public static void Warn(object message, Exception ex)
        //{
        //    Log.Warn(message, ex);
        //}

        //public static void Error(object message, Exception ex)
        //{
        //    Log.Error(message, ex);
        //}

        //public static void Info(object message, Exception ex)
        //{
        //    Log.Info(message, ex);
        //}
    }
}
