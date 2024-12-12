using UnityEngine;

public class BillboardPos : MonoBehaviour
{
    private Camera targetCamera; // The camera the object should face. If not set, it defaults to the main camera.

    void Start()
    {
        // If no camera is assigned, use the main camera
        if (targetCamera == null)
        {
            targetCamera = Camera.main;
        }
    }

    void Update()
    {
        Vector3 v = targetCamera.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(targetCamera.transform.position - v);
    }
}
