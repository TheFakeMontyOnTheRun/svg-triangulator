package br.odb.gamerendering.rendering;

import java.util.HashMap;

import br.odb.libsvg.ColoredPolygon;
import br.odb.libsvg.SVGParsingUtils.Gradient;

public class PolygonRenderingNode extends RenderingNode {

    public ColoredPolygon cp;
    public HashMap<String, Gradient> gradients = new HashMap<String, Gradient>();

    public PolygonRenderingNode(ColoredPolygon cp,
            HashMap<String, Gradient> gradients) {

        super("PolygonRenderingNode_" + cp.id);
        this.cp = cp;
        this.gradients = gradients;
    }

    @Override
    public void render(RenderingContext rc) {
        rc.drawColoredPolygon(cp, bounds, null, gradients);
    }
}
