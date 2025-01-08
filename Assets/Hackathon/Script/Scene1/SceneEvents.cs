using UnityEngine;
using UnityEngine.Events;

public class SceneEvents : MonoBehaviour
{
    public static SceneEvents instance;

    public UnityEvent StartEvent;
    public UnityEvent EndEvent;

    //Scene one Starting Events

    public UnityAction StartEvents;
    public UnityAction EndEvents;

    //Scene orb touch Events
    public UnityAction OrbTriggered;

    //Scene Audio Events
    public UnityAction ButtonClick;
    public UnityAction OrbAudioTrigger;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Method for invoking the Start events
    public void InvokeStartEvent()
    {
        // Safely invoke the StartEvent action if it has subscribers
        StartEvent?.Invoke();

        // Safely invoke the StartEvents action if it has subscribers
        StartEvents?.Invoke();
    }

    // Method for invoking the End events
    public void InvokeEndEvent()
    {
        // Safely invoke the EndEvent action if it has subscribers
        EndEvent?.Invoke();

        // Safely invoke the EndEvents action if it has subscribers
        EndEvents?.Invoke();
    }

    public void InvokeButtonClick()
    {
        // Safely invoke the Button action if it has subscribers
        ButtonClick?.Invoke();
    }
}
