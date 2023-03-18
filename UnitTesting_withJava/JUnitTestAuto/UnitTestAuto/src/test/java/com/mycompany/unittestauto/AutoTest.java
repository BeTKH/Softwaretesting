/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/UnitTests/JUnit5TestClass.java to edit this template
 */


package com.mycompany.unittestauto;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.AfterAll;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

/**
 *
 * @author Beck
 */
public class AutoTest {
    
    public AutoTest() {
    }
    
    @BeforeAll
    public static void setUpClass() {
    }
    
    @AfterAll
    public static void tearDownClass() {
    }
    
    @BeforeEach
    public void setUp() {
    }
    
    @AfterEach
    public void tearDown() {
    }

    /**
     * Test of getModel method, of class Auto.
     * 
     * T1 test case - Auto( ) ++++
     */
    @Test
    public void testAutoT1() {
        
        Auto instance = new Auto();
        
        assertEquals("unknown", instance.getModel());
        assertEquals(0, instance.getMilesDriven());
        assertEquals(0.0, instance.getGallonsOfGas());
        // TODO review the generated test code and remove the default call to fail.
        //fail("The test case is a prototype.");
    }
    
    
    
    /**
     * Test of getModel method with arguments, of class Auto.
     * 
     * T2 test case - public Auto( startModel, startMilesDriven, double startGallonsOfGas )
     */
    @Test
    public void testAutoT2() {
      
        Auto instance = new Auto("Toyota",20,40.0);
       //JUnit
       // Model
       assertEquals("Toyota", instance.getModel());
       // Miles
       assertEquals(20, instance.getMilesDriven());
       //GallonsOfGas 
       assertEquals(40.0, instance.getGallonsOfGas());
    }
    
    
    
    
    
    /**
     * Test of setModel method with arguments, of class Auto.
     * 
     * T3 test case - setModel( String newModel )
     */
    @Test
    public void testSetModelT3() {
          Auto instance = new Auto();
        String newModel = "Ford";
     
        instance.setModel(newModel);
        //JUnit
        assertEquals("Ford", instance.getModel());
    }

    
    
    
    

    /**
     * Test of setMilesDriven method, of class Auto.
     * destroy setMilesDriven method by passing illegal argument value
     * 
     * T4 test case  - setMilesDriven( int newMilesDriven )
     */
    @Test
    public void testSeMilesDrivenFalse() {
        //IllegalArgumentException("Miles driven cannot be negative.");
        Auto instance = new Auto();
         try
        {
            instance.setMilesDriven(-1);
        }
        catch(IllegalArgumentException exp)
        {
               //JUnit
            assertTrue(exp.getMessage().contains("Miles driven cannot be negative."));
        }
        
    }
    
    
    
    
    
     /**
     * Test of setMilesDriven method, of class Auto.
     * 
     * T5 test case  - setGallonsOfGas( double newGallonsOfGas )
     */
    @Test
    public void setGallonsOfGasFalse() {
      //IllegalArgumentException("Gallons of gas cannot be negative.");
        Auto instance = new Auto();
        try
        {
            instance.setGallonsOfGas(-1);
        }
        catch(IllegalArgumentException exp)
        {
               //JUnit
            assertTrue(exp.getMessage().contains("Gallons of gas cannot be negative."));
        }
    }

    
   

    
    /**
     * Test of calculateMilesPerGallon method, of class Auto.
     * 
     * T6 test case  - calculateMilesPerGallon( )
     */
    @Test
    public void testCalculateMilesPerGallonT6() {
        
        Auto instance = new Auto("",0,30.0);
        double result = instance.calculateMilesPerGallon();
        assertEquals(0, result, 0.0001);   // what is the third arument for ? - tolerance for difference between actual and calculated value
  
    }
    
    
    
     /**
     * Test of calculateMilesPerGallon method, of class Auto.
     * 
     * T7 test case  - calculateMilesPerGallon( )
     */
    @Test
    public void testCalculateMilesPerGallonT4B() {
        
        Auto instance = new Auto("car",2000,50.0);
        double expResult = 40.0;
        double result = instance.calculateMilesPerGallon();
        assertEquals(expResult, result, 0.0001);  // what is the third arument for ? - tolerance for difference between actual and calculated value
  
    }
    
    
    
     /**
     * Test of toString method, of class Auto.
     * 
     * T8 test case  - toString( )
     */
    @Test
    public void testToString() {
        
        Auto instance = new Auto("Toyota", 2000, 27.0);
        String expResult = "Model: Toyota"
             + "\n miles driven: 2000" 
             + "\n gallons of gas: 27.0";
            
        String result = instance.toString();
        assertEquals(expResult, result);
        
    }
    
    
    
    // T9 test case  - equals( Object o )
    @Test
    public void testEqualsFalse() 
    {
       Object myObj = new Object();
       Auto myCar1 = new Auto("Ford",1000,25);
       
        
       boolean result = myCar1.equals(myObj);
       boolean expResult = false; 
       assertEquals(expResult, result);
      
    }
    

    
    
    

    
    // T10 test case  - equals( Object o )
    @Test
    public void testEqualsFalse2() {
       
       Auto myCar1 = new Auto("Toyota",1000,25);
       Auto myCar2 = new Auto("Ford",1000,25);
        
       boolean result = myCar1.equals(myCar2);
       boolean expResult = false;
        
       assertEquals(expResult, result);
      
    }
    
    
    

    
     /**
     * Test of equals method, of class Auto.
     * 
     * T11 test case  - equals( Object o )
     */
    @Test
    public void testEqualsTrue() {
       
        Auto myCar1 = new Auto("Ford",1000,25);
        Auto myCar2 = new Auto("Ford",1000,25);
        
       boolean result = myCar1.equals(myCar2);
       boolean expResult = true;
       assertEquals(expResult, result);
      
    }
    
}
