using UnityEngine;

public class RigidbodyKnockBack : MonoBehaviour
{
    [SerializeField] private Rigidbody gameObjectRigidBody;
    private Vector3 direction;

    private void Start()
    {
        gameObjectRigidBody = GetComponent<Rigidbody>();
    }

    public void TakeHit(float knockbackStrength, Vector3 bulletVelocity)
    {
        Debug.Log("Calling TakeHit on Player KnockBack");
        gameObjectRigidBody = GetComponent<Rigidbody>();

        if (gameObjectRigidBody != null)
        {
            Debug.Log("Applying Knockback");

            // Calculate knockback direction based on bullet velocity
            Vector3 knockbackDirection = -bulletVelocity.normalized;

            // Set direction to knockback direction
            direction = knockbackDirection;

            // Apply knockback force
            gameObjectRigidBody.AddForce(knockbackDirection * knockbackStrength, ForceMode.Impulse);
        }
    }


    public void LookInDirection(Vector3 direction)
    {
        Debug.Log("PlayerKnockback - Calling LookInDirection");
        // Rotate game objects towards opposite knockback direction (the effect is so that the game object looks at what hit it)
        direction = -direction;
        direction.y = 0f; // Ensure player doesn't tilt upwards/downwards
        Quaternion rotation = Quaternion.LookRotation(direction);
        gameObjectRigidBody.MoveRotation(rotation);
    }

}
