using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentKnockBack : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private bool knockBack;
    private Vector3 direction;

    [SerializeField] private float knockBackSpeed = 10f;
    [SerializeField] private float knockBackAcceleration = 20f;
    [SerializeField] private float knockBackAngularSpeed = 180f;

    void Start()
    {
        knockBack = false;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        if (knockBack)
        {
            navMeshAgent.velocity = direction * 8; // Knocks the enemy back when appropriate 
        }
    }

    public void ApplyKnockBack()
    {
        Debug.Log("Applying Knockback to " + gameObject);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            direction = (gameObject.transform.position - player.transform.position).normalized;
            StartCoroutine(KnockBack());
        }
        else
        {
            Debug.LogError("Player game object not found. Make sure the player has the 'Player' tag.");
        }
    }

    private IEnumerator KnockBack()
    {
        knockBack = true;
        navMeshAgent.speed = knockBackSpeed;
        navMeshAgent.angularSpeed = 0; // Keeps the enemy facing forward rather than spinning
        navMeshAgent.acceleration = knockBackAcceleration;

        yield return new WaitForSeconds(0.2f); // Only knock the enemy back for a short time     

        // Reset to default values
        knockBack = false;
        navMeshAgent.speed = 4;
        navMeshAgent.angularSpeed = knockBackAngularSpeed;
        navMeshAgent.acceleration = 10;
    }
}
