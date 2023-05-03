using UnityEngine;

public class PreventEnvironmentClipping : MonoBehaviour
{
    private Rigidbody rb;
    private CapsuleCollider playerCollider;
    private float skinWidth = 0.1f; // Adjust this to prevent clipping

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
    }

    private void FixedUpdate()
    {
        // Cast a capsule in the direction of the player's movement
        Vector3 movement = rb.velocity.normalized;
        float distance = Mathf.Max(playerCollider.height / 2 - playerCollider.radius, playerCollider.radius);
        RaycastHit hit;
        if (Physics.CapsuleCast(
            playerCollider.bounds.center + Vector3.up * (distance - playerCollider.radius + skinWidth),
            playerCollider.bounds.center + Vector3.down * (distance - playerCollider.radius + skinWidth),
            playerCollider.radius - skinWidth,
            movement,
            out hit,
            rb.velocity.magnitude * Time.fixedDeltaTime + skinWidth,
            LayerMask.GetMask("Environment")
        ))
        {
            // Prevent player from clipping into the wall
            rb.position = hit.point - movement.normalized * (hit.distance - playerCollider.radius + skinWidth);
            rb.velocity = Vector3.zero;
            Debug.DrawLine(playerCollider.bounds.center, hit.point, Color.red, 1f);
            Debug.Log("Prevented environment clipping. Hit distance: " + hit.distance);
        }
    }
}
