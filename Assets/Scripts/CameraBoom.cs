using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoom : MonoBehaviour {

    public bool invertY = false;
    public float mouseSensitivity = 10f;
    public float joystickSensitivity = 100f;
    public float sphereCastRadius = 0.5f;
    public float maxDistance = 5f;
    public Transform tiltTransform;
    public Transform endTransform;

    //degrees
    float pan = 0f;
    float tilt = 0f;

    float distanceVelocity = 0f;

    PlayerControls controls;
    void Start() {
        controls = new PlayerControls();
        controls.Enable();
    }

    void Update() {
        if (controls.Player.LockMouse.triggered)
            Cursor.lockState = CursorLockMode.Locked;
        if (controls.Player.UnlockMouse.triggered)
            Cursor.lockState = CursorLockMode.None;

        Vector2 lookMouse = controls.Player.LookMouse.ReadValue<Vector2>();
        if (invertY)
            lookMouse.y *= -1;

        if (Cursor.lockState == CursorLockMode.Locked) {
            pan += lookMouse.x * mouseSensitivity * Time.deltaTime;
            tilt -= lookMouse.y * mouseSensitivity * Time.deltaTime;
        }

        Vector2 lookStick = controls.Player.LookStick.ReadValue<Vector2>();
        if (invertY)
            lookStick.y *= -1;

        pan += lookStick.x * joystickSensitivity * Time.deltaTime;
        tilt -= lookStick.y * joystickSensitivity * Time.deltaTime;

        pan %= 360;
        tilt = Mathf.Clamp(tilt, -89, 89);

        transform.rotation = Quaternion.Euler(0, pan, 0);
        tiltTransform.localRotation = Quaternion.Euler(tilt, 0, 0);

        
        float distance = maxDistance;
        RaycastHit hit;
        if (Physics.SphereCast(tiltTransform.position, sphereCastRadius, -tiltTransform.forward, out hit, maxDistance, LayerMask.GetMask("Ground"))) {
            distance = Vector3.Dot(-tiltTransform.forward, hit.point - tiltTransform.position);
        }
        distance = Mathf.SmoothDamp(endTransform.localPosition.z, -distance, ref distanceVelocity, 0.25f);

        
        

        endTransform.localPosition = new Vector3(0, 0, distance);
        
    }
}

/* 
        if (Physics.Raycast(tiltTransform.position, -tiltTransform.forward, out hit, maxDistance, LayerMask.GetMask("Ground"))) {
            distance = -hit.distance;
        }
*/