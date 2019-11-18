package example;
import Helpers.XmlHelper;
import Interfaces.IDeveloper;
import Models.Developer;

import javax.jws.WebMethod;
import javax.jws.WebResult;
import javax.jws.WebService;
import javax.xml.ws.Endpoint;
import java.util.Calendar;
import java.util.Date;

@WebService()
public class HelloWorld {
  @WebResult
  public String sayHelloWorldFrom(String from) {
    Developer dev = new Developer("Zygimantas Gudanis");
    return XmlHelper.ToXml((Developer)dev);
  }
  public static void main(String[] argv) {
    Object implementor = new HelloWorld();
    String address = "http://localhost:9000/HelloWorld"; //http://localhost:9000/HelloWorld?wsdl
    Endpoint.publish(address, implementor);
  }
}
