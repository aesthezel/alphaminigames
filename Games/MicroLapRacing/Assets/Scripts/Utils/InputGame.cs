// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Utils/InputGame.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace AlphaMiniGames
{
    public class @InputGame : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputGame()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputGame"",
    ""maps"": [
        {
            ""name"": ""Vehicle"",
            ""id"": ""7271b4e5-53f7-46c1-b785-65b3aecd823b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""d3220048-b225-4ba6-8abe-666e6be1bab6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""1c16a419-837e-4a78-8cd4-8cccfa879f2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Horizontal"",
                    ""id"": ""2299a7f1-72e2-4ece-9c51-9b465c2edfa0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a2bc9741-5d76-4a97-b29b-cb1d05de8194"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""33b978af-a2db-458a-aedf-9489d16bbc7e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Vertical"",
                    ""id"": ""5622c965-94ef-4b14-97ab-91d96b6a8ff0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2fca247c-c680-4b3e-ade8-fa4c25e5a585"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1edd8a0f-2b41-4738-849c-271409f25f70"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Vehicle
            m_Vehicle = asset.FindActionMap("Vehicle", throwIfNotFound: true);
            m_Vehicle_Move = m_Vehicle.FindAction("Move", throwIfNotFound: true);
            m_Vehicle_Accelerate = m_Vehicle.FindAction("Accelerate", throwIfNotFound: true);
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

        // Vehicle
        private readonly InputActionMap m_Vehicle;
        private IVehicleActions m_VehicleActionsCallbackInterface;
        private readonly InputAction m_Vehicle_Move;
        private readonly InputAction m_Vehicle_Accelerate;
        public struct VehicleActions
        {
            private @InputGame m_Wrapper;
            public VehicleActions(@InputGame wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Vehicle_Move;
            public InputAction @Accelerate => m_Wrapper.m_Vehicle_Accelerate;
            public InputActionMap Get() { return m_Wrapper.m_Vehicle; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(VehicleActions set) { return set.Get(); }
            public void SetCallbacks(IVehicleActions instance)
            {
                if (m_Wrapper.m_VehicleActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_VehicleActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_VehicleActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_VehicleActionsCallbackInterface.OnMove;
                    @Accelerate.started -= m_Wrapper.m_VehicleActionsCallbackInterface.OnAccelerate;
                    @Accelerate.performed -= m_Wrapper.m_VehicleActionsCallbackInterface.OnAccelerate;
                    @Accelerate.canceled -= m_Wrapper.m_VehicleActionsCallbackInterface.OnAccelerate;
                }
                m_Wrapper.m_VehicleActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Accelerate.started += instance.OnAccelerate;
                    @Accelerate.performed += instance.OnAccelerate;
                    @Accelerate.canceled += instance.OnAccelerate;
                }
            }
        }
        public VehicleActions @Vehicle => new VehicleActions(this);
        public interface IVehicleActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnAccelerate(InputAction.CallbackContext context);
        }
    }
}
