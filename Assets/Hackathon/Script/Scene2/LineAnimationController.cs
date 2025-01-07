using System.Collections.Generic;
using UnityEngine;

public class LineAnimationController : MonoBehaviour
{
    //private List<LineAnimation> lineAnimations = new List<LineAnimation>(); // Initialize the list
    private SimpleLineDrawer simpleLineDrawer;

    void Start()
    {
        // Loop through all child transforms
        // foreach (Transform child in transform)
        // {
        //     LineAnimation lineAnimation = child.GetComponent<LineAnimation>();
        //     if (lineAnimation != null)
        //     {
        //         lineAnimations.Add(lineAnimation);
        //     }
        // }
        simpleLineDrawer = GetComponent<SimpleLineDrawer>();
    }

    // Method to start line drawing for all animations
    public void StartLineDraw()
    {
        // foreach (LineAnimation line in lineAnimations)
        // {
        //     line.StartDrawingLine();
        // }
        simpleLineDrawer.DrawLinesForward();
    }

    // Method to start line Redrawing for all animations
    public void StartLineRedraw()
    {
        // foreach (LineAnimation line in lineAnimations)
        // {
        //     line.StartRedrawingLine();
        // }
        simpleLineDrawer.DrawLinesBackward();
    }
}
