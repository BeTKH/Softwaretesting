/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package cookyourlasagna;

/**
 *
 * @author Beck
 */
public class Lasagna {
    
    
    public int expectedMinutesInOven(){
    
        return 40;
    }
    
    
    public int preparationTimeInMinutes(int numberOfLayers){
        
        return numberOfLayers * 2;
    }
    
    
    public int totalTimeInMinutes(int numberOfLayers, int actualMinutes){
    
        return numberOfLayers * 2 + actualMinutes;
        
    }
}
