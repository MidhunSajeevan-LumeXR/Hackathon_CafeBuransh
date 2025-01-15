using UnityEngine;

public class Trigger : MonoBehaviour
{

    private void OnTriggerEnter()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnTriggerExit()
    {
        transform.GetChild(0).gameObject.SetActive(false);

    }
}
