/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package br.odb.gamelib.swing;

import br.odb.gamerendering.rendering.RenderingContext;
import br.odb.libsvg.ColoredPolygon;
import br.odb.libsvg.SVGGraphic;
import br.odb.utils.Color;
import br.odb.utils.Rect;

/**
 *
 * @author monty
 */
public class TextureBaker {
    public static void render(RenderingContext rc, SVGGraphic graphic ) {
        Rect bounds = new Rect( 0, 0, 64, 64 );

        for (ColoredPolygon cp : graphic.shapes) {

            if (cp.visible) {

                ColoredPolygon cp3D = new ColoredPolygon();
                
                cp3D.color = new Color( cp.color );

                for (int c = 0; c < cp.npoints; ++c) {

                    cp3D.addPoint( 128 * cp.xpoints[ c ] / 800.0f, 128 * cp.ypoints[ c ] / 480.0f );
                }
                
                rc.drawColoredPolygon(cp3D, bounds, null,
                        graphic.gradients);
            }
        }
    }
}
