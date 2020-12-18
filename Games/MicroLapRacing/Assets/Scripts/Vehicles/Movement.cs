using UnityEngine;

namespace AlphaMiniGames
{
    public class Movement : MonoBehaviour
    {
        
        [SerializeField] private float movementSpeed;

        private Rigidbody2D body;
        private Vector2 velocity = Vector2.zero;

        public void Move(float dir)
        {
            Vector2 targetVelocity = new Vector2(dir * movementSpeed, body.velocity.y);
            body.velocity = Vector2.SmoothDamp(body.velocity, targetVelocity, ref velocity, .03f);
        }
        
        private void Awake() 
        {
            body = GetComponent<Rigidbody2D>();
        }
    }
}
