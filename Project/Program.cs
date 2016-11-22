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
using SerializationXML;
using SerializationJSON;
using SerializationBinary;
using Moduls;
using LogHelper;
using System.Diagnostics;

namespace MainProject
{
	class Read_config
	{
		public String line;
		public String lineText;
		public void read_file()
		{
			try
			{
				using (StreamReader _StreamReader = new StreamReader("tanks.txt"))
				{
					Console.WriteLine("Танк {0}", lineText);
					while (true)
					{
						line = _StreamReader.ReadLine();

						if (line == null)
							break;
						lineText = line;
						Console.WriteLine(" {0}", lineText);
					}
				}
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("Файл танка не найден");
				Console.ReadLine();
			}
			catch (Exception)
			{
				Console.WriteLine("Файл танка не может быть прочитан");
				Console.ReadLine();

			}

		}
	}

	// ////////////////////////////////////////////////////////Serializatio nXML JSON Binary
	class interface_ISerializer
	{
		public void Serialize()
		{
			Console.WriteLine("Сериализация XML");
			XMLs XML = new XMLs();
			XML.Serialize();
			Console.WriteLine("Сериализация JSON");
			JSONs JSON = new JSONs();
			JSON.Serialize();
			Console.WriteLine("Сериализация Binary");
			Binarys Binary = new Binarys();
			Binary.Serialize();
		}

		public void Deserialize()
		{
			Console.WriteLine("Десериализация XML");
			XMLs XML = new XMLs();
			XML.Deserialize();
			Console.WriteLine("Десериализация JSON");
			JSONs JSON = new JSONs();
			JSON.Deserialize();
			Console.WriteLine("Десериализация Binary");
			Binarys Binary = new Binarys();
			Binary.Deserialize();
		}

	}
	// ////////////////////////////////////////////////////////Serialization XML JSON Binary


	public class Windows
	{
		private static void Main(string[] args)
		{
			LogException newlog = new LogException();
			newlog.write_log();

			Console.WriteLine("Данные о танке:");
			body status1 = new body();
			status1.bodyOutput();
			track status2 = new track();
			status2.trackOutput();
			tower status3 = new tower();
			status3.towerOutput();
			engine status4 = new engine();
			status4.engineOutput();
			transmission status5 = new transmission();
			status5.transmissionOutput();
			weaponary status6 = new weaponary();
			status6.weaponaryOutput();
			communication status7 = new communication();
			status7.communicationOutput();
			surveillance status8 = new surveillance();
			status8.surveillanceOutput();
			Weapons status9 = new Weapons();
			status9.crewOutput();
			status9.weaponsNumber();

			aboutTank ui = new aboutTank();
			Read_config _Read_config = new Read_config();
			_Read_config.read_file();

			ui.crewNum = 5;
			Console.WriteLine("Экипаж");
			Console.WriteLine(ui.crewNum);
			Console.WriteLine("Название танка");
			Console.WriteLine(ui.Name);

			// ____________________________________________________________________Serialization XML JSON Binary
			try
			{
				interface_ISerializer ISerialize = new interface_ISerializer();
				ISerialize.Serialize();
				ISerialize.Deserialize();
			}
			catch (Exception)
			{
				Console.WriteLine("Не сработала сериализация");
				Console.ReadLine();
			}
			// ____________________________________________________________________Serialization XML JSON Binary


			Console.ReadLine();
		} 
	} 
} 