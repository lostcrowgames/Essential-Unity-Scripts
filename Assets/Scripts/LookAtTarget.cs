using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private float detectionRange = 10f; // The range at which the Game Object can detect the target
    [SerializeField] private float rotationSpeed = 5f; // The speed at which the Game Object rotates to face the target

    private Transform lookAtTarget; // The transform of the target


    private void Start()
    {
        lookAtTarget = GameObject.FindGameObjectWithTag(targetTag).transform; // Find the target Game Object based on tag
    }

    private void Update()
    {
        // Check if the player is within detection range
        if (Vector3.Distance(transform.position, lookAtTarget.position) <= detectionRange)
        {
            // Calculate the direction to the player
            Vector3 direction = lookAtTarget.position - transform.position;
            direction.y = 0f;

            // Rotate the enemy to face the player
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        // Draw a yellow wire circle to show the detection range
        Gizmos.color = Color.yellow;
        Vector3 circlePos = transform.position;
        circlePos.y += 0.1f; // adjust the height to avoid z-fighting
        float radius = detectionRange * Mathf.Max(transform.localScale.x, transform.localScale.z);
        Matrix4x4 matrixBackup = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(circlePos, Quaternion.LookRotation(Vector3.up, Vector3.forward), new Vector3(radius, radius, 0f));
        Gizmos.DrawWireSphere(Vector3.zero, 1f);
        Gizmos.matrix = matrixBackup;
    }

}
