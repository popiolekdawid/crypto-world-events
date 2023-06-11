package com.soapsoapsoap;
import javax.jws.WebService;
import java.time.Duration;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
@WebService(endpointInterface = "com.soapsoapsoap.MyFirstSOAPInterface")
public class MyFirstWS implements MyFirstSOAPInterface{
    public String getHelloWorldAsString(String nazwa) {
        String message = "Witaj "+nazwa+"!";
        return message;
    }
    public double getAverage(double price1,double price2,double price3,double price4,double price5,double price6,double price7) {
        double avg = (price1+price2+price3+price4+price5+price6+price7)/7;

        return avg;
    }
}