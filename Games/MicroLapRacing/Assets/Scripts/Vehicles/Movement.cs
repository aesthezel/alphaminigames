using UnityEngine;

namespace AlphaMiniGames
{
    public class Movement : MonoBehaviour
    {
        
        [SerializeField] private float vehicleSpeed = 3f;
        [Range(2f, 10f)]
        [SerializeField] private float vehicleStabilization = 2f;

        private Rigidbody2D body;
        private Vector2 velocity = Vector2.zero;

        public void Move(float dirMove, float accelerationValue)
        {
            Vector2 targetVelocity = new Vector2(dirMove * vehicleStabilization, accelerationValue * vehicleSpeed);
            body.velocity = Vector2.SmoothDamp(body.velocity, targetVelocity, ref velocity, .03f);
        }
        
        private void Awake() 
        {
            body = GetComponent<Rigidbody2D>();
        }
    }
}
