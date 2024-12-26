using UnityEngine;

public class AnimationComplete : MonoBehaviour
{

    public void OnAnimationComplete()
    {
        SceneEvents.instance.InvokeStartEvent();
    }
}
