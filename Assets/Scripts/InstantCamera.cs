using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera), typeof(Animator))]
public class InstantCamera : MonoBehaviour {

    const float filmRatio = 3/2f;
    const float shutterTime = 0.25f;

    public bool aimingAllowed = true;
    public Camera mainCam;
    public Animator shutterAnim;

    bool aiming = false;
    float shutterTimer = 0f;
    Camera cam;
    Animator anim;
    PlayerControls controls;

    void Start() {
        cam = GetComponent<Camera>();
        anim = GetComponent<Animator>();
        controls = new PlayerControls();
        controls.Enable();
        controls.Player.AimCamera.started += OnAimStarted;
        controls.Player.AimCamera.canceled += OnAimCanceled;
        controls.Player.SnapPhoto.started += OnSnapPhoto;

        shutterAnim.SetTrigger("Close");
    }

    void Update() {
        float screenRatio = Screen.width / (float)Screen.height;
        Rect rect = Rect.zero;
        if (screenRatio > filmRatio) {
            rect.x = (1 - (filmRatio / screenRatio)) / 2f;
            rect.width = filmRatio / screenRatio;
            rect.height = 1;
        } else {
            rect.y = (1 - (screenRatio / filmRatio)) / 2f;
            rect.width = 1;
            rect.height = screenRatio / filmRatio;
        }
        cam.rect = rect;

        transform.rotation = mainCam.transform.rotation;

        if (shutterTimer > 0)
            shutterTimer -= Time.deltaTime;
    }

    void OnAimStarted(InputAction.CallbackContext context) {
        if (aimingAllowed) {
            cam.enabled = true;
            mainCam.enabled = false;
            aiming = true;
            shutterAnim.SetTrigger("Open");
        }
    }

    void OnAimCanceled(InputAction.CallbackContext context) {
        if (aiming) {
            mainCam.enabled = true;
            cam.enabled = false;
            aiming = false;
            shutterAnim.SetTrigger("Close");
        }
    }

    void OnSnapPhoto(InputAction.CallbackContext context) {
        if (aiming) {
            shutterAnim.SetTrigger("Snap");
        }
    }

    public void Raise() {
        anim.SetTrigger("Stand");
    }

    public void Lower() {
        anim.SetTrigger("Crouch");
    }

    public bool IsAiming() {
        return aiming;
    }
}
