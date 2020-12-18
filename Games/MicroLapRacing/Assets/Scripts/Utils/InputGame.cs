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
                    ""name"": """",
                    ""id"": ""8639795e-6824-43fd-aaed-8e94483b8163"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b2139e6-c5af-49be-8748-075877ef8dc1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Vehicle
            m_Vehicle = asset.FindActionMap("Vehicle", throwIfNotFound: true);
            m_Vehicle_Move = m_Vehicle.FindAction("Move", throwIfNotFound: true);
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
        public struct VehicleActions
        {
            private @InputGame m_Wrapper;
            public VehicleActions(@InputGame wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Vehicle_Move;
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
                }
                m_Wrapper.m_VehicleActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                }
            }
        }
        public VehicleActions @Vehicle => new VehicleActions(this);
        public interface IVehicleActions
        {
            void OnMove(InputAction.CallbackContext context);
        }
    }
}
