using UnityEngine;

public class CloudController : MonoBehaviour
{
    void Start()
    {
        SceneEvents.instance.StartEvents += TurnOnObject;
        SceneEvents.instance.OrbTriggered += TurnOffObject;
        TurnOffObject();
    }

    void TurnOnObject()
    {
        this.gameObject.SetActive(true);
    }

    void TurnOffObject()
    {
        this.gameObject.SetActive(false);
    }

}
