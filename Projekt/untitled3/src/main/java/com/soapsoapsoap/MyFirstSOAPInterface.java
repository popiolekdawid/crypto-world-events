package com.soapsoapsoap;
import javax.jws.WebMethod;
import javax.jws.WebService;
import javax.jws.soap.SOAPBinding;
import javax.jws.soap.SOAPBinding.Style;
//Service Endpoint Interface
@WebService // oznaczenie klasy jako SEO (Service EndpointInterface)
@SOAPBinding(style = Style.RPC)
public interface MyFirstSOAPInterface{
    @WebMethod String getHelloWorldAsString(String name);
    @WebMethod double getAverage(double price1,double price2,double price3,double price4,double price5,double price6,double price7);
}
