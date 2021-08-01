// GENERATED AUTOMATICALLY FROM 'Assets/Input/GeneralControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GeneralControlsScript : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GeneralControlsScript()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GeneralControls"",
    ""maps"": [
        {
            ""name"": ""GeneralControls"",
            ""id"": ""26eb9e0d-a38d-4d5b-bfb2-32ac390157aa"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""3e97b906-d1f6-47d5-9c0d-0e4292b5e039"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Value"",
                    ""id"": ""dfae1b2c-69e3-4d75-ac9d-a8c0630260a2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Nuke"",
                    ""type"": ""Button"",
                    ""id"": ""a7983f3e-d505-4f24-94ea-45d16b7405ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""7dcb3fe3-4085-4e81-93fe-9f9c20a1ac71"",
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
                    ""id"": ""25242634-47a1-4ee6-840d-59423a20185b"",
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
                    ""id"": ""f46f8b42-6db9-4887-af82-89fffd1da34a"",
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
                    ""id"": ""10d416ea-9e1d-4506-b12e-a60a477325f7"",
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
                    ""id"": ""d4ef235f-7d2b-4475-b85d-fc30b9da9986"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""0ebb7e31-06ea-46c9-821a-90fa67eb62f5"",
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
                    ""id"": ""357dc0a9-8067-441d-a5ed-63dcc94b7046"",
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
                    ""id"": ""46cb5d88-02a0-4ccd-b78b-ef7278ca92b7"",
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
                    ""id"": ""924c0ae5-7687-4d56-8afe-6e2dfbd1c16d"",
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
                    ""id"": ""ccffbd88-7a73-47d4-b16a-e9d97805a9a6"",
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
                    ""id"": ""fdb50c32-95c6-484a-b196-823682893fcd"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2798568-6e4f-4b13-8628-ae8bb6101650"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Nuke"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd592e47-41e5-4b67-a7a0-2aad3d60e90e"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Nuke"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GeneralControls
        m_GeneralControls = asset.FindActionMap("GeneralControls", throwIfNotFound: true);
        m_GeneralControls_Move = m_GeneralControls.FindAction("Move", throwIfNotFound: true);
        m_GeneralControls_Fire = m_GeneralControls.FindAction("Fire", throwIfNotFound: true);
        m_GeneralControls_Nuke = m_GeneralControls.FindAction("Nuke", throwIfNotFound: true);
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

    // GeneralControls
    private readonly InputActionMap m_GeneralControls;
    private IGeneralControlsActions m_GeneralControlsActionsCallbackInterface;
    private readonly InputAction m_GeneralControls_Move;
    private readonly InputAction m_GeneralControls_Fire;
    private readonly InputAction m_GeneralControls_Nuke;
    public struct GeneralControlsActions
    {
        private @GeneralControlsScript m_Wrapper;
        public GeneralControlsActions(@GeneralControlsScript wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GeneralControls_Move;
        public InputAction @Fire => m_Wrapper.m_GeneralControls_Fire;
        public InputAction @Nuke => m_Wrapper.m_GeneralControls_Nuke;
        public InputActionMap Get() { return m_Wrapper.m_GeneralControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralControlsActions set) { return set.Get(); }
        public void SetCallbacks(IGeneralControlsActions instance)
        {
            if (m_Wrapper.m_GeneralControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GeneralControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GeneralControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GeneralControlsActionsCallbackInterface.OnMove;
                @Fire.started -= m_Wrapper.m_GeneralControlsActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GeneralControlsActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GeneralControlsActionsCallbackInterface.OnFire;
                @Nuke.started -= m_Wrapper.m_GeneralControlsActionsCallbackInterface.OnNuke;
                @Nuke.performed -= m_Wrapper.m_GeneralControlsActionsCallbackInterface.OnNuke;
                @Nuke.canceled -= m_Wrapper.m_GeneralControlsActionsCallbackInterface.OnNuke;
            }
            m_Wrapper.m_GeneralControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Nuke.started += instance.OnNuke;
                @Nuke.performed += instance.OnNuke;
                @Nuke.canceled += instance.OnNuke;
            }
        }
    }
    public GeneralControlsActions @GeneralControls => new GeneralControlsActions(this);
    public interface IGeneralControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnNuke(InputAction.CallbackContext context);
    }
}
