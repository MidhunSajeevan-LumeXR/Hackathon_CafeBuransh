using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class UIEventManager : MonoBehaviour
{
    public static UIEventManager instance;

    [SerializeField] private VideoPlayer videoPlayer;

    public UnityEvent OrbSelected;

    private void Start()
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

    public void SetData(OrbContents orbContents)
    {
        OrbSelected?.Invoke();
        Debug.Log("Data writed");
        videoPlayer.clip = orbContents.videoClip;
        videoPlayer.Play();
    }
}
