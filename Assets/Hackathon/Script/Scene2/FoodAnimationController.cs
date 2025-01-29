using System.Collections;
using UnityEngine;

public class FoodAnimationController : MonoBehaviour
{
    [SerializeField] private GameObject[] children;

    private void OnEnable()
    {
        for (int i = 0; i < children.Length; i++)
        {
            children[i].SetActive(false);
        }
        StartCoroutine(ChildrenStatus(true));

    }

    private IEnumerator ChildrenStatus(bool status)
    {
        foreach (var child in children)
        {
            child.gameObject.SetActive(status);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
