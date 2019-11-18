using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Task2.Client
{
    public class Developer
    {
        [XmlElement("fullName")]
        public string FullName { get; set; }
        [XmlElement("isMarried")]
        public bool IsMarried { get; set; }
        [XmlElement("currentProjects")]
        public List<Project> CurrentProjects { get; set; }
    }
}
