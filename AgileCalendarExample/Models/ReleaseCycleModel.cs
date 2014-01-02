﻿using AgileCalendarExample.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AgileCalendarExample.Models
{
    [XmlRoot(ElementName = "releaseCycle", Namespace = "urn:supperslonic:agileCalendar")]
    public class ReleaseCycleModel : IXmlSerializable
    {
        public static readonly CultureInfo cultureInfo = new CultureInfo(Resources.CultureInfo);
        private static readonly XmlSerializer serializer = new XmlSerializer(typeof(ReleaseCycleModel));

        public IList<AgileItemBase> Items { get; set; }

        #region Serialization Support

        public static ReleaseCycleModel GetRecord(string xml)
        {
            using (TextReader reader = new StringReader(xml))
            {
                ReleaseCycleModel result = serializer.Deserialize(reader) as ReleaseCycleModel;
                return result;
            }
        }

        public override string ToString()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ReleaseCycleModel));

            using (TextWriter writer = new StringWriter(ReleaseCycleModel.cultureInfo))
            {
                serializer.Serialize(writer, this);
                return writer.ToString();
            }
        }

        #endregion

        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            Assembly currentAssembly = Assembly.GetAssembly(typeof(ReleaseCycleModel));
            using (Stream xsdStream = currentAssembly.GetManifestResourceStream(currentAssembly.GetName() + ".AgileCalendar.xsd"))
                return XmlSchema.Read(xsdStream, null);
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            this.Items = new List<AgileItemBase>();

            string startNodeName = reader.Name;
            while (reader.Read())
            {
                if (!reader.IsStartElement())
                {
                    if (startNodeName == reader.Name)
                    {
                        reader.Read();//Set pointer to the next node
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }

                AgileItemBase item;
                switch (reader.Name)
                {
                    case "planning":
                        item = new Planning();
                        break;

                    case "sprint":
                        item = new Sprint();
                        break;

                    case "holiday":
                        item = new Holiday();
                        break;

                    case "vacation":
                        item = new Vacation();
                        break;

                    default:
                        throw new InvalidOperationException(string.Format(ReleaseCycleModel.cultureInfo, Resources.E_UnexpectedXmlElementWithParam, reader.Name));
                }

                item.ReadXml(reader);
                this.Items.Add(item);
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            foreach(AgileItemBase item in this.Items)
                item.WriteXml(writer);
        }

        #endregion
    }
}