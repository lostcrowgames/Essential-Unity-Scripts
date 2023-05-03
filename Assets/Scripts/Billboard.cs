using UnityEngine;

public class Billboard : MonoBehaviour
{
    public string cameraName = "Main Camera"; // Change this to the name of your camera's GameObject

    private Camera cam;

    void Start()
    {
        cam = GameObject.Find(cameraName).GetComponent<Camera>();
        Debug.Log("Camera:" + cam);
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
    }
}
