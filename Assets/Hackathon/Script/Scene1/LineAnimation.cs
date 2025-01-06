using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineAnimation : MonoBehaviour
{
    [SerializeField] private float animationDuration = 5f;

    private LineRenderer lineRenderer;
    private Vector3[] linePoints;
    private GameObject[] orbs;
    private int pointsCount;

    private void Start()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer is not found in children!");
            return;
        }

        var orbList = new List<GameObject>();
        foreach (Transform child in transform)
        {
            Transform orbChild = child.Find("Orb");
            if (orbChild != null)
            {
                orbList.Add(orbChild.gameObject);
                orbChild.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning($"Child named 'Orb' not found under {child.name}.");
            }
        }
        orbs = orbList.ToArray();
    }

    public void StartDrawingLine()
    {
        InitializeLinePoints();
        StartCoroutine(AnimateLine(forward: true));
    }

    public void StartRedrawingLine()
    {
        animationDuration = 1.5f;
        InitializeLinePoints();
        // Activate the child GameObjects after animation completes
        foreach (var orb in orbs)
        {
            if (orb != null)
            {
                orb.SetActive(false);
            }
        }
        StartCoroutine(AnimateLine(forward: false));
    }

    private void InitializeLinePoints()
    {
        pointsCount = lineRenderer.positionCount;
        linePoints = new Vector3[pointsCount];
        for (int i = 0; i < pointsCount; i++)
        {
            linePoints[i] = lineRenderer.GetPosition(i);
        }
    }

    private IEnumerator AnimateLine(bool forward)
    {
        if (linePoints == null || linePoints.Length == 0)
        {
            Debug.LogError("Line points are not initialized. Call InitializeLinePoints first.");
            yield break;
        }

        float segmentDuration = animationDuration / (pointsCount - 1);
        lineRenderer.enabled = true;

        if (!forward)
        {
            System.Array.Reverse(linePoints); // Reverse the points for redrawing
        }

        for (int i = 0; i < pointsCount - 1; i++)
        {
            float startTime = Time.time;

            Vector3 startPosition = linePoints[i];
            Vector3 endPosition = linePoints[i + 1];

            while (Time.time - startTime < segmentDuration)
            {
                float t = (Time.time - startTime) / segmentDuration;
                Vector3 pos = Vector3.Lerp(startPosition, endPosition, t);

                if (i + 1 < lineRenderer.positionCount)
                {
                    lineRenderer.SetPosition(i + 1, pos);
                }

                yield return null;
            }

            // Ensure the endpoint is set correctly
            if (i + 1 < lineRenderer.positionCount)
            {
                lineRenderer.SetPosition(i + 1, endPosition);
            }
        }

        // Activate the child GameObjects after animation completes
        foreach (var orb in orbs)
        {
            if (orb != null)
            {
                orb.SetActive(forward);
            }
        }
    }
}
