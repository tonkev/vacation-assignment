using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightProvoker : MonoBehaviour {

    public Transform owner;

    public Vector3 velocity {
        get { return _velocity; }
    }

    Vector3 prevPosition;
    Vector3 _velocity = Vector3.zero;

    public void Start() {
        prevPosition = transform.position;
    }

    public void FixedUpdate() {
        _velocity = (transform.position - prevPosition) / Time.fixedDeltaTime;
        prevPosition = transform.position;
    }

    public bool IsRelated(Transform other) {
        Transform parent = other;
        while (parent != owner) {
            if (parent.parent == null)
                return false;
            parent = parent.parent;
        }
        return true;
    }
}
