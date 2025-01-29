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
    [SerializeField] private float TextVisibleTime = 5f;
    [Header("UI Buttons")]
    [SerializeField] private GameObject commonButton;
    [SerializeField] private GameObject cafeBuransh;
    [SerializeField] private GameObject chandrashila;

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
        SeperateInteraction(orbContents);
        //Add Description 
        descriptionText.text = orbContents.Data;

        //Set video Clip
        videoPlayer.clip = orbContents.videoClip;

        //Add Hading text 
        tittleText.text = orbContents.Heading;
        tittleText.GetComponent<TextFadeAnimation>().FadeIn();
        tittleText.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = orbContents.Altitude;
        tittleText.transform.GetChild(0).GetComponent<TextFadeAnimation>().FadeIn();

        //tittleText.gameObject.SetActive(true);
        //Wait for seconds before set active and inactive the gameobject
        StartCoroutine(TurnOnOrOffObject(tittleText.gameObject, false));

        for (int i = 0; i < photoSliders.Length; i++)
        {
            photoSliders[i].photoClip = orbContents.PhotoClips[i];
        }
    }

    private void SeperateInteraction(OrbContents contents)
    {
        switch (contents.orbName)
        {
            case "Cafe Buransh":
                // code block
                CafeBuransh();
                Debug.Log("Cafe Buransh");
                break;
            case "Chandrashila":
                Chandrashila();
                Debug.Log("Chandrashila");
                // code block
                break;
            default:
                CommonButtons();
                // code block
                break;
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
        yield return new WaitForSeconds(TextVisibleTime);
        tittleText.GetComponent<TextFadeAnimation>().FadeOut();
        tittleText.transform.GetChild(0).GetComponent<TextFadeAnimation>().FadeOut();
    }

    //Seperate logics for cafe buransh
    private void CafeBuransh()
    {
        cafeBuransh.SetActive(true);
    }

    private void CommonButtons()
    {
        commonButton.SetActive(true);
    }

    private void Chandrashila()
    {
        chandrashila.SetActive(true);
    }
}
