//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/PauseInput.inputactions
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

public partial class @PauseInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PauseInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PauseInput"",
    ""maps"": [
        {
            ""name"": ""PauseI"",
            ""id"": ""7e3ad6d1-e3a7-45e8-8e18-a52727e73b1e"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""8a033485-49da-40b6-95c1-82c5a8c80ddc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""01e2e332-8d76-42ab-abf6-9c8834056fb4"",
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
        // PauseI
        m_PauseI = asset.FindActionMap("PauseI", throwIfNotFound: true);
        m_PauseI_Pause = m_PauseI.FindAction("Pause", throwIfNotFound: true);
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

    // PauseI
    private readonly InputActionMap m_PauseI;
    private IPauseIActions m_PauseIActionsCallbackInterface;
    private readonly InputAction m_PauseI_Pause;
    public struct PauseIActions
    {
        private @PauseInput m_Wrapper;
        public PauseIActions(@PauseInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_PauseI_Pause;
        public InputActionMap Get() { return m_Wrapper.m_PauseI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseIActions set) { return set.Get(); }
        public void SetCallbacks(IPauseIActions instance)
        {
            if (m_Wrapper.m_PauseIActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_PauseIActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PauseIActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PauseIActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PauseIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PauseIActions @PauseI => new PauseIActions(this);
    public interface IPauseIActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
