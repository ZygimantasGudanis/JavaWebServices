import javax.xml.*;
import javax.xml.bind.annotation.*;

@XmlRootElement(name="Employee")
@XmlType(propOrder = { "id", "firstName", "lastName", "wage" })
public class Employee
{
    private Long id;
    private String firstName;
    private String lastName;
    private float wage;
    @XmlAttribute
    public void setId(Long id)
    {
        this.id = id;
    }
    public Long getId()
    {
        return id;
    }

    public void setFirstName(String firstName)
    {
        this.firstName = firstName;
    }
    public String getFirstName ()
    {
        return firstName;
    }

    public void setLastName(String lastName)
    {
        this.lastName = lastName;
    }
    public String getLastName()
    {
        return firstName;
    }

    public void setWage(float wage)
    {
        this.wage = wage;
    }
    public float getWage()
    {
        return wage;
    }
}
