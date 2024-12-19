using UnityEngine;

public class LoadToNextScene : MonoBehaviour
{
    public static LoadToNextScene instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


}
