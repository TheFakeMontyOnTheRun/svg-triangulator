package br.odb.gamerendering.rendering;

import java.util.ArrayList;

public class Animation implements Runnable {
	boolean running = false;
	private int framesPerSecond;
	private ArrayList<RenderingNode> frames;
	private int currentFrame;
	private boolean loop;
	private Thread controller;

	public Animation() {
		frames = new ArrayList<RenderingNode>();
		currentFrame = 0;
		loop = true;
		framesPerSecond = 24;
		controller = null;
	}

	@Override
	public void run() {
		while (running) {
			tick();
		}
	}

	/**
	 * @param framesPerSeconds
	 *            the framesPerSeconds to set
	 */
	public void setFramesPerSecond(int framesPerSeconds) {
		this.framesPerSecond = framesPerSeconds;
	}

	/**
	 * @return the framesPerSeconds
	 */
	public int getFramesPerSecond() {
		return framesPerSecond;
	}

	/**
	 * @param frames
	 *            the frames to set
	 */
	public void setFrames(ArrayList<RenderingNode> frames) {
		this.frames = frames;
	}

	/**
	 * @return the frames
	 */
	public ArrayList<RenderingNode> getFrames() {
		return frames;
	}

	/**
	 * @param currentFrame
	 *            the currentFrame to set
	 */
	public void setCurrentFrame(int currentFrame) {
		this.currentFrame = currentFrame;
	}

	/**
	 * @return the currentFrame
	 */
	public int getCurrentFrame() {
		return currentFrame;
	}

	/**
	 * @param loop
	 *            the loop to set
	 */
	public void setLoop(boolean loop) {
		this.loop = loop;
	}

	/**
	 * @return the loop
	 */
	public boolean isLoop() {
		return loop;
	}

	public void addFrame(RenderingNode node ) {
		frames.add( node );

	}

	public RenderingNode getCurrentFrameReference() {
		return getFrameReference(currentFrame);
	}

	public void start() {
		running = true;
		controller = new Thread(this, "animation ticker");
		controller.start();
	}

	public RenderingNode getFrameReference(int i) {
		return frames.get(i);
	}

	public void tick() {
		currentFrame++;
		if (currentFrame == frames.size())
			currentFrame = 0;
	}

}
