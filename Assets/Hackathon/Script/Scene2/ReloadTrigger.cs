using System.Collections;
using UnityEngine;

public class ReloadTrigger : MonoBehaviour
{
    ScriptAnimation scriptAnimation;

    private void Start()
    {
        scriptAnimation = GetComponent<ScriptAnimation>();
    }

    private void OnTriggerEnter()
    {
        scriptAnimation.AnimateScale();
        SceneEvents.instance.OrbAudioTrigger?.Invoke();
        StartCoroutine(ReloadScene());
    }

    private void OnTriggerExit()
    {
        scriptAnimation.ResetScale();
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.ReloadScene();
    }
}
