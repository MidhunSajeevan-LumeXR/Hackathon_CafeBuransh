using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClip;
    [SerializeField] private AudioClip orbClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SceneEvents.instance.OrbAudioTrigger += OrbTriggered;
        SceneEvents.instance.ButtonClick += ButtonClick;
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
}
