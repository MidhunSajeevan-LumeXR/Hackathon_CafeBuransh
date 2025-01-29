using DG.Tweening;
using UnityEngine;

public class ScriptAnimation : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float duration = 1f; // Duration of the scale animation
    [SerializeField] private float bounceDepth = 1f; // Depth of the downward movement
    [SerializeField] private float bounceDuration = 0.5f; // Duration for the bounce
    [SerializeField] private Ease easeType = Ease.Linear; // Easing type for rotation
    [SerializeField] private float rotationAngle = 45f; // Rotation angle for Y-axis
    [SerializeField] private float rotationDuration = 1f; // Duration for a single rotation loop
    [SerializeField] private Ease rotationEaseType = Ease.Linear; // Easing type for rotation
    [SerializeField] private float scaleValue = 2f;
    [Header("Position Animation")]
    [SerializeField] private Transform startPositionOffset; // Offset for starting position
    [SerializeField] private Vector3 endPositionOffset; // Offset for resetting position
    [Header("Tranparency Animation")]
    [SerializeField] private Material targetMaterial; // Material to animate
    [SerializeField] private string alphaProperty = "_Color"; // Shader property for color (default: "_Color")\
    [Header("Animations")]
    [SerializeField] private bool ScaleAnimation;
    [SerializeField] private bool PositionAnimation;
    [SerializeField] private bool RotateAnimation;
    [SerializeField] private bool FadeAnimation;
    [SerializeField] private bool setActiveFalseAfterReset = false; // Whether to deactivate after reset
    private Vector3 originalScale;
    private Vector3 originalPosition;

    private void Awake()
    {
        // Save the original scale and position
        originalScale = transform.localScale;
        originalPosition = transform.position;
    }

    private void OnEnable()
    {

        //Activate Scale animaiton on Start
        if (ScaleAnimation)
        {
            AnimateScale();
        }
        if (RotateAnimation)
        {
            AnimateRotation();
        }
        if (FadeAnimation)
        {
            FadeIn();
        }
        //Activate Scale animaiton on Start
        if (PositionAnimation)
        {
            AnimatePosition();
        }

    }

    private void OnDisable()
    {
        //Deactivate Scale animaiton on Start
        if (ScaleAnimation)
        {
            ResetScale();
        }
        if (RotateAnimation)
        {
            StopRotation();
        }
        if (FadeAnimation)
        {
            FadeOut();
        }
        //Activate Pos animaiton on Start
        if (PositionAnimation)
        {
            ResetPosition();
        }
    }

    // Animate scale to 2x the current scale
    public void AnimateScale()
    {
        if (setActiveFalseAfterReset)
        {
            this.gameObject.SetActive(true);
        }
        Vector3 targetScale = originalScale * scaleValue; // Dynamically calculate 2x scale
        transform.DOScale(targetScale, duration).SetEase(easeType);
    }

    // Reset to the original scale
    public void ResetScale()
    {
        transform.DOScale(originalScale, duration)
            .SetEase(easeType)
            .OnComplete(() =>
            {
                if (setActiveFalseAfterReset)
                {
                    this.gameObject.SetActive(false);
                }
            });
    }

    // Animate position
    public void AnimatePosition()
    {
        endPositionOffset = transform.position;
        if (setActiveFalseAfterReset)
        {
            this.gameObject.SetActive(true);
        }

        // Calculate target position
        Vector3 targetPosition = startPositionOffset.position;

        // Animate position
        transform.DOMove(targetPosition, duration).SetEase(easeType);
    }

    // Reset position
    public void ResetPosition()
    {
        Vector3 resetPosition = endPositionOffset;

        // Animate position back to reset
        transform.DOMove(resetPosition, duration)
            .SetEase(easeType)
            .OnComplete(() =>
            {
                if (setActiveFalseAfterReset)
                {
                    this.gameObject.SetActive(false);
                }
            });
    }

    // Fade in: Increase alpha to 1 (fully visible)
    public void FadeIn()
    {
        if (targetMaterial != null && targetMaterial.HasProperty("_Color"))
        {
            Color currentColor = targetMaterial.color; // Get the current color
            float currentAlpha = currentColor.a;       // Get the alpha value
            DOTween.To(() => currentAlpha, x =>
            {
                currentColor.a = x;                    // Update alpha
                targetMaterial.color = currentColor;   // Apply updated color
            }, 1f, duration)                           // Target alpha: 1 (fully visible)
            .SetEase(easeType);
        }
        else
        {
            Debug.LogError("Material does not have a '_Color' property");
        }
    }

    // Fade out: Decrease alpha to 0 (fully transparent)
    public void FadeOut()
    {
        if (targetMaterial != null && targetMaterial.HasProperty("_Color"))
        {
            Color currentColor = targetMaterial.color; // Get the current color
            float currentAlpha = currentColor.a;       // Get the alpha value
            DOTween.To(() => currentAlpha, x =>
            {
                currentColor.a = x;                    // Update alpha
                targetMaterial.color = currentColor;   // Apply updated color
            }, 0f, duration)                           // Target alpha: 0 (fully transparent)
            .SetEase(easeType);
        }
        else
        {
            Debug.LogError("Material does not have a '_Color' property");
        }
    }

    // Animate a single downward bounce and return to the original position
    public void AnimateBounce()
    {
        Sequence bounceSequence = DOTween.Sequence();

        // Downward movement
        bounceSequence.Append(
            transform.DOMoveY(originalPosition.y - bounceDepth, bounceDuration / 2)
            .SetEase(easeType)
        );

        // Return to original position
        bounceSequence.Append(
            transform.DOMoveY(originalPosition.y, bounceDuration / 2)
            .SetEase(easeType)
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
