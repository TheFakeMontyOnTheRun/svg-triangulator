/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package br.odb.svgtriangulate;


import br.odb.gamelib.swing.SwingCanvasRenderingContext;
import br.odb.gamerendering.rendering.DisplayList;
import br.odb.gamerendering.rendering.GameRenderer;
import br.odb.gamerendering.rendering.RenderingNode;
import br.odb.gamerendering.rendering.SolidSquareRenderingNode;
import br.odb.gameutils.Color;
import br.odb.gameutils.Rect;
import br.odb.gameutils.math.Vec2;
import java.awt.Graphics;

/**
 *
 * @author monty
 */
public class SVGViewJPanel extends javax.swing.JPanel {

    SwingCanvasRenderingContext renderingContext;
    private DisplayList renderingNode;
    private long renderingBudget;
    private GameRenderer gameRenderer;
    private RenderingNode defaultRenderingNode;
    protected RenderingNode selectedItem;
    protected boolean shouldFollowTarget;
    final Vec2 accScroll = new Vec2();
    final Vec2 lastTouchPosition = new Vec2();

    /**
     * Creates new form ExploreStationJPanel
     */
    public SVGViewJPanel() {
        initComponents();

        renderingContext = new SwingCanvasRenderingContext();
        gameRenderer = new GameRenderer();
        gameRenderer.setCurrentRenderingContext(renderingContext);
        defaultRenderingNode = new SolidSquareRenderingNode(new Rect(10, 10, 100, 100), new Color(255, 0, 0));
        renderingBudget = 1000;
    }

    protected RenderingNode getRenderingContent() {
        return renderingNode;
    }

    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);



        long t0 = System.currentTimeMillis();
        long tn = t0;

        renderingContext.prepareWithCanvas(g);

        if (renderingNode == null) {
            renderDefaultEmptyScreen();
            return;
        }

        this.getRenderingContent().translate.set(accScroll);

        renderingContext.currentOrigin.addTo(renderingNode.translate);

        gameRenderer.startRendering(renderingNode);

        while (gameRenderer.hasJobs() && ((tn - t0) < this.renderingBudget)) {
            gameRenderer.renderNext();
            tn = System.currentTimeMillis();
        }

        gameRenderer.resetRenderingContext();
        renderingContext.currentOrigin.addTo(renderingNode.translate.negated());

        tn = System.currentTimeMillis();
        if ((tn - t0) < this.renderingBudget) {
            try {
                Thread.sleep(this.renderingBudget - (tn - t0));
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    private void renderDefaultEmptyScreen() {
        if (defaultRenderingNode == null) {

            defaultRenderingNode = new SolidSquareRenderingNode( new Rect(100, 100, 200, 200), new Color(255, 255, 0));
        }
        gameRenderer.renderNode(defaultRenderingNode);

    }

    public void setRenderingContent(DisplayList displayList) {
        this.renderingNode = displayList;
    }

    public void setRenderingBudget(long milisseconds) {
        this.renderingBudget = milisseconds;
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        setBackground(new java.awt.Color(102, 0, 102));
        setForeground(new java.awt.Color(153, 0, 102));

        org.jdesktop.layout.GroupLayout layout = new org.jdesktop.layout.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(0, 400, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(0, 300, Short.MAX_VALUE)
        );
    }// </editor-fold>//GEN-END:initComponents
    // Variables declaration - do not modify//GEN-BEGIN:variables
    // End of variables declaration//GEN-END:variables

    public void setSelectedItem(RenderingNode node) {
        selectedItem = node;


        Vec2 translate = selectedItem.translate.scaled(-1.0f);
        Vec2 halfScreen = new Vec2(getWidth(), getHeight());
        halfScreen.scale(0.5f);

        translate.addTo(halfScreen);
        accScroll.set(translate);

        //accScroll.set(new Vec2(getWidth(), getHeight()).scaled(0.5f).add(selectedItem.translate.scaled(-1.0f)));
    }
}
