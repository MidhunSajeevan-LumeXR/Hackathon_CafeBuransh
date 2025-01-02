using UnityEngine;

public class ReloadTrigger : MonoBehaviour
{

    private void OnTriggerEnter()
    {
        GameManager.instance.ReloadScene();
    }
}
