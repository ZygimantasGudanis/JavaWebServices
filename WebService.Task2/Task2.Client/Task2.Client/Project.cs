using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Task2.Client
{
    public class Project
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
