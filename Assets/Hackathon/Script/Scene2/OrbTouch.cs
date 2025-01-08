using UnityEngine;

public class OrbTouch : MonoBehaviour
{
    [SerializeField] private OrbContents orbContent;

    public void OnTriggerEnter()
    {
        //Invoke Audio events 
        SceneEvents.instance.OrbAudioTrigger?.Invoke();
        //Invoke all events when trigger entered
        SceneEvents.instance.OrbTriggered?.Invoke();
        //Set data to UI Event Manager
        UIEventManager.instance.SetData(orbContent);

        GetComponent<ScriptAnimation>().AnimateScale();
    }

    private void OnTriggerExit()
    {
        GetComponent<ScriptAnimation>().ResetScale();
    }
}
