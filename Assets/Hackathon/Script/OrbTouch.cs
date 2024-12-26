using UnityEngine;
using UnityEngine.Events;

public class OrbTouch : MonoBehaviour
{
    [SerializeField] private OrbContents orbContent;
    public UnityEvent OnTriggerEntered;

    public void OnTriggerEnter()
    {
        Debug.Log("Trigger Entered");
        OnTriggerEntered?.Invoke();
        UIEventManager.instance.SetData(orbContent);
    }
}
