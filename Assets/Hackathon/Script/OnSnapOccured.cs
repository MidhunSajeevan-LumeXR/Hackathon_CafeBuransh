using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnSnapOccured : MonoBehaviour
{
    private List<GameObject> childrenList;

    private void Start()
    {
        childrenList = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<ObjectRotator>())
                childrenList.Add(child.gameObject);
        }
    }

    public void SnapOccured()
    {
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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
