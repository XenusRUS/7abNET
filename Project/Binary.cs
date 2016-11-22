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

namespace SerializationBinary
{
    [Serializable]
    class Tank
    {
        public string TankName { get; set; }
		public string Country { get; set; }

		public Tank(string tankName, string country)
        {
			TankName = tankName;
			Country = country;
        }
    }

    class Binarys
    {
        public void Serialize()
        {
            // объект для сериализации
			Tank person = new Tank("Т-34", "USSR");
            Console.WriteLine("Объект создан");
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
                Console.WriteLine("Объект сериализован");
            }
        }
        public void Deserialize()
        {
            // десериализация из файла people.dat
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Tank newTank = (Tank)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
				Console.WriteLine("Танк: {0} --- Страна: {1}", newTank.TankName, newTank.Country);
            }
        }
    }
}