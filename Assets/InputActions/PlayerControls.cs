// GENERATED AUTOMATICALLY FROM 'Assets/InputActions/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""40b4f9be-873c-451e-9924-cfefa1e40ccc"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""955ea51f-a900-47b8-a344-a39b7fcabc3d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookMouse"",
                    ""type"": ""Value"",
                    ""id"": ""728194fa-448e-41f4-bb24-08a7eae9b7e1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookStick"",
                    ""type"": ""Value"",
                    ""id"": ""118eca9b-0d5f-4d4e-b11b-5e4af6b7b3ad"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockMouse"",
                    ""type"": ""Button"",
                    ""id"": ""40db5088-78f9-4b32-af57-31ad1cef5bc5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UnlockMouse"",
                    ""type"": ""Button"",
                    ""id"": ""929208f2-8d39-4be8-b8a3-2469ed4f9cee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""7ed6c13c-fcbb-4c0c-968d-e33338ebf5d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""670f426a-a36e-43ec-afa7-83e1efe34156"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sneak"",
                    ""type"": ""Button"",
                    ""id"": ""6d3ef702-a636-47a8-9990-6fe1850cd48d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimCamera"",
                    ""type"": ""Button"",
                    ""id"": ""16a1e582-fddb-4cf7-9e78-6a41282348d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SnapPhoto"",
                    ""type"": ""Button"",
                    ""id"": ""5f464e8e-a63e-484b-9834-cda1f8afc833"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""afd7955d-dc72-43cb-a2aa-5a14a0407988"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""477e0565-7e97-410e-b564-08254af2fb0e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9fe2baaa-ad33-44f3-b28a-dbe8cead8f04"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f3331313-e7e6-4844-9e21-5225c3a4dbf9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cb34b910-2387-4c1d-8130-21c8cebd295d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fedf7f9e-862d-49c5-b174-53321cde7d25"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f9d8cf1-9176-4c07-a504-9dae076a5234"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d0ed942-c058-4446-9ec1-e4ed9aa369fe"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67c0be9d-30e1-45df-82fd-5bc9316397e3"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UnlockMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcc9c080-f328-4cb8-9a73-8d1b77b5f931"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52e3c5d1-1ffa-4765-bb15-bc952d6a9315"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b96b587-4b7b-400b-a6d4-6fda3605dc5e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82a607fb-5eab-4656-acd1-3abb8d1bf3cc"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d28c46e-c40c-439c-a68d-07a661c9805d"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""deca00ce-72bf-40a8-b6c2-268d5c1bcd40"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sneak"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""322275be-cb95-42be-86b5-0c3b3ecdffd7"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sneak"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf2334f3-d9f2-42e8-a294-53a9cbf5c85c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""158aa71f-cf69-456b-a636-2c427107c98c"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea193e48-36c7-47f6-9fc8-1d7874a493bc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SnapPhoto"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a9aec1c-863c-4ee4-8fbf-ee99f3db65b1"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SnapPhoto"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_LookMouse = m_Player.FindAction("LookMouse", throwIfNotFound: true);
        m_Player_LookStick = m_Player.FindAction("LookStick", throwIfNotFound: true);
        m_Player_LockMouse = m_Player.FindAction("LockMouse", throwIfNotFound: true);
        m_Player_UnlockMouse = m_Player.FindAction("UnlockMouse", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
        m_Player_Sneak = m_Player.FindAction("Sneak", throwIfNotFound: true);
        m_Player_AimCamera = m_Player.FindAction("AimCamera", throwIfNotFound: true);
        m_Player_SnapPhoto = m_Player.FindAction("SnapPhoto", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_LookMouse;
    private readonly InputAction m_Player_LookStick;
    private readonly InputAction m_Player_LockMouse;
    private readonly InputAction m_Player_UnlockMouse;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Crouch;
    private readonly InputAction m_Player_Sneak;
    private readonly InputAction m_Player_AimCamera;
    private readonly InputAction m_Player_SnapPhoto;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @LookMouse => m_Wrapper.m_Player_LookMouse;
        public InputAction @LookStick => m_Wrapper.m_Player_LookStick;
        public InputAction @LockMouse => m_Wrapper.m_Player_LockMouse;
        public InputAction @UnlockMouse => m_Wrapper.m_Player_UnlockMouse;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
        public InputAction @Sneak => m_Wrapper.m_Player_Sneak;
        public InputAction @AimCamera => m_Wrapper.m_Player_AimCamera;
        public InputAction @SnapPhoto => m_Wrapper.m_Player_SnapPhoto;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @LookMouse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookMouse;
                @LookMouse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookMouse;
                @LookMouse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookMouse;
                @LookStick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookStick;
                @LookStick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookStick;
                @LookStick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookStick;
                @LockMouse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockMouse;
                @LockMouse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockMouse;
                @LockMouse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockMouse;
                @UnlockMouse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUnlockMouse;
                @UnlockMouse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUnlockMouse;
                @UnlockMouse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUnlockMouse;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Sneak.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSneak;
                @Sneak.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSneak;
                @Sneak.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSneak;
                @AimCamera.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimCamera;
                @AimCamera.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimCamera;
                @AimCamera.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimCamera;
                @SnapPhoto.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSnapPhoto;
                @SnapPhoto.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSnapPhoto;
                @SnapPhoto.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSnapPhoto;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @LookMouse.started += instance.OnLookMouse;
                @LookMouse.performed += instance.OnLookMouse;
                @LookMouse.canceled += instance.OnLookMouse;
                @LookStick.started += instance.OnLookStick;
                @LookStick.performed += instance.OnLookStick;
                @LookStick.canceled += instance.OnLookStick;
                @LockMouse.started += instance.OnLockMouse;
                @LockMouse.performed += instance.OnLockMouse;
                @LockMouse.canceled += instance.OnLockMouse;
                @UnlockMouse.started += instance.OnUnlockMouse;
                @UnlockMouse.performed += instance.OnUnlockMouse;
                @UnlockMouse.canceled += instance.OnUnlockMouse;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Sneak.started += instance.OnSneak;
                @Sneak.performed += instance.OnSneak;
                @Sneak.canceled += instance.OnSneak;
                @AimCamera.started += instance.OnAimCamera;
                @AimCamera.performed += instance.OnAimCamera;
                @AimCamera.canceled += instance.OnAimCamera;
                @SnapPhoto.started += instance.OnSnapPhoto;
                @SnapPhoto.performed += instance.OnSnapPhoto;
                @SnapPhoto.canceled += instance.OnSnapPhoto;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLookMouse(InputAction.CallbackContext context);
        void OnLookStick(InputAction.CallbackContext context);
        void OnLockMouse(InputAction.CallbackContext context);
        void OnUnlockMouse(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnSneak(InputAction.CallbackContext context);
        void OnAimCamera(InputAction.CallbackContext context);
        void OnSnapPhoto(InputAction.CallbackContext context);
    }
}
