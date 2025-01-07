using UnityEngine;

public class SimpleLineDrawer : MonoBehaviour
{
    private LineRenderer[] lineRenderers; // Array of LineRenderers

    [SerializeField] private float animationDuration = 2f; // Duration for the line animation

    private void Start()
    {
        lineRenderers = transform.GetComponentsInChildren<LineRenderer>();
    }

    public void DrawLinesForward()
    {
        foreach (LineRenderer lineRenderer in lineRenderers)
        {
            if (lineRenderer != null)
            {
                StartCoroutine(DrawLine(lineRenderer, forward: true));
            }
            else
            {
                Debug.LogWarning("One of the LineRenderers in the array is null!");
            }
        }
    }

    public void DrawLinesBackward()
    {
        //Turn of the orb first before line animation
        OrbController(false);

        //Reduce time when draw line backward
        animationDuration = animationDuration / 5;
        foreach (LineRenderer lineRenderer in lineRenderers)
        {
            if (lineRenderer != null)
            {
                StartCoroutine(DrawLine(lineRenderer, forward: false));
            }
            else
            {
                Debug.LogWarning("One of the LineRenderers in the array is null!");
            }
        }
    }

    private System.Collections.IEnumerator DrawLine(LineRenderer lineRenderer, bool forward)
    {
        int pointsCount = lineRenderer.positionCount;
        Vector3[] linePoints = new Vector3[pointsCount];
        for (int i = 0; i < pointsCount; i++)
        {
            linePoints[i] = lineRenderer.GetPosition(i);
        }

        if (!forward)
        {
            System.Array.Reverse(linePoints); // Reverse the points for backward animation
        }

        lineRenderer.enabled = true;

        // Gradually draw the line segment by segment
        for (int i = 0; i < pointsCount - 1; i++)
        {
            float startTime = Time.time;
            Vector3 startPosition = linePoints[i];
            Vector3 endPosition = linePoints[i + 1];

            while (Time.time - startTime < animationDuration / pointsCount)
            {
                float t = (Time.time - startTime) / (animationDuration / pointsCount);
                Vector3 currentPosition = Vector3.Lerp(startPosition, endPosition, t);
                lineRenderer.SetPosition(i + 1, currentPosition);
                yield return null;
            }

            lineRenderer.SetPosition(i + 1, endPosition);
        }
        OrbController(forward);
    }

    private void OrbController(bool state)
    {
        foreach (var child in lineRenderers)
        {
            child.transform.GetChild(0).gameObject.SetActive(state);
        }
    }
}
