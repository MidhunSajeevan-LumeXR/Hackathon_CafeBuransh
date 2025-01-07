using UnityEngine;

public class OrbTouch : MonoBehaviour
{
    [SerializeField] private OrbContents orbContent;

    public void OnTriggerEnter()
    {
        //Invoke all events when trigger entered
        SceneEvents.instance.OrbTriggered?.Invoke();
        //Set data to UI Event Manager
        UIEventManager.instance.SetData(orbContent);
        //Set Active false this GameObject
        this.gameObject.SetActive(false);
    }

}
