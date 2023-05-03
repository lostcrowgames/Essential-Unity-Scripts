using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private float followSpeed = 50f;
    [SerializeField] private Vector3 offset;
    [SerializeField] bool clampToTargetSpeed;
    private Transform followTransform;


    private void Start()
    {
        followTransform = GameObject.FindGameObjectWithTag(targetTag).transform;
    }

    void Update()
    {
        if (!clampToTargetSpeed)
        {
            Vector3 targetPosition = followTransform.TransformPoint(offset);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
        }
        else
        {
            Vector3 targetPosition = followTransform.TransformPoint(offset);
            transform.position = targetPosition;
        }
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
