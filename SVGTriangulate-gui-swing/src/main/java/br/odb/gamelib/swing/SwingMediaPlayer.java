/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package br.odb.gamelib.swing;

import br.odb.gameapp.AbstractMediaPlayer;
import java.applet.AudioClip;

/**
 *
 * @author monty
 */
public class SwingMediaPlayer implements AbstractMediaPlayer {
    AudioClip clip;

    SwingMediaPlayer(AudioClip clip) {
        this.clip = clip;
    }


    public void play() {
        clip.play();
    }


    public void loop() {
        clip.loop();
    }


    public void stop() {
        clip.stop();
    }    
}
