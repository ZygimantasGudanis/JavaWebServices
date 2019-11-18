import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import javax.xml.bind.*;
import javax.xml.bind.JAXBException;
/**
 *
 * @author Žygimantas Gudanis
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Employee employee = new Employee();
        employee.setLastName("Dave");
        employee.setFirstName("Dave");
        employee.setId(42069L);
        employee.setWage(0.05f);
        try {

            convertToXml(employee);

            Employee unmarsheled = convertToPogo("./employee.xml");

            System.out.printf(unmarsheled.getFirstName());
        }
        catch (Exception ex)
        {
            System.out.println(ex);
        }
    }
    public static void convertToXml(Employee employee) throws JAXBException
    {
        JAXBContext context = JAXBContext.newInstance(Employee.class);
        Marshaller mar = context.createMarshaller();
        mar.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, Boolean.TRUE);
        mar.marshal(employee, new File("./employee.xml"));
    }

    public static Employee convertToPogo(String path)  throws IOException, JAXBException
    {
        JAXBContext context = JAXBContext.newInstance(Employee.class);
        return (Employee) context.createUnmarshaller()
                .unmarshal(new FileReader("./employee.xml"));
    }
}
