using System.Collections;
using UnityEngine;

public class OrbTouch : MonoBehaviour
{
    [SerializeField] private OrbContents orbContent;

    private bool isTriggerd = false;

    public void OnTriggerEnter()
    {
        if (!isTriggerd)
        {
            //Invoke Audio events 
            SceneEvents.instance.OrbTriggerAudio?.Invoke();
            //Invoke all events when trigger entered
            SceneEvents.instance.OrbTriggered?.Invoke();
            //Set data to UI Event Manager
            UIEventManager.instance.SetData(orbContent);
            GetComponent<ScriptAnimation>().AnimateScale();
            GetComponent<ShaderGraphAlphaController>().FadeIn();
            StartCoroutine(TurnOffObject());
            isTriggerd = true;
        }
    }

    private IEnumerator TurnOffObject()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<ScriptAnimation>().ResetScale();
        yield return new WaitForSeconds(2f);
        GetComponent<ShaderGraphAlphaController>().SetPreviousValue();
        this.gameObject.SetActive(false);
    }
}
