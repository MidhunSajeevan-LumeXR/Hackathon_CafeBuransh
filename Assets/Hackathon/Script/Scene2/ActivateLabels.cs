using System.Collections;
using UnityEngine;

public class ActivateLabels : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToActivate; // Array of GameObjects to activate
    [SerializeField] private float delay = 1f; // Delay between activations in seconds

    public void Start()
    {
        // Start activating objects with a delay
        StartCoroutine(ActivateObjectsWithDelay());
    }

    // Coroutine to activate GameObjects one by one
    private IEnumerator ActivateObjectsWithDelay()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            if (!obj.activeSelf) // Check if the object is inactive
            {
                obj.SetActive(true);
                obj.GetComponent<LineAnimator>().StartDrawingLine();
                //Debug.Log($"Activated: {obj.name}");
                yield return new WaitForSeconds(delay); // Wait for the specified delay
            }
        }
    }
}
