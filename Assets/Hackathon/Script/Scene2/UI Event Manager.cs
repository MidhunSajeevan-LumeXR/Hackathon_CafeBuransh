using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class UIEventManager : MonoBehaviour
{
    public static UIEventManager instance;

    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject PhotoPannel;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI headingText;

    [SerializeField] private PhotoSlider[] photoSliders;

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

    //Method is called when the orb is triggered
    public void SetData(OrbContents orbContents)
    {
        headingText.text = orbContents.Heading;
        descriptionText.text = orbContents.Data;
        videoPlayer.clip = orbContents.videoClip;
        videoPlayer.Play();
        videoPlayer.loopPointReached += EndReached;
        StartCoroutine(TurnOnOrOffObject(headingText.gameObject, false));

        for (int i = 0; i < photoSliders.Length; i++)
        {
            photoSliders[i].photoClip = orbContents.PhotoClips[i];
        }
    }

    void EndReached(VideoPlayer vp)
    {
        videoPlayer.gameObject.GetComponent<Animator>().SetBool("PanoramaPannel", false);
        //vp.playbackSpeed = vp.playbackSpeed / 10.0F;
        StartCoroutine(TurnOnOrOffObject(PhotoPannel, true));
    }

    private IEnumerator TurnOnOrOffObject(GameObject item, bool value)
    {
        yield return new WaitForSeconds(3f);
        item.SetActive(value);
    }
}
