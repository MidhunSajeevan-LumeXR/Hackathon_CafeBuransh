using System.Collections;
using UnityEngine;

public class ReloadTrigger : MonoBehaviour
{
    ScriptAnimation scriptAnimation;
    private bool isTriggerd = false;

    private void Start()
    {
        scriptAnimation = GetComponent<ScriptAnimation>();
    }

    private void OnTriggerEnter()
    {
        if (!isTriggerd)
        {
            scriptAnimation.AnimateScale();
            SceneEvents.instance.OrbTriggerAudio?.Invoke();
            StartCoroutine(ReloadScene());
            isTriggerd = true;
        }
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1f);
        scriptAnimation.ResetScale();
        yield return new WaitForSeconds(2f);
        GameManager.instance.ReloadScene();
    }
}
