using System.Collections;
using DG.Tweening;
using UnityEngine;

public class ScriptAnimation : MonoBehaviour
{
    [SerializeField] private float duration = 1f; // Duration of the animation
    [SerializeField] private Ease easeType = Ease.InOutSine; // Type of easing

    [SerializeField] private Material targetMaterial; // Assign your Shader Graph material here
    [SerializeField] private float fadeDuration = 1f; // Duration of the fade effect

    private Coroutine coroutine;

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
        AnimateAlpha(0, true);
    }

    // Reset to the original scale
    public void ResetScale()
    {
        transform.DOScale(originalScale, duration).SetEase(easeType);
        ResetAlpha();
    }

    // Animate the material _Alpha to fade out
    public void AnimateAlpha(float targetAlpha, bool status)
    {
        coroutine = StartCoroutine(FadeAlpha(targetAlpha, status));
    }

    // Reset _Alpha back to 1 (fully visible)
    public void ResetAlpha()
    {
        AnimateAlpha(0.5f, false);
    }
    // Coroutine to fade _Alpha
    private IEnumerator FadeAlpha(float targetAlpha, bool status)
    {
        if (!targetMaterial.HasProperty("_Alpha"))
        {
            Debug.LogError("Material does not have an '_Alpha' property!");
            yield break;
        }

        float startAlpha = targetMaterial.GetFloat("_Alpha");
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            targetMaterial.SetFloat("_Alpha", newAlpha);
            yield return null;
        }

        // Ensure the alpha is set to the exact target value at the end
        targetMaterial.SetFloat("_Alpha", targetAlpha);

        this.gameObject.SetActive(status);
    }
}
