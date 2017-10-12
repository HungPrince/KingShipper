using System;
using System.IO;
using System.Text;

namespace KingShipper.Library
{
    public class FileUtility
    {
        /// <summary>
        /// Append string to text file
        /// </summary>
        /// <param name="strContent"></param>
        /// <param name="uploadPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool AppendToTextFile(string strContent, string uploadPath, string fileName)
        {
            bool result = true;
            try
            {
                var byteArray = Encoding.UTF8.GetBytes(strContent);
                var stream = new MemoryStream(byteArray);
                var filePath = Path.Combine(uploadPath, fileName);
                var dir = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                if (!File.Exists(filePath))
                {
                    var fs = File.Create(filePath);
                    fs.Close();
                }

                StreamWriter sw = File.AppendText(filePath);
                sw.WriteLine(strContent);
                // Writing a string directly to the file
                sw.Close();
            }
            catch (Exception exception)
            {
                result = false;
                Console.Write(exception.ToString());
            }
            return result;


        }
        /// <summary>
        /// Append string to text file
        /// </summary>
        /// <param name="strContent"></param>
        /// <param name="uploadPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool AppendToNextTextFile(string strContent, string uploadPath, string fileName)
        {
            bool result = true;
            try
            {
                var byteArray = Encoding.UTF8.GetBytes(strContent);
                var stream = new MemoryStream(byteArray);
                var filePath = Path.Combine(uploadPath, fileName);
                var dir = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                if (!File.Exists(filePath))
                {
                    var fs = File.Create(filePath);
                    fs.Close();
                }

                StreamWriter sw = File.AppendText(filePath);
                sw.Write(strContent);
                // Writing a string directly to the file
                sw.Close();
            }
            catch (Exception exception)
            {
                result = false;
                Console.Write(exception.ToString());
            }
            return result;


        }
        /// <summary>
        /// Write file
        /// </summary>
        /// <param name="strContent"></param>
        /// <param name="uploadPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool WriteTextFile(string strContent, string uploadPath, string fileName)
        {
            bool result = true;
            try
            {
                var byteArray = Encoding.UTF8.GetBytes(strContent);
                var stream = new MemoryStream(byteArray);
                var filePath = Path.Combine(uploadPath, fileName);
                var dir = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                if (!File.Exists(filePath))
                {
                    var fs = File.Create(filePath);
                    fs.Close();
                }

                StreamWriter sw = File.CreateText(filePath);
                sw.Write(strContent);
                // Writing a string directly to the file
                sw.Close();
            }
            catch (Exception exception)
            {
                result = false;
                Console.Write(exception.ToString());
            }
            return result;
        }

        public static string ReadTextFile(string filePath)
        {
            var result = string.Empty;
            if (!File.Exists(filePath))
            {
                //ExceptionHandler.Handle(new Exception("File not found:" + filePath));
                return result;
            }
            try
            {
                var file = new StreamReader(filePath);
                result = file.ReadToEnd();
                file.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return result;
        }
    }
}
