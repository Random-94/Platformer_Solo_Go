// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""Perso"",
            ""id"": ""4860ba1d-1aee-47bd-ae4d-80c8c74ee00d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""3d740009-99c5-4c13-90a3-9e0131104768"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9d60c0eb-a24b-4343-9040-e53c971fb79c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""286074de-e767-4d5f-b930-9a0e5a376917"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrows"",
                    ""id"": ""ab7b65a2-696c-4fb1-953b-ecd8e6529c47"",
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
                    ""id"": ""96c7071b-5293-44e5-8863-08f708afa6b0"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a83c8e86-d046-4967-bc83-df49cb55ca67"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7f9c0c6f-83a0-4296-b5ff-de79928e1599"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""08112d24-dc6d-425d-afcc-35e90bed1bc3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b9d68a80-c9db-4ea3-b8f2-6ad7b3ddba3f"",
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
                    ""id"": ""511005a7-03ac-45a7-a8b3-46173d6741a4"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Perso
        m_Perso = asset.FindActionMap("Perso", throwIfNotFound: true);
        m_Perso_Move = m_Perso.FindAction("Move", throwIfNotFound: true);
        m_Perso_Jump = m_Perso.FindAction("Jump", throwIfNotFound: true);
        m_Perso_Pause = m_Perso.FindAction("Pause", throwIfNotFound: true);
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

    // Perso
    private readonly InputActionMap m_Perso;
    private IPersoActions m_PersoActionsCallbackInterface;
    private readonly InputAction m_Perso_Move;
    private readonly InputAction m_Perso_Jump;
    private readonly InputAction m_Perso_Pause;
    public struct PersoActions
    {
        private @Inputs m_Wrapper;
        public PersoActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Perso_Move;
        public InputAction @Jump => m_Wrapper.m_Perso_Jump;
        public InputAction @Pause => m_Wrapper.m_Perso_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Perso; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PersoActions set) { return set.Get(); }
        public void SetCallbacks(IPersoActions instance)
        {
            if (m_Wrapper.m_PersoActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PersoActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PersoActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PersoActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PersoActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PersoActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PersoActionsCallbackInterface.OnJump;
                @Pause.started -= m_Wrapper.m_PersoActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PersoActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PersoActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PersoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PersoActions @Perso => new PersoActions(this);
    public interface IPersoActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
