using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingShipper.Library
{
    public class ExceptionHandler
    {
        /// <summary>
        /// Handle Exception and write to log file
        /// </summary>
        /// <param name="ex">Exception object</param>
        public static void Handle(Exception ex)
        {
            Handle(ex, String.Empty, String.Empty);
        }
        /// <summary>
        /// Handle Exception and write to log file
        /// </summary>
        /// <param name="ex">Exception object</param>
        /// <param name="className">Name of class, where the error occurred.</param>
        public static void Handle(Exception ex, string className)
        {
            Handle(ex, className, String.Empty);
        }
        /// <summary>
        /// Handle Exception and write to log file
        /// </summary>
        /// <param name="ex">Exception object</param>
        /// <param name="className">Name of class, where the error occurred.</param>
        /// <param name="functionName">Name of function, where the error occurred.</param>
        public static void Handle(Exception ex, string className, string functionName)
        {
            Handle(ex, className, functionName, "LogErrors.txt");
        }
        public static void Handle(Exception ex, string className, string functionName, string logFile)
        {
            Console.WriteLine(ex.Message);
            //MessageBox.Show(ex.Message + ",class=" + className + ",func = " + functionName);
            var sb = new StringBuilder();
            sb.Append("Time: ");
            sb.Append(DateTime.Now);
            sb.Append("| class: ");
            sb.Append(className);
            sb.Append("| functionName: ");
            sb.Append(functionName);
            sb.Append("| Error: ");
            sb.Append(ex.Message);
            sb.AppendLine();
            sb.Append(ex.StackTrace);
            sb.AppendLine();
            sb.Append("---------------------");
            FileUtility.AppendToTextFile(sb.ToString(), Config.LogErrorFolder, logFile);
            //throw ex;
        }

        public static void Handle(Exception ex, bool deferLogFileName)
        {
            var logFile = "LogErrors.txt";
            if (deferLogFileName)
            {
                logFile = "LogErrors-" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".txt";
            }
            Handle(ex, String.Empty, String.Empty, logFile);
        }
    }
}
