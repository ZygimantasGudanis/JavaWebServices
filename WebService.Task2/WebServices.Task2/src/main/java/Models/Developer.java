package Models;

import Interfaces.IDeveloper;
import Interfaces.IProject;

import javax.xml.bind.annotation.*;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@XmlRootElement(name="Developer")
@XmlType(propOrder = { "fullName", "birthDay", "isMarried", "currentProjects"})
@XmlAccessorType(XmlAccessType.FIELD)
public class Developer implements IDeveloper
{
    public String fullName = "";
    public Date birthDay = new Date();
    public Boolean isMarried = false;

    @XmlElement(type = Project.class)
    public List<IProject> currentProjects = new ArrayList<IProject>();

    public Developer(String fullName)
    {
        this.fullName = fullName;
        currentProjects = new ArrayList<IProject>();
        currentProjects.add(new Project("Project 1"));
        currentProjects.add(new Project("Project 2"));
    }
    public Developer() {}

    public String getFullName() {
        return fullName;
    }

    public Date getBirthDay() {
        return birthDay;
    }

    public Boolean getIsMarried() {
        return isMarried;
    }

    public List<IProject> getCurrentProjects() {
        return currentProjects;
    }

    public void setFullName(String FullName) {
        this.fullName = FullName;
    }

    public void setBirthDay(Date BirthDay) {
        this.birthDay = BirthDay;
    }

    public void setIsMarried(boolean IsMarried) {
        this.isMarried = IsMarried;
    }

    public void setCurrentProjects(List<IProject> CurrentProjects) {
        this.currentProjects = CurrentProjects;
    }
}
