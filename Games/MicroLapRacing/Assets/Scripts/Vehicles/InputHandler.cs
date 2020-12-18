using UnityEngine;
using UnityEngine.InputSystem;

namespace AlphaMiniGames
{
    public class InputHandler : MonoBehaviour, InputGame.IVehicleActions
    {

        [SerializeField] private Movement movementVehicle;
        private InputGame controls;

        private float onMoveValue;

        public void OnMove(InputAction.CallbackContext context)
        {
            onMoveValue = context.ReadValue<float>();
            // movementVehicle.Move(context.ReadValue<float>());
        }

		public void OnEnable()
		{
			if (controls == null)
			{
				controls = new InputGame();
				controls.Vehicle.SetCallbacks(this);
			}
			controls.Vehicle.Enable();
		}

		public void OnDisable()
		{
			controls.Vehicle.Disable();
		}

        private void Update() 
        {
            movementVehicle.Move(onMoveValue);
        }

    }
}
