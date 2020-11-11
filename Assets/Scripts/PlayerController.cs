using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    const float GROUND_MAX_SPEED = 5f;
    const float GROUND_ACC = 10f;
    const float GROUND_DEACC = 20f;
    const float AIR_MAX_SPEED = 15f;
    const float AIR_ACC = 0f;
    const float AIR_DEACC = 0f;
    const float JUMP_SPEED = 5f;
    const float TERMINAL_SPEED = 50f;

    const float SIGHT_POINT_OFFSET_NORMAL = 1f;
    const float SIGHT_POINT_OFFSET_CROUCH = 0.5f;

    public bool toggleSneak = false;
    public bool toggleCrouch = true;

    public Transform bodyTransform;
    public Transform sightPoint;
    public AudioSource leftFootstep;
    public AudioSource rightFootstep;
    public Camera mainCam;

    bool leftFootstepNext = false;

    bool isSneaking = false;
    bool isCrouching = false;

    float maxSpeed = 0f;
    float acc = 0f;
    float deacc = 0f;

    bool grounded = false;
    //bool jumpJustPressed = false;
    float bodyRotVelocity = 0f; 
    Vector3 step = Vector3.zero;
    Vector3 horizontalVelocity = Vector3.zero;
    Vector3 verticalVelocity = Vector3.zero;
    Rigidbody rb;
    Animator anim;
    PlayerControls controls;
    SoundManager soundManager;
    InstantCamera instantCam;

    enum PlayerState {
        Standing, Sneaking, Crouching, Jumping, Falling
    };

    delegate void eeDel();
    delegate PlayerState uDel();

    PlayerState prevPlayerState = PlayerState.Standing;
    PlayerState playerState = PlayerState.Falling;
    eeDel[] enterFuncs;
    eeDel[] exitFuncs;
    uDel[] updateFuncs;

    void EnterStanding() {
        anim.SetTrigger("Standing");
        maxSpeed = GROUND_MAX_SPEED;
        acc = GROUND_ACC;
        deacc = GROUND_DEACC;
        sightPoint.localPosition = Vector3.up * SIGHT_POINT_OFFSET_NORMAL;
        instantCam.Raise();
    }
    void EnterSneaking() {
        anim.SetTrigger("Standing");
        maxSpeed = GROUND_MAX_SPEED / 2;
        acc = GROUND_ACC;
        deacc = GROUND_DEACC;
        sightPoint.localPosition = Vector3.up * SIGHT_POINT_OFFSET_NORMAL;
        instantCam.Raise();
    }
    void EnterCrouching() {
        anim.SetTrigger("Crouching");
        maxSpeed = GROUND_MAX_SPEED / 2;
        acc = GROUND_ACC;
        deacc = GROUND_DEACC;
        sightPoint.localPosition = Vector3.up * SIGHT_POINT_OFFSET_CROUCH;
        instantCam.Lower();
    }
    void EnterJumping() {
        anim.SetTrigger("Jumping");
        verticalVelocity.y += JUMP_SPEED;
        maxSpeed = AIR_MAX_SPEED;
        acc = AIR_ACC;
        deacc = AIR_DEACC;
        sightPoint.localPosition = Vector3.up * SIGHT_POINT_OFFSET_NORMAL;
        instantCam.Raise();
    }
    void EnterFalling() {
        anim.SetTrigger("Falling");
        maxSpeed = AIR_MAX_SPEED;
        acc = AIR_ACC;
        deacc = AIR_DEACC;
        sightPoint.localPosition = Vector3.up * SIGHT_POINT_OFFSET_NORMAL;
        instantCam.Lower();
    }

    void ExitStanding() { }
    void ExitSneaking() { }
    void ExitCrouching() { }
    void ExitJumping() { }
    void ExitFalling() { }

    PlayerState UpdateStanding() {
        //if (jumpJustPressed)
        //    return PlayerState.Jumping;
        if (grounded) {
            if (isCrouching)
                return PlayerState.Crouching;
            if (isSneaking)
                return PlayerState.Sneaking;
            return PlayerState.Standing;
        }
        return PlayerState.Falling;
    }
    PlayerState UpdateSneaking() {
        if (grounded) {
            if (isCrouching)
                return PlayerState.Crouching;
            if (isSneaking)
                return PlayerState.Sneaking;
            return PlayerState.Standing;
        }
        return PlayerState.Falling;
    }
    PlayerState UpdateCrouching() {
        if (grounded) {
            if (isCrouching)
                return PlayerState.Crouching;
            if (isSneaking)
                return PlayerState.Sneaking;
            return PlayerState.Standing;
        }
        return PlayerState.Falling;
    }
    PlayerState UpdateJumping() {
        if (verticalVelocity.y > 0)
            return PlayerState.Jumping;
        return PlayerState.Falling;
    }
    PlayerState UpdateFalling() {
        if (grounded)
            return PlayerState.Standing;
        return PlayerState.Falling;
    }

    void Start() {
        enterFuncs = new eeDel[] {
            this.EnterStanding, this.EnterSneaking, this.EnterCrouching, this.EnterJumping, this.EnterFalling
        };
        exitFuncs = new eeDel[] {
            this.ExitStanding, this.ExitSneaking, this.ExitCrouching, this.ExitJumping, this.ExitFalling
        };
        updateFuncs = new uDel[] {
            this.UpdateStanding, this.UpdateSneaking, this.UpdateCrouching, this.UpdateJumping, this.UpdateFalling
        };

        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        controls = new PlayerControls();
        controls.Enable();
        controls.Player.Jump.started += OnJumpStarted;
        controls.Player.Sneak.started += OnSneakStarted;
        controls.Player.Sneak.canceled += OnSneakCanceled;
        controls.Player.Crouch.started += OnCrouchStarted;
        controls.Player.Crouch.canceled += OnCrouchCanceled;

        PlayerIK ik = GetComponentInChildren<PlayerIK>();
        if (ik)
            ik.onFootHitGround += OnFootHitGround;

        soundManager = SoundManager.Get();

        instantCam = GetComponentInChildren<InstantCamera>();
    }

    void Update() {
        if (playerState != prevPlayerState) {
            exitFuncs[(int)prevPlayerState]();
            prevPlayerState = playerState;
            enterFuncs[(int)playerState]();
        }
        playerState = updateFuncs[(int)playerState]();

        //jumpJustPressed = false;

        anim.SetFloat("Speed", horizontalVelocity.magnitude);
    }

    void FixedUpdate() {
        GroundRoutine();

        Vector3 fixedCamRight = Vector3.Cross(Vector3.up, mainCam.transform.forward).normalized;
        Vector3 fixedCamForward = Vector3.Cross(fixedCamRight, Vector3.up);

        Vector2 move = controls.Player.Move.ReadValue<Vector2>();

        step = Vector3.zero;
        step += fixedCamRight * move.x;
        step += fixedCamForward * move.y;
        step = Vector3.ClampMagnitude(step, 1);

        if (instantCam.IsAiming()) {
            bodyTransform.rotation = Quaternion.LookRotation(fixedCamForward);
        } else if (step.magnitude > 0) {
            float stepAngle = Vector3.SignedAngle(Vector3.forward, step, Vector3.up);
            float bodyAngle = Vector3.SignedAngle(Vector3.forward, bodyTransform.forward, Vector3.up);
            bodyAngle = Mathf.SmoothDampAngle(bodyAngle, stepAngle, ref bodyRotVelocity, 0.25f);
            bodyTransform.rotation = Quaternion.Euler(0f, bodyAngle, 0f);
        }

        horizontalVelocity += step * acc * Time.fixedDeltaTime;

        float projectedHVOnStep = Mathf.Clamp(Vector3.Dot(step.normalized, horizontalVelocity), 0, maxSpeed);
        Vector3 unprojectedHV = horizontalVelocity - (step.normalized * projectedHVOnStep);
        Vector2 sign = Vector2.zero;
        sign.x = Mathf.Sign(unprojectedHV.x);
        sign.y = Mathf.Sign(unprojectedHV.z);
        unprojectedHV -= unprojectedHV.normalized * deacc * Time.fixedDeltaTime;
        if (sign.x != Mathf.Sign(unprojectedHV.x))
            unprojectedHV.x = 0f;
        if (sign.y != Mathf.Sign(unprojectedHV.z))
            unprojectedHV.z = 0f;
        horizontalVelocity = (step.normalized * projectedHVOnStep) + unprojectedHV;
        horizontalVelocity = Vector3.ClampMagnitude(horizontalVelocity, maxSpeed);

        verticalVelocity += Physics.gravity * Time.fixedDeltaTime;
        verticalVelocity.y = Mathf.Max(verticalVelocity.y, -TERMINAL_SPEED);

        rb.velocity = horizontalVelocity + verticalVelocity;
    }

    void GroundRoutine() {
        RaycastHit hit;
        Vector3 start = transform.TransformPoint(0f, 0.5f, 0f);
        Vector3 dir = Vector3.down;
        if (verticalVelocity.y <= 0 && Physics.Raycast(start, dir, out hit, 0.6f, LayerMask.GetMask("Ground"))) {
            grounded = true;
            rb.MovePosition(hit.point);
            verticalVelocity.y = 0;
        } else {
            grounded = false;
        }
    }

    void OnJumpStarted(InputAction.CallbackContext context) {
        //jumpJustPressed = true;
    }

    void OnSneakStarted(InputAction.CallbackContext context) {
        if (toggleSneak)
            isSneaking = !isSneaking;
        else
            isSneaking = true;
    }
    void OnSneakCanceled(InputAction.CallbackContext context) {
        if (!toggleSneak)
            isSneaking = false;
    }

    void OnCrouchStarted(InputAction.CallbackContext context) {
        if (toggleCrouch)
            isCrouching = !isCrouching;
        else
            isCrouching = true;
    }
    void OnCrouchCanceled(InputAction.CallbackContext context) {
        if (!toggleCrouch)
            isCrouching = false;
    }

    void OnFootHitGround(RaycastHit hit) {
        float blend = horizontalVelocity.magnitude / GROUND_MAX_SPEED;

        Sound sound = new Sound();
        sound.origin = hit.point;
        sound.radius = 2 * blend;
        sound.type = SoundType.Footstep;
        sound.emitter = gameObject;
        soundManager.EmitSound(sound);

        if (leftFootstepNext) {
            leftFootstep.volume = blend;
            leftFootstep.Play();
        } else {
            rightFootstep.volume = blend;
            rightFootstep.Play();
        }
        leftFootstepNext = !leftFootstepNext;
    }

    public bool IsCrouching() {
        return playerState == PlayerState.Crouching;
    }

    public bool IsFalling() {
        return playerState == PlayerState.Crouching;
    }
}
