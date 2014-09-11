/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package br.odb.svgtriangulate;

import br.odb.gameapp.AbstractMediaPlayer;
import java.applet.AudioClip;

/**
 *
 * @author monty
 */
public class SwingMediaPlayer extends AbstractMediaPlayer {
    AudioClip clip;

    SwingMediaPlayer(AudioClip clip) {
        this.clip = clip;
    }

    @Override
    public void play() {
        clip.play();
    }

    @Override
    public void loop() {
        clip.loop();
    }

    @Override
    public void stop() {
        clip.stop();
    }    
}
