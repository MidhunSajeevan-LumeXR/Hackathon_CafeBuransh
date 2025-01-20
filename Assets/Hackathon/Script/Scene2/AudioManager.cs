using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClip;
    [SerializeField] private AudioClip orbClip;
    [SerializeField] private AudioClip SlideInsert;
    [SerializeField] private AudioClip SlideTake;
    [SerializeField] private AudioClip HomeClip;

    private AudioSource audioSource;

    public static AudioManager instance;

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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SceneEvents.instance.OrbTriggerAudio += OrbTriggered;
        SceneEvents.instance.ButtonClickAudio += ButtonClick;
    }

    private void OrbTriggered()
    {
        audioSource.clip = orbClip;
        audioSource.Play();
    }

    private void ButtonClick()
    {
        audioSource.clip = buttonClip;
        audioSource.Play();
    }

    public void SlideInsertPlay()
    {
        audioSource.clip = SlideInsert;
        audioSource.Play();
    }

    public void SlideTakePlay()
    {
        audioSource.clip = SlideTake;
        audioSource.Play();
    }

    public void HomeTriggered()
    {
        audioSource.clip = HomeClip;
        audioSource.Play();
    }
}
