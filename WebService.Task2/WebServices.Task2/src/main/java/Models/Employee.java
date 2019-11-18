package Models;

import Interfaces.IEmployee;

import javax.annotation.Resource;
import javax.xml.bind.annotation.XmlElement;
import java.util.Date;

public class Employee implements IEmployee {
    @XmlElement
    String FullName = null;
    @XmlElement
    Date BirthDay = null;
    @XmlElement
    Boolean IsMarried = null;
    private void ST() {
        FullName = "Hello";
    }
}
