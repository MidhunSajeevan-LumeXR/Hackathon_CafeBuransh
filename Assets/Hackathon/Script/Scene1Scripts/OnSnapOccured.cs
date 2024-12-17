using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;


public class OnSnapOccured : MonoBehaviour
{
    [SerializeField] private VisualEffect flowerParticles;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator animator;

    private List<GameObject> childrenList;
    private float fadeDuration = 5f;

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
        for (int i = childrenList.Count - 1; i >= 0; i--)
        {
            var objectRotator = childrenList[i].GetComponent<ObjectRotator>();
            if (objectRotator != null)
            {
                objectRotator.enabled = true;
            }
            yield return new WaitForSeconds(Random.Range(0.5f, 0.9f)); // Delay of 1 second
        }
        flowerParticles.Play();
        audioSource.Play();

        yield return new WaitForSeconds(2f);
        animator.SetBool("ShowTittle", true);

        yield return new WaitForSeconds(5f);
        SceneOneEvents.instance.EndEvent?.Invoke();
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

        //After all events call next scene 
        GameManager.instance.LoadNextScene();
    }
}
