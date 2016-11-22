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

namespace SerializationXML
{
    // класс и его члены объявлены как public
    [Serializable]
    public class Tank
    {
        public string TankName { get; set; }
		public string Country { get; set; }

        // стандартный конструктор без параметров
        public Tank()
        { }

		public Tank(string tankName, string country)
        {
            TankName = tankName;
			Country = country;
        }
    }
    class XMLs
    {
      public void Serialize()
        {
            // объект для сериализации
            Tank tank = new Tank("Т-34", "USSR");

            Console.WriteLine("Объект создан");

            // передаем в конструктор тип класса
            XmlSerializer formatter = new XmlSerializer(typeof(Tank));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("tanks.xml", FileMode.OpenOrCreate))
            {
				formatter.Serialize(fs, tank);

                Console.WriteLine("Объект сериализован");

            }          
        }

        public void Deserialize()
        {
            // десериализация
			XmlSerializer formatter = new XmlSerializer(typeof(Tank));

            using (FileStream fs = new FileStream("tanks.xml", FileMode.OpenOrCreate))
            {
				Tank newTank = (Tank)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
				Console.WriteLine("Танк: {0} --- Страна: {1}", newTank.TankName, newTank.Country);
            }
        }
    }
}