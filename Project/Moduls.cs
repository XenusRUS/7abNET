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

namespace Moduls
{
	public class body
	{
		public void bodyOutput()
		{
			Console.WriteLine("Корпус");
		}
	}
	public class track
	{
		public void trackOutput()
		{
			Console.WriteLine("Гусеница");
		}
	}
	public class tower
	{
		public void towerOutput()
		{
			Console.WriteLine("Башня");
		}
	}
	public class engine
	{
		public void engineOutput()
		{
			Console.WriteLine("Двигатель");
		}
	}
	public class transmission
	{
		public void transmissionOutput()
		{
			Console.WriteLine("Трансмиссия");
		}
	}
	public class weaponary
	{
		public void weaponaryOutput()
		{
			Console.WriteLine("Вооружение");
		}
	}
	public class communication
	{
		public void communicationOutput()
		{
			Console.WriteLine("Средства связи");
		}
	}
	public class surveillance
	{
		public void surveillanceOutput()
		{
			Console.WriteLine("Средства наблюдения");
		}
	}
	public abstract class crew
	{
		public void crewOutput()
		{
			Console.WriteLine("Экипаж: 5 человек");
		}
		abstract public void weaponsNumber();
	}

	public class Weapons : crew
	{
		public override void weaponsNumber()
		{
			Console.WriteLine("Количество вооружения: 2");
		}
	}

	class aboutTank
	{
		int crewNumber = 5;
		string tankName = "Tiger";
		public int crewNum
		{
			get
			{
				if (crewNumber <= 0)
					return 1;
				return crewNumber;
			}

			set
			{
				crewNumber = value;
			}
		}
		public string Name
		{
			get
			{
				return tankName;
			}
		}
	}
} // namespace MainProject