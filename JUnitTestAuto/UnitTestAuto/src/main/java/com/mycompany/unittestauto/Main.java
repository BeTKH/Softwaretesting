/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.mycompany.unittestauto;

/**
 *
 * @author Beck
 */
public class Main {
    
    
    public static void main(String args []){
    
    
    Auto car1 = new Auto("Ford", 40, 40.0);
    
    String CarModel = car1.getModel();
    
    System.out.println("The car model is: "+CarModel);
    System.out.println("The milesdriven is  is: "+car1.getMilesDriven());
    System.out.println("The gallons is  is: "+car1.getGallonsOfGas());
    
    }
            
    
    
    
}
