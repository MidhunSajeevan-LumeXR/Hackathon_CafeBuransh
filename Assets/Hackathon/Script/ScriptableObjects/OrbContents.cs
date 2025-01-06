using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "OrbContentData", menuName = "ScriptableObjects/OrbContents", order = 1)]
public class OrbContents : ScriptableObject
{
    [Header("Basic Info")]
    public string orbName; // Renamed to avoid confusion with the base class `name`
    public VideoClip videoClip;
    public Photo[] PhotoClips;

    [SerializeField, TextArea(3, 10)]
    public string Heading;

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
