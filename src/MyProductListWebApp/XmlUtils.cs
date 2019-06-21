using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MyProductListWebApp
{
    /// <summary>
    /// Utility methods for handling XML.
    /// </summary>
    public static class XmlUtils
    {
        /// <summary>
        /// Serializes an object to an Xml document
        /// </summary>		
        public static XmlDocument SerializeXml(Object obj)
        {
            if (obj == null)
                return null;

            //serialize the object
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (StreamWriter sw = new StreamWriter(memoryStream, Encoding.UTF8))
                {
                    XmlSerializer xs = new XmlSerializer(obj.GetType());
                    using (XmlWriter writer = XmlWriter.Create(sw))
                    {
                        xs.Serialize(writer, obj);
                    }

                    memoryStream.Position = 0;
                    using (XmlTextReader reader = new XmlTextReader(memoryStream))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(reader);

                        //strip document from extra xml nodes
                        doc.DocumentElement.RemoveAllAttributes();
                        string cleanXml = doc.DocumentElement.OuterXml;
                        doc = new XmlDocument();
                        doc.LoadXml(cleanXml);
                        return doc;
                    }
                }
            }
        }

        /// <summary>
        /// Deserializes an object from an Xml document
        /// </summary>
        public static Object DeserializeXml(XmlDocument doc, Type objectType)
        {
            //write doc into a stream and de-serialize from stream
            using (MemoryStream stream = new MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(stream))
                {
                    doc.Save(writer);
                    stream.Position = 0;
                    XmlSerializer ser = new XmlSerializer(objectType);
                    return ser.Deserialize(stream);
                }
            }
        }
    }
}