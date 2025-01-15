using UnityEngine;
using System.Collections;

public class ShaderGraphAlphaController : MonoBehaviour
{
    [SerializeField] private Material targetMaterial; // Assign the Shader Graph material
    [SerializeField] private float fadeDuration = 1f; // Duration of the fade effect
    [SerializeField] private bool isFadeIn = false; // Control fade direction from the Inspector

    private Coroutine fadeCoroutine;

    private void Start()
    {
        if (targetMaterial == null)
        {
            Debug.LogError("Target material is not assigned!");
        }

        if (!targetMaterial.HasProperty("_Alpha"))
        {
            Debug.LogError("Material does not have an '_Alpha' property!");
        }
    }

    /// <summary>
    /// Fade in: Alpha increases from current value to 1, then returns to the original value.
    /// </summary>
    public void FadeIn()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(FadeInRoutine());
    }

    /// <summary>
    /// Fade out: Alpha decreases from current value to 0.
    /// </summary>
    public void FadeOut()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(FadeOutRoutine());
    }

    public void SetPreviousValue()
    {
        targetMaterial.SetFloat("_Alpha", 0.5f);
    }

    private IEnumerator FadeInRoutine()
    {
        if (!targetMaterial.HasProperty("_Alpha"))
        {
            Debug.LogError("Material does not have an '_Alpha' property!");
            yield break;
        }

        float startAlpha = targetMaterial.GetFloat("_Alpha");
        float elapsedTime = 0f;

        // Step 1: Fade from current alpha to 1
        while (elapsedTime < fadeDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, 1f, elapsedTime / (fadeDuration / 2));
            targetMaterial.SetFloat("_Alpha", newAlpha);
            yield return null;
        }

        // Step 2: Fade back to the original alpha
        elapsedTime = 0f;
        while (elapsedTime < fadeDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(1f, startAlpha, elapsedTime / (fadeDuration / 2));
            targetMaterial.SetFloat("_Alpha", newAlpha);
            yield return null;
        }

        targetMaterial.SetFloat("_Alpha", startAlpha); // Ensure exact value
        fadeCoroutine = null;
    }

    private IEnumerator FadeOutRoutine()
    {
        if (!targetMaterial.HasProperty("_Alpha"))
        {
            Debug.LogError("Material does not have an '_Alpha' property!");
            yield break;
        }

        float startAlpha = targetMaterial.GetFloat("_Alpha");
        float elapsedTime = 0f;

        // Fade to 0
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeDuration);
            targetMaterial.SetFloat("_Alpha", newAlpha);
            yield return null;
        }

        targetMaterial.SetFloat("_Alpha", 0f); // Ensure exact value
        fadeCoroutine = null;
    }
}
