using UnityEngine;
using UnityEngine.Events;

public class SceneEvents : MonoBehaviour
{
    public static SceneEvents instance;

    public UnityEvent StartEvent;
    public UnityEvent EndEvent;
    // Start is called before the first frame update
    void Start()
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

    public void InvokeStartEvent()
    {
        StartEvent?.Invoke();
    }
    public void InvokeEndEvent()
    {
        EndEvent?.Invoke();
    }
}
