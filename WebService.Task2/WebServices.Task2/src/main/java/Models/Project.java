package Models;

import Interfaces.IProject;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

@XmlRootElement(name="Project")
@XmlType(propOrder = { "name"})
@XmlAccessorType(XmlAccessType.FIELD)
public class Project implements IProject {
    public String name = "";

    public Project(){}
    public Project(String name){
        this.name = name;
    }

    public String getName()
    {
        return name;
    }

    public void setName(String Name)
    {
        name = Name;
    }
}
