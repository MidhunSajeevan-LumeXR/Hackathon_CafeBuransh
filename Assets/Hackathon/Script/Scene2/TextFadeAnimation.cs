using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextFadeAnimation : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI targetText;
    [SerializeField] private float duration = 1f;       // Duration of the animation
    [SerializeField] private Ease easeType = Ease.InOutSine; // Type of easing
    [SerializeField] private bool TextAnimation = false;

    private void OnEnable()
    {
        if (TextAnimation)
        {
            FadeIn();
        }
    }
    private void OnDisable()
    {
        if (TextAnimation)
        {
            FadeOut();
        }
    }

    // Fade in: Increase alpha to 1 (fully visible)
    public void FadeIn()
    {
        if (targetText != null)
        {
            Color currentColor = targetText.color; // Get the current color
            float currentAlpha = currentColor.a;   // Get the alpha value
            DOTween.To(() => currentAlpha, x =>
            {
                currentColor.a = x;                // Update alpha
                targetText.color = currentColor;   // Apply updated color
            }, 1f, duration)                       // Target alpha: 1 (fully visible)
            .SetEase(easeType);
        }
        else
        {
            Debug.LogError("Target TextMeshProUGUI is not assigned.");
        }
    }

    // Fade out: Decrease alpha to 0 (fully transparent)
    public void FadeOut()
    {
        if (targetText != null)
        {
            Color currentColor = targetText.color; // Get the current color
            float currentAlpha = currentColor.a;   // Get the alpha value
            DOTween.To(() => currentAlpha, x =>
            {
                currentColor.a = x;                // Update alpha
                targetText.color = currentColor;   // Apply updated color
            }, 0f, duration)                       // Target alpha: 0 (fully transparent)
            .SetEase(easeType);
        }
        else
        {
            Debug.LogError("Target TextMeshProUGUI is not assigned.");
        }
    }
}
