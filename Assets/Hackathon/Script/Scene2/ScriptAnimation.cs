using DG.Tweening;
using UnityEngine;

public class ScriptAnimation : MonoBehaviour
{
    [SerializeField] private float duration = 1f; // Duration of the animation
    [SerializeField] private Ease easeType = Ease.InOutSine; // Type of easing

    private Vector3 originalScale;

    private void Start()
    {
        // Save the original scale for resetting purposes
        originalScale = transform.localScale;
    }

    // Animate scale to 2x the current scale
    public void AnimateScale()
    {
        Vector3 targetScale = originalScale * 2; // Dynamically calculate 2x scale
        transform.DOScale(targetScale, duration).SetEase(easeType);
    }

    // Reset to the original scale
    public void ResetScale()
    {
        transform.DOScale(originalScale, duration).SetEase(easeType);
    }
}
