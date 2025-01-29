using System.Collections;
using UnityEngine;

public class OrbTouch : MonoBehaviour
{
    [SerializeField] private OrbContents orbContent;

    private bool isTriggerd = false;

    private void Start()
    {
        GetComponentInChildren<ScriptAnimation>().AnimateRotation();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!isTriggerd && other.transform.root.CompareTag("Player") && !SceneEvents.instance.OneOrbTriggered)
        {
            SceneEvents.instance.OneOrbTriggered = true;
            GetComponentInChildren<ShaderGraphAlphaController>().FadeIn();
            GetComponent<ScriptAnimation>().AnimateBounce();
            StartCoroutine(AnimateLocationPin());
            //Invoke Audio events 
            SceneEvents.instance.OrbTriggerAudio?.Invoke();

            isTriggerd = true;
        }
    }

    private IEnumerator AnimateLocationPin()
    {
        yield return new WaitForSeconds(1f);
        //Invoke all events when trigger entered
        SceneEvents.instance.OrbTriggered?.Invoke();
        //Set data to UI Event Manager
        UIEventManager.instance.SetData(orbContent);

        StartCoroutine(TurnOffObject());
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
