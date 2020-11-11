using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MovementSight : MonoBehaviour {

    public delegate void OnMovementSightTrigger(Transform other);

    public float triggerSpeed = 4.5f;
    public event OnMovementSightTrigger onMovementSightTrigger;

    void OnTriggerStay(Collider other) {
        SightProvoker sp = other.GetComponent<SightProvoker>();
        if (sp) {
            if (sp.velocity.magnitude >= triggerSpeed) {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (other.transform.position - transform.position).normalized, out hit, float.MaxValue)) {
                    if (sp.IsRelated(hit.transform)) {
                        onMovementSightTrigger(sp.owner);
                    }
                }
            }
        }
    }
}
