using System.Collections;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Transform startPos; // The parent position
    private Transform endPos;   // The child position

    private Vector3 originalChildPosition; // To store the original position of the child

    [SerializeField] private float moveDuration = 5f; // Duration for the child to move

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        startPos = this.gameObject.transform.parent.transform;
        endPos = this.gameObject.transform.GetChild(0);

        originalChildPosition = endPos.position; // Store the original position of the child
        lineRenderer.positionCount = 2;
        UpdateLine();
    }

    // Method to update the line renderer positions
    private void UpdateLine()
    {
        lineRenderer.SetPosition(0, startPos.position);
        lineRenderer.SetPosition(1, endPos.position);
    }

    // Method to move the child 30 units up in the Y direction
    public void MoveChildUp()
    {
        StopAllCoroutines(); // Stop any ongoing coroutines
        Vector3 targetPosition = endPos.position + new Vector3(0, 30, 0); // Move only along Y-axis
        StartCoroutine(MoveChild(endPos.position, targetPosition));
    }

    // Method to move the child back to its original position
    public void MoveChildBack()
    {
        StopAllCoroutines(); // Stop any ongoing coroutines
        StartCoroutine(MoveChild(endPos.position, originalChildPosition));
    }

    // Coroutine to handle child movement and line drawing
    private IEnumerator MoveChild(Vector3 fromPosition, Vector3 toPosition)
    {
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;

            // Interpolate the child's position
            endPos.position = Vector3.Lerp(fromPosition, toPosition, elapsedTime / moveDuration);

            // Update the line renderer to reflect the new position
            UpdateLine();

            yield return null; // Wait for the next frame
        }

        // Ensure the final position is correctly set
        endPos.position = toPosition;
        UpdateLine();
    }
}
