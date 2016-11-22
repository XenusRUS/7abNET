using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
//using System.Drawing;
using System.Windows;
using System.Web;
using System.Threading;
using System.Security;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Diagnostics;

namespace LogHelper
{
    public class LogException
    {
        private static object sync = new object();
        public static void Write(Exception ex)

		{
			try
			{
				// Путь .\\Log
				string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
				if (!Directory.Exists(pathToLog))
					Directory.CreateDirectory(pathToLog); // Создаем директорию, если нужно
				string filename = Path.Combine(pathToLog, string.Format(
				AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
				string fullText = string.Format("[{1}.{2}()] {3}\r\n",
				DateTime.Now, ex.TargetSite.DeclaringType, ex.TargetSite.Name, ex.Message);
				lock (sync)
				{
					File.AppendAllText(filename, fullText, Encoding.GetEncoding("Windows-1251"));
				}
			}
			catch
			{
				// Перехватываем все и ничего не делаем
			}
		}

        private int one=1;
        
        public void write_log()
        {
            File.AppendAllText("file.txt", DateTime.Now.ToString("открытие файла" + "\n"));
            File.AppendAllText("file.txt", DateTime.Now.ToString("ввели : " + Convert.ToString(one) + "\n"));
            Console.Write("ввели : {0}", one);
            File.AppendAllText("file.txt", DateTime.Now.ToString("закрытие файла" + "\n"));
        }
    }
}
