using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType { Footstep }

public struct Sound {
    public SoundType type;
    public Vector3 origin;
    public float radius;
    public GameObject emitter;
}

public class SoundManager {

    List<SoundListener> listeners;

    static SoundManager soundManager = null;

    private SoundManager() {
        listeners = new List<SoundListener>();
    }

    public void AddListener(SoundListener listener) {
        listeners.Add(listener);
    }

    public void RemoveListener(SoundListener listener) {
        listeners.Remove(listener);
    }

    public void EmitSound(Sound sound) {
        foreach (SoundListener listener in listeners) {
            if (listener.enabled) {
                Vector3 distance = sound.origin - (listener.transform.position + listener.offset);
                if (distance.magnitude < sound.radius + listener.radius)
                    listener.Listen(sound);
            }
        }
    }

    static public SoundManager Get() {
        if (soundManager == null)
            soundManager = new SoundManager();
        return soundManager;
    }

}
