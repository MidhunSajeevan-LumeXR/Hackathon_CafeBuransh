using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class UIEventManager : MonoBehaviour
{
    public static UIEventManager instance;

    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject PhotoPannel;
    [SerializeField] private TextMeshProUGUI descriptionText;

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

    public void SetData(OrbContents orbContents)
    {
        descriptionText.text = orbContents.Data;
        videoPlayer.clip = orbContents.videoClip;
        videoPlayer.Play();
        videoPlayer.loopPointReached += EndReached;

    }

    void EndReached(VideoPlayer vp)
    {
        PhotoPreview = true;
        //vp.playbackSpeed = vp.playbackSpeed / 10.0F;
        PhotoPannel.SetActive(true);
        videoPlayer.gameObject.GetComponent<Animator>().SetBool("PanoramaPannel", false);
    }
}
