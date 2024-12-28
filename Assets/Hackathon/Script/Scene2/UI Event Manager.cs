using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class UIEventManager : MonoBehaviour
{
    public static UIEventManager instance;

    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject PhotoPannel;

    private bool PhotoPreview = false;

    private void Awake()
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

    public void Update()
    {

    }

    public void SetData(OrbContents orbContents)
    {
        videoPlayer.clip = orbContents.videoClip;
        videoPlayer.Play();
        videoPlayer.loopPointReached += EndReached;

    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        PhotoPreview = true;
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
        PhotoPannel.SetActive(true);
        videoPlayer.gameObject.GetComponent<Animator>().SetBool("PanoramaPannel", false);
    }
}
