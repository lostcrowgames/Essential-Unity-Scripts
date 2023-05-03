using UnityEngine;

public class DestroyAfterDuration : MonoBehaviour
{
    [SerializeField] private float duration = 1f;

    void Start()
    {
        Destroy(gameObject, duration);
    }
}
