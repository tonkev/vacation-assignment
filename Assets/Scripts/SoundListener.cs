using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundListener : MonoBehaviour {

    public delegate void OnListenSound(Sound sound);
    public event OnListenSound onListenSound;

    public float radius = 1f;
    public Vector3 offset = Vector3.zero;

    public void Start() {
        SoundManager.Get().AddListener(this);
    }

    public void OnDestroy() {
        SoundManager.Get().RemoveListener(this);
    }

    public void Listen(Sound sound) {
        onListenSound(sound);
    }
}
