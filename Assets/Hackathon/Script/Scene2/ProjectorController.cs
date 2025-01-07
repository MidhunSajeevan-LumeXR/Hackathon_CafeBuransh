using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProjectorController : MonoBehaviour
{
    [SerializeField] RawImage image;

    private Texture2D texture;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PhotoSlider>())
        {
            texture = other.gameObject.GetComponent<PhotoSlider>().photoClip.Image;
        }

    }

    public void Selected()
    {
        image.texture = texture;
    }

    public void UnSelected()
    {
        image.texture = null;
    }

}
