using UnityEngine;

public class SmoothFollowWithMassAndRotation : MonoBehaviour
{
    [SerializeField] private Transform target; // The target to follow
    [SerializeField] private float followSpeed = 2f; // Speed at which the object follows position
    [SerializeField] private float rotationSpeed = 2f; // Speed at which the object follows rotation
    [SerializeField] private float massFactor = 0.5f; // Higher values simulate more "mass" (slower response for position)

    private Vector3 velocity = Vector3.zero; // Velocity for smooth damping (position)

    private void Update()
    {
        if (target != null)
        {
            // Smoothly interpolate position with a mass effect
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, massFactor, followSpeed);

            // Smoothly interpolate rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * rotationSpeed);
        }
    }
}
