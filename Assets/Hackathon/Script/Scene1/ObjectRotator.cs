using UnityEngine;
using DG.Tweening;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2f; // Duration for one full rotation
    [SerializeField] private bool rotateClockwise = true; // Direction of rotation

    void Start()
    {
        // Determine the rotation direction
        float rotationAngle = rotateClockwise ? -360f : 360f;

        // Apply the rotation on the Z-axis
        transform.DOLocalRotate(new Vector3(0, 0, -rotationAngle / 4), 0.5f, RotateMode.LocalAxisAdd)
        .SetDelay(0.5f)
        .OnComplete(() => transform.DOLocalRotate(new Vector3(0, 0, rotationAngle), rotationSpeed, RotateMode.FastBeyond360)
        .SetRelative()
        .SetLoops(-1, LoopType.Restart)
        .SetEase(Ease.Linear));

    }
}
