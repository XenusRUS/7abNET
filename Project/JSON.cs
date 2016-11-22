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

namespace SerializationJSON
{
    [DataContract]
    public class Tank
    {
        [DataMember]
        public string TankName { get; set; }
        [DataMember]
        public string Country { get; set; }

		public Tank(string tankName, string country)
        {
            TankName = tankName;
			Country = country;
        }
    }
    class JSONs
    {
        public void Serialize()
        {
            // объект для сериализации
			Tank tank1 = new Tank("Т-34", "USSR");
            Tank tank2 = new Tank("Cromwell", "GB");
			Tank[] tanks = new Tank[] { tank1, tank2 };

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Tank[]));

            using (FileStream fs = new FileStream("tanks.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, tanks);
            }

        }
        public void Deserialize()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Tank[]));
            using (FileStream fs = new FileStream("tanks.json", FileMode.OpenOrCreate))
            {
                Tank[] newTanks = (Tank[])jsonFormatter.ReadObject(fs);

				foreach (Tank p in newTanks)
                {
                    Console.WriteLine("Танк: {0} --- Страна: {1}", p.TankName, p.Country);
                }
            }
        }

    }
}