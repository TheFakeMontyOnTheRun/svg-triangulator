/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package br.odb.svgtriangulate;

import java.awt.Color;

/**
 *
 * @author monty
 */
class SwingUtils {

    static Color getSwingColor(br.odb.utils.Color color) {
        Color swingColor = new Color( color.r, color.g, color.b );
        
        return swingColor;
    }
    
}