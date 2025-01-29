using System.Collections;
using UnityEngine;

public class ReloadTrigger : MonoBehaviour
{

    public void TriggerEnter()
    {
        AudioManager.instance.HomeTriggered();
        StartCoroutine(ReloadScene());
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1f);
        GameManager.instance.ReloadScene();
    }
}
