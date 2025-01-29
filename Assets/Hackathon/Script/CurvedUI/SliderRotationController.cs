using UnityEngine;
using DG.Tweening;

public class RotationController : MonoBehaviour
{
    [SerializeField] private Transform sliderObject; // The object whose Y rotation represents the "slider"
    [SerializeField] private Transform targetObject; // The object to rotate based on the slider
    [SerializeField] private float animationDuration = 0.5f; // Duration of the rotation animation
    [SerializeField] private Ease easeType = Ease.InOutSine; // Type of easing for the animation

    private float previousSliderYRotation;

    private void Start()
    {
        if (sliderObject == null || targetObject == null)
        {
            Debug.LogError("SliderObject or TargetObject is not assigned in the inspector.");
            return;
        }

        // Initialize previousSliderYRotation to the starting Y rotation of the sliderObject
        previousSliderYRotation = sliderObject.eulerAngles.y;
    }

    private void Update()
    {
        // Get the current Y rotation of the sliderObject
        float currentSliderYRotation = sliderObject.eulerAngles.y;

        // Check if the slider's rotation has changed
        if (!Mathf.Approximately(currentSliderYRotation, previousSliderYRotation))
        {
            // Calculate the target rotation angle (2x the slider's Y rotation)
            float targetRotationAngle = 20 * currentSliderYRotation;

            // Apply rotation to the targetObject using DoTween
            targetObject.DORotate(new Vector3(0, targetRotationAngle, 0), animationDuration)
                .SetEase(easeType);

            // Update the previous rotation value
            previousSliderYRotation = currentSliderYRotation;
        }
    }
}
