/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package cookyourlasagna;

/**
 *
 * @author Beck
 */
public class CookYourLasagna {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        
        Lasagna las1 = new Lasagna();
        
        int mins = las1.totalTimeInMinutes(4, 8);
        
        System.out.println("total minutes required to cook is:"+mins);
        
        
    }
    
}
