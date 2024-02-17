package br.odb.gamerendering.rendering;

import java.util.ArrayList;

import br.odb.gamerendering.rendering.animation.Animation;
import br.odb.gameutils.Rect;
import br.odb.gameutils.Updatable;
import br.odb.gameutils.math.Vec2;

public abstract class RenderingNode implements Updatable {

	ArrayList<RenderingNode> subnodes;
	final public Rect bounds = new Rect();
	boolean visible = true;
	final public Vec2 translate = new Vec2(0.0f, 0.0f);
	final public Vec2 scale = new Vec2(1.0f, 1.0f);
	public float alpha = 1.0f;
	Animation animation;
	final public String id;

	public RenderingNode(String id) {
		this.id = id;
	}

	public float getWidth() {
		return bounds.getDX();
	}

	public float getHeight() {
		return bounds.getDY();
	}

	public void setVisible(boolean visible) {
		this.visible = visible;
	}

	public boolean isVisible() {
		return visible;
	}
	
	public void addAnimation( Animation animation ) {
		this.animation = animation;
	}

	@Override
	public void update(long ms) {

		if (animation != null) {
			animation.update(ms);
			if (!animation.isActive()) {
				animation.kill();
			}
		}
	}

	public boolean isInside(Vec2 point) {
		return bounds.isInside(point);
	}

	public abstract void render(RenderingContext rc);

	public void addSon(RenderingNode node) {

		if (subnodes == null) {
			subnodes = new ArrayList<RenderingNode>();
		}

		subnodes.add(node);
	}

	String getId() {
		return id;
	}
}
