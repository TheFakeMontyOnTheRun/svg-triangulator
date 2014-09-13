/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.odb.svgtriangulate;

import br.odb.gamerendering.rendering.RenderingContext;
import br.odb.gamerendering.rendering.RenderingNode;
import br.odb.gamerendering.rendering.SVGRenderingNode;
import br.odb.libsvg.ColoredPolygon;
import br.odb.libsvg.SVGGraphic;
import br.odb.utils.Color;
import br.odb.utils.math.Vec2;

/**
 *
 * @author monty
 */
public class Iso3DSVGRenderingNode extends SVGRenderingNode {

    public Iso3DSVGRenderingNode(SVGGraphic graphic, String id) {
        super(graphic, id);
    }
    
    String selected = "";

    @Override
    public void render(RenderingContext rc) {

        String style = null;

        for (ColoredPolygon cp : graphic.shapes) {

            if (cp.visible) {

                ColoredPolygon cp3D = new ColoredPolygon();
                
                cp3D.color = new Color( cp.color );

                for (int c = 0; c < cp.npoints; ++c) {

                    cp3D.addPoint(400 + cp.xpoints[ c] + cp.z, 400 + cp.ypoints[ c] - cp.xpoints[ c] + cp.z );
                }

                if ( selected != null && cp.id.equals( selected ) ) {
                    style = "fill:none";
                } else {
                    style = null;
                }
                    
                
                
                rc.drawColoredPolygon(cp3D, bounds, style,
                        graphic.gradients);

                
                
                cp3D = new ColoredPolygon();
                
                cp3D.color = new Color( cp.color );

                for (int c = 0; c < cp.npoints; ++c) {

                    cp3D.addPoint(400 + cp.xpoints[ c], 400 + cp.ypoints[ c] - cp.xpoints[ c] );
                    
                    
                    rc.drawLine( new Vec2( 400 + cp.xpoints[ c], 400 + cp.ypoints[ c] - cp.xpoints[ c] ), new Vec2( 400 + cp.xpoints[ c] + cp.z, 400 + cp.ypoints[ c] - cp.xpoints[ c] + cp.z ) );
                }

                style = null;
                
                rc.drawColoredPolygon(cp3D, bounds, style,
                        graphic.gradients);
                
            }

        }
    }
}
