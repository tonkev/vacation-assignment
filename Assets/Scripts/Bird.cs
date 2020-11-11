using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SoundListener))]
public class Bird : MonoBehaviour {

    enum BirdState { Standing, Flying, Landing }

    public float traversalRadius = 10f;
    public float maxSpeed = 10f;
    public float acceleration = 1f;
    public float deceleration = 0.5f;

    bool isGrounded = false;
    bool isScared = false;
    Vector3 velocity = Vector3.zero;

    bool traversalTargetValid = false;
    Vector3 traversalTarget = Vector3.zero;
    Vector3 traversalCenter = Vector3.zero;
    Vector3 traversalReturn = Vector3.zero;

    BirdState state = BirdState.Flying;
    BirdState prevState = BirdState.Standing;

    Animator anim;

    void Start() {
        traversalCenter = transform.position;
        traversalReturn = transform.position;
        anim = GetComponent<Animator>();
        MovementSight ms = GetComponentInChildren<MovementSight>();
        if (ms)
            ms.onMovementSightTrigger += OnMovementSightEnter;
        SoundListener sl = GetComponent<SoundListener>();
        if (sl)
            sl.onListenSound += OnListenSound;
    }

    void FixedUpdate() {
        if (prevState != state) {
            anim.SetTrigger(state.ToString());
            prevState = state;
        }

        Vector3 diff = Vector3.zero;
        switch (state) {
            case BirdState.Standing:
                if (!isGrounded || isScared) {
                    isScared = false;
                    state = BirdState.Flying;
                    traversalTargetValid = false;
                    Vector2 rng = Random.insideUnitCircle * traversalRadius;
                    traversalTarget = traversalCenter;
                    traversalTarget.x += rng.x;
                    traversalTarget.z += rng.y;
                }
                break;
            case BirdState.Flying:
                diff = traversalReturn - transform.position;
                velocity += diff.normalized * acceleration * Time.fixedDeltaTime;
                if (!traversalTargetValid)
                    AttemptGenerateTraversalTarget();
                else if (diff.sqrMagnitude < 0.1f) {
                    state = BirdState.Landing;
                }
                break;
            case BirdState.Landing:
                diff = traversalTarget - transform.position;
                if (isGrounded) {
                    state = BirdState.Standing;
                    velocity = Vector3.zero;
                }
                break;
        }

        Debug.DrawLine(transform.position, transform.position + diff);
        velocity += diff.normalized * acceleration * Time.fixedDeltaTime;
        float projectedVelocityOnDiff = Mathf.Clamp(Vector3.Dot(diff.normalized, velocity), 0, maxSpeed);
        Vector3 unprojectedVelocity = velocity - (diff.normalized * projectedVelocityOnDiff);
        Vector2 sign = Vector2.zero;
        sign.x = Mathf.Sign(unprojectedVelocity.x);
        sign.y = Mathf.Sign(unprojectedVelocity.z);
        unprojectedVelocity -= unprojectedVelocity.normalized * deceleration * Time.fixedDeltaTime;
        if (sign.x - Mathf.Sign(unprojectedVelocity.x) > 0.1f)
            unprojectedVelocity.x = 0f;
        if (sign.y - Mathf.Sign(unprojectedVelocity.z) > 0.1f)
            unprojectedVelocity.z = 0f;
        velocity = (diff.normalized * projectedVelocityOnDiff) + unprojectedVelocity;
        transform.position += velocity * Time.fixedDeltaTime;

        if (velocity.sqrMagnitude > 0.1f) {
            Vector3 dir = velocity;
            dir.y = 0;
            transform.rotation = Quaternion.LookRotation(dir);
        }

        SnapToGround();

    }

    void OnTriggerEnter(Collider collider) {
        if (state == BirdState.Standing) {
            Flags flags = collider.gameObject.GetComponent<Flags>();
            if (flags && flags.scaresBird) {
                isScared = true;
            }
        }
    }

    void OnMovementSightEnter(Transform other) {
        if (state == BirdState.Standing) {
            Flags flags = other.gameObject.GetComponent<Flags>();
            if (flags && flags.scaresBird) {
                isScared = true;
            }
        }
    }

    void OnListenSound(Sound sound) {
        if (state == BirdState.Standing) {
            isScared = true;
        }
    }

    void AttemptGenerateTraversalTarget() {
        Vector2 rng = Random.insideUnitCircle * traversalRadius;
        traversalTarget = traversalCenter;
        traversalTarget.x += rng.x;
        traversalTarget.z += rng.y;
        RaycastHit hit;
        traversalTargetValid = Physics.Raycast(traversalTarget, Vector3.down, out hit, float.MaxValue, LayerMask.GetMask("Ground"));
        if (traversalTargetValid)
            traversalTarget = hit.point;
    }

    void SnapToGround() {
        Vector3 start = transform.TransformPoint(0f, 0.1f, 0f);
        RaycastHit hit;
        isGrounded = Physics.Raycast(start, Vector3.down, out hit, 0.2f, LayerMask.GetMask("Ground")) && velocity.y <= 0;
        if (isGrounded) {
            transform.position = hit.point;
            velocity.y = 0;
        }
    }
}
