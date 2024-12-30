using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProjectorController : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] TextMeshProUGUI text;

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
        text.text = "When select";
        image.texture = texture;
    }

    public void UnSelected()
    {
        text.text = "When Unselect";
        image.texture = null;
    }

}
