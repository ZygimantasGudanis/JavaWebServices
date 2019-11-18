package Interfaces;

import javax.xml.bind.annotation.XmlElement;
import java.util.ArrayList;
import java.util.List;

public interface IDeveloper extends IEmployee {
    List<IProject> currentProjects = new ArrayList<IProject>();
}
