using DG.Tweening;
using UnityEngine;

public class ScriptAnimation : MonoBehaviour
{
    [SerializeField] private float duration = 1f; // Duration of the scale animation
    [SerializeField] private float bounceDepth = 1f; // Depth of the downward movement
    [SerializeField] private float bounceDuration = 0.5f; // Duration for the bounce
    [SerializeField] private Ease EaseType = Ease.Linear; // Easing type for rotation
    [SerializeField] private float rotationAngle = 45f; // Rotation angle for Y-axis
    [SerializeField] private float rotationDuration = 1f; // Duration for a single rotation loop
    [SerializeField] private Ease rotationEaseType = Ease.Linear; // Easing type for rotation
    private Vector3 originalScale;
    private Vector3 originalPosition;

    private void Start()
    {
        // Save the original scale and position
        originalScale = transform.localScale;
        originalPosition = transform.position;
    }

    // Animate scale to 2x the current scale
    public void AnimateScale()
    {
        Vector3 targetScale = originalScale * 2; // Dynamically calculate 2x scale
        transform.DOScale(targetScale, duration).SetEase(EaseType);
    }

    // Reset to the original scale
    public void ResetScale()
    {
        transform.DOScale(originalScale, duration).SetEase(EaseType);
    }

    // Animate a single downward bounce and return to the original position
    public void AnimateBounce()
    {
        Sequence bounceSequence = DOTween.Sequence();

        // Downward movement
        bounceSequence.Append(
            transform.DOMoveY(originalPosition.y - bounceDepth, bounceDuration / 2)
            .SetEase(EaseType)
        );

        // Return to original position
        bounceSequence.Append(
            transform.DOMoveY(originalPosition.y, bounceDuration / 2)
            .SetEase(EaseType)
        );

        bounceSequence.Play();
    }

    // Animate continuous rotation on the Y-axis
    public void AnimateRotation()
    {
        transform.DORotate(new Vector3(0, 360, 0), rotationDuration, RotateMode.LocalAxisAdd)
            .SetEase(rotationEaseType)
            .SetLoops(-1, LoopType.Restart); // Infinite looping
    }

    // Stop the rotation animation
    public void StopRotation()
    {
        transform.DOKill(); // Stops all animations on the transform
        transform.rotation = Quaternion.identity; // Reset rotation to original
    }
}
