using UnityEngine;

public class LineAnimationController : MonoBehaviour
{
    //private List<LineAnimation> lineAnimations = new List<LineAnimation>(); // Initialize the list
    private SimpleLineDrawer simpleLineDrawer;

    void Start()
    {
        simpleLineDrawer = GetComponent<SimpleLineDrawer>();
        SceneEvents.instance.StartEvents += StartLineDraw;
    }

    // Method to start line drawing for all animations
    public void StartLineDraw()
    {
        simpleLineDrawer.DrawLinesForward();
    }

    // Method to start line Redrawing for all animations
    public void StartLineRedraw()
    {
        simpleLineDrawer.DrawLinesBackward();
    }
}
