//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/PlayerInputControl.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputControl : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputControl"",
    ""maps"": [
        {
            ""name"": ""Player Interaction"",
            ""id"": ""117e754f-20c1-4337-8af8-873e5e30ca7d"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""0b7bd352-bb1f-4355-8899-ea02d20bd787"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""444ccf11-8846-4b89-b048-9e9da20a6f39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""47ee0e19-e991-4a30-a76d-2905ea1dc87f"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d1594d55-eda6-473a-bfc9-659db05e7f89"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""f95c351e-1d1a-4b5f-83ee-0618f2248a29"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""EnergyDrink"",
                    ""type"": ""Button"",
                    ""id"": ""0f837975-f3a4-4989-9e5e-cac1af2707f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""85f5807e-dc3f-4266-a21e-79cb50afdef9"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e335579-381f-4e25-9bfa-5e32c1ced312"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ed27867-b172-40c7-a610-207e6ee6e365"",
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
                    ""id"": ""89786c64-8f69-4f9b-a328-86e1ad3fd66a"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Press(pressPoint=0.5)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5552434d-8e10-4ddd-808c-fa7e35285a92"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnergyDrink"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""3D Vector"",
                    ""id"": ""76381777-eab2-4497-aa78-75c8a2a6c2e0"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e18cd307-f43c-4dcb-8425-9e5d46767d4d"",
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
                    ""id"": ""09a308b8-fc75-4cfe-afbf-9f38fad9b7d0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""forward"",
                    ""id"": ""1bb1f866-d27d-47d4-8c4b-3b7606b93955"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""backward"",
                    ""id"": ""de520f79-0620-4d7a-a01c-e59d78348911"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Default"",
            ""bindingGroup"": ""Default"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player Interaction
        m_PlayerInteraction = asset.FindActionMap("Player Interaction", throwIfNotFound: true);
        m_PlayerInteraction_Interact = m_PlayerInteraction.FindAction("Interact", throwIfNotFound: true);
        m_PlayerInteraction_Attack = m_PlayerInteraction.FindAction("Attack", throwIfNotFound: true);
        m_PlayerInteraction_Move = m_PlayerInteraction.FindAction("Move", throwIfNotFound: true);
        m_PlayerInteraction_Jump = m_PlayerInteraction.FindAction("Jump", throwIfNotFound: true);
        m_PlayerInteraction_Run = m_PlayerInteraction.FindAction("Run", throwIfNotFound: true);
        m_PlayerInteraction_EnergyDrink = m_PlayerInteraction.FindAction("EnergyDrink", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player Interaction
    private readonly InputActionMap m_PlayerInteraction;
    private IPlayerInteractionActions m_PlayerInteractionActionsCallbackInterface;
    private readonly InputAction m_PlayerInteraction_Interact;
    private readonly InputAction m_PlayerInteraction_Attack;
    private readonly InputAction m_PlayerInteraction_Move;
    private readonly InputAction m_PlayerInteraction_Jump;
    private readonly InputAction m_PlayerInteraction_Run;
    private readonly InputAction m_PlayerInteraction_EnergyDrink;
    public struct PlayerInteractionActions
    {
        private @PlayerInputControl m_Wrapper;
        public PlayerInteractionActions(@PlayerInputControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_PlayerInteraction_Interact;
        public InputAction @Attack => m_Wrapper.m_PlayerInteraction_Attack;
        public InputAction @Move => m_Wrapper.m_PlayerInteraction_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerInteraction_Jump;
        public InputAction @Run => m_Wrapper.m_PlayerInteraction_Run;
        public InputAction @EnergyDrink => m_Wrapper.m_PlayerInteraction_EnergyDrink;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInteraction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInteractionActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInteractionActions instance)
        {
            if (m_Wrapper.m_PlayerInteractionActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnInteract;
                @Attack.started -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnAttack;
                @Move.started -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnJump;
                @Run.started -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnRun;
                @EnergyDrink.started -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnEnergyDrink;
                @EnergyDrink.performed -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnEnergyDrink;
                @EnergyDrink.canceled -= m_Wrapper.m_PlayerInteractionActionsCallbackInterface.OnEnergyDrink;
            }
            m_Wrapper.m_PlayerInteractionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @EnergyDrink.started += instance.OnEnergyDrink;
                @EnergyDrink.performed += instance.OnEnergyDrink;
                @EnergyDrink.canceled += instance.OnEnergyDrink;
            }
        }
    }
    public PlayerInteractionActions @PlayerInteraction => new PlayerInteractionActions(this);
    private int m_DefaultSchemeIndex = -1;
    public InputControlScheme DefaultScheme
    {
        get
        {
            if (m_DefaultSchemeIndex == -1) m_DefaultSchemeIndex = asset.FindControlSchemeIndex("Default");
            return asset.controlSchemes[m_DefaultSchemeIndex];
        }
    }
    public interface IPlayerInteractionActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnEnergyDrink(InputAction.CallbackContext context);
    }
}
