using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Task2.Client
{
    public class Startup
    {
        public void HttpRequest()
        {
            var url = "http://localhost:9000/HelloWorld?wsdl";

            var developer = RequestDeveloper();
        }

        public Developer RequestDeveloper()
        {
            HttpWebRequest request = CreateWebRequest();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(
                @$"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:exam=""http://example/"">
                        <soapenv:Body>
                          <exam:sayHelloWorldFrom>
                             <arg0>?</arg0>
                          </exam:sayHelloWorldFrom>
                        </soapenv:Body>
                    </soapenv:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    var xml = new XmlDocument();
                    xml.LoadXml(soapResult);
                    Console.WriteLine(xml.InnerText);
                    return XmlDeserializeFromString(xml.InnerText, typeof(Developer)) as Developer;
                }
            }
        }
        public HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:9000/HelloWorld.asmx?wsdl");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        public object XmlDeserializeFromString( string objectData, Type type)
        {
            var serializer = new XmlSerializer(type);
            object result;

            using (TextReader reader = new StringReader(objectData))
            {
                result = serializer.Deserialize(reader);
            }

            return result;
        }
    }
}
