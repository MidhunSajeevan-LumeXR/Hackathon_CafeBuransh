using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class OrbTouch : MonoBehaviour
{
    [SerializeField] private OrbContents orbContent;
    [SerializeField] private GameObject controllerOrb;
    public UnityEvent OnTriggerEntered;
    public TextMeshProUGUI text;

    public void OnTriggerEnter(Collider other)
    {
        controllerOrb.transform.position = this.transform.position;
        controllerOrb.SetActive(true);
        text.text = other.name.ToString();
        Debug.Log("Trigger Entered");
        OnTriggerEntered?.Invoke();
        UIEventManager.instance.SetData(orbContent);
    }
}
