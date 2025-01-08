using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class UIEventManager : MonoBehaviour
{
    public static UIEventManager instance;

    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject ProjectorItems;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI tittleText;

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
        //Add Description 
        descriptionText.text = orbContents.Data;
        //Set video Clip
        videoPlayer.clip = orbContents.videoClip;
        //Add Hading text 
        tittleText.text = orbContents.Heading;

        //Subcribe to loop Point reached for check video stoped
        //     videoPlayer.loopPointReached += EndReached;

        //Wait for seconds before set active and inactive the gameobject
        StartCoroutine(TurnOnOrOffObject(tittleText.gameObject, false));

        for (int i = 0; i < photoSliders.Length; i++)
        {
            photoSliders[i].photoClip = orbContents.PhotoClips[i];
        }
    }

    void EndReached(VideoPlayer vp)
    {
        //Set Active false if video completed
        videoPlayer.gameObject.GetComponent<Animator>().SetBool("PanoramaPannel", false);
        //Set Active true for Projector view
        ProjectorItems.SetActive(true);
    }

    private IEnumerator TurnOnOrOffObject(GameObject item, bool value)
    {
        yield return new WaitForSeconds(3f);
        item.SetActive(value);
    }
}
