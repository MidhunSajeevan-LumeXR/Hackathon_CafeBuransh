using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class OnSnapOccured : MonoBehaviour
{
    [SerializeField] private VisualEffect flowerParticles;
    [SerializeField] private AudioSource windAudioSource;
    [SerializeField] private Animator textAnimator;
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private AudioSource introAudioSource;

    private List<GameObject> childrenList;
    private float fadeDuration = 5f;

    // Subscribe to Unity events when the script is enabled
    private void OnEnable()
    {
        // Subscribe to the StartEvents action in the SceneEvents singleton instance
        SceneEvents.instance.StartEvents += SnapOccured;

        // Subscribe to the EndEvents action in the SceneEvents singleton instance
        SceneEvents.instance.EndEvents += EndEvents;
    }

    // Unsubscribe from Unity events when the script is disabled
    private void OnDisable()
    {
        // Unsubscribe from the StartEvents action in the SceneEvents singleton instance
        SceneEvents.instance.StartEvents -= SnapOccured;

        // Unsubscribe from the EndEvents action in the SceneEvents singleton instance
        SceneEvents.instance.EndEvents -= EndEvents;
    }

    private void Start()
    {
        childrenList = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<ObjectRotator>())
            {
                childrenList.Add(child.gameObject);
            }
        }
    }

    public void SnapOccured()
    {
        //Start rotating and play vfx particles effects after snap occured
        StartCoroutine(rotateDelay());
    }

    private IEnumerator rotateDelay()
    {
        // Iterate through the list in reverse order with a delay
        for (int i = 0; i < childrenList.Count; i++)
        {
            var objectRotator = childrenList[i].GetComponent<ObjectRotator>();
            if (objectRotator != null)
            {
                objectRotator.enabled = true;
            }
            yield return new WaitForSeconds(Random.Range(0.5f, 0.9f)); // Delay of 1 second
        }

        //Call OnStart Method for runtime events like audio and flower particles to play
        OnStart();

        //Fade in Tittle 
        yield return new WaitForSeconds(fadeDuration / 2);
        textAnimator.SetBool("ShowTittle", true);

        //Invoke EndEvents before scene change for fade out all objects
        yield return new WaitForSeconds(fadeDuration * 2);

        SceneEvents.instance.InvokeEndEvent();
    }

    public void EndEvents()
    {
        //Find all sprite renderer and fade the alpha to zero
        foreach (GameObject child in childrenList)
        {
            if (child.GetComponent<SpriteRenderer>())
            {
                StartCoroutine(ReduceAlpha(child.GetComponent<SpriteRenderer>()));
            }
        }
    }

    // Public coroutine function to fade the SpriteRenderer's alpha to zero
    private IEnumerator ReduceAlpha(SpriteRenderer renderer)
    {
        Color spriteColor = renderer.color;
        float startAlpha = spriteColor.a; // Store the initial alpha value
        float elapsedTime = 0f; // Track elapsed time

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeDuration); // Lerp alpha over time

            // Apply the new alpha value to the color
            renderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, newAlpha);

            yield return null; // Wait until the next frame
        }

        // Ensure the alpha is exactly zero at the end
        renderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, 0f);

        //Fade out Tittle 
        textAnimator.SetBool("ShowTittle", false);
        //Wait for seceonds for completing fadeout
        yield return new WaitForSeconds(fadeDuration);
        //After all events call next scene 
        GameManager.instance.LoadNextScene();
    }

    private void OnStart()
    {
        flowerParticles.Play();
        windAudioSource.Play();
        bgmAudioSource.Play();
        introAudioSource.Play();
    }
    private void OnEnd()
    {

    }
}
