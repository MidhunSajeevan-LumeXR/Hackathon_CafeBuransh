using UnityEngine;

public class PhotoSlider : MonoBehaviour
{
    [HideInInspector]
    public Photo photoClip;

    [SerializeField]
    public GameObject refMaterial;

    private void Start()
    {
        refMaterial.GetComponent<MeshRenderer>().material.mainTexture = photoClip.Image;
    }
}
