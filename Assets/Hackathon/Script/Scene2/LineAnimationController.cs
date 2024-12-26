using System.Collections.Generic;
using UnityEngine;

public class LineAnimationController : MonoBehaviour
{
    private List<LineAnimation> lineAnimations = new List<LineAnimation>(); // Initialize the list

    void Start()
    {
        // Loop through all child transforms
        foreach (Transform child in transform)
        {
            LineAnimation lineAnimation = child.GetComponent<LineAnimation>();
            if (lineAnimation != null)
            {
                lineAnimations.Add(lineAnimation);
            }
        }
    }

    // Method to start line drawing for all animations
    public void StartLineDraw()
    {
        foreach (LineAnimation line in lineAnimations)
        {
            line.StartDrawingLine();
        }
    }

    // Method to start line Redrawing for all animations
    public void StartLineRedraw()
    {
        foreach (LineAnimation line in lineAnimations)
        {
            line.StartRedrawingLine();
        }
    }
}
