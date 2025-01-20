using System.Collections;
using TMPro;
using UnityEngine;

public class ReloadTrigger : MonoBehaviour
{
    ScriptAnimation scriptAnimation;
    private bool isTriggerd = false;

    private void Start()
    {
        scriptAnimation = GetComponent<ScriptAnimation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggerd && other.transform.root.CompareTag("Player"))
        {
            scriptAnimation.AnimateScale();
            AudioManager.instance.HomeTriggered();
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
