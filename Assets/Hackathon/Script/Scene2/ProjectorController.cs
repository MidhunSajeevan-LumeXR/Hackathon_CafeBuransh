using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProjectorController : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] TextMeshProUGUI text;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PhotoSlider>())
        {
            image.texture = other.gameObject.GetComponent<PhotoSlider>().photoClip.Image;
        }

    }
    public void OnTriggerExit()
    {
        image.texture = null;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
