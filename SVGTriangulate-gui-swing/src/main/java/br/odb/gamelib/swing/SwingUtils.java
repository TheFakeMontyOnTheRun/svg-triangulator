/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package br.odb.gamelib.swing;

import java.awt.Color;

/**
 *
 * @author monty
 */
class SwingUtils {

    static Color getSwingColor(br.odb.gameutils.Color color) {
        Color swingColor = new Color( color.r, color.g, color.b, color.a );
        
        return swingColor;
    }
    
}
