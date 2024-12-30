using UnityEngine;

[CreateAssetMenu(fileName = "Photo", menuName = "ScriptableObjects/PhotoSlides")]
public class Photo : ScriptableObject
{
    [Header("Basic Info")]
    public string PhotoName; // Renamed to avoid confusion with the base class `name`
    public Texture2D Image;

    [Header("Additional Data")]
    [SerializeField, TextArea(3, 50)]
    private string data; // Serialized private field for encapsulation

    // Public property to access 'data' safely
    public string Data
    {
        get => data;
        set => data = value;
    }
}
