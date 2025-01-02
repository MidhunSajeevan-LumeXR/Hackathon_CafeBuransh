using UnityEngine;
using UnityEngine.Events;

public class OrbTouch : MonoBehaviour
{
    [SerializeField] private OrbContents orbContent;
    [SerializeField] private GameObject controllerOrb;
    public UnityEvent OnTriggerEntered;

    public void OnTriggerEnter()
    {
        controllerOrb.transform.position = this.transform.position;
        controllerOrb.SetActive(true);
        OnTriggerEntered?.Invoke();
        UIEventManager.instance.SetData(orbContent);
        this.gameObject.SetActive(false);
    }
}
