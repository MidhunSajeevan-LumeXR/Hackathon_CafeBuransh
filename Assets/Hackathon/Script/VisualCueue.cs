using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using TMPro;
using UnityEngine;

public class VisualCueue : MonoBehaviour
{
    [SerializeField] private GameObject FlowerVisual;

    [SerializeField] private GrabInteractable grabInteractable;

    public TextMeshProUGUI textMeshProUGUI;

    private void OnEnable()
    {
        grabInteractable.WhenInteractorViewAdded += OnGrabStarted;
        grabInteractable.WhenStateChanged += OnGrabEnded;

    }

    private void OnDisable()
    {
        grabInteractable.WhenInteractorViewAdded -= OnGrabStarted;
        grabInteractable.WhenStateChanged -= OnGrabEnded;
    }

    private void OnGrabStarted(IInteractorView args)
    {
        textMeshProUGUI.text = "Object grabbed!";
        if (grabInteractable.State == InteractableState.Select && !FlowerVisual.activeSelf)
        {
            FlowerVisual.SetActive(true);
        }
    }

    private void OnGrabEnded(InteractableStateChangeArgs args)
    {
        textMeshProUGUI.text = "Object released!";
        if (grabInteractable.State == InteractableState.Select && !FlowerVisual.activeSelf)
        {
            FlowerVisual.SetActive(true);
        }
        if (grabInteractable.State == InteractableState.Normal && FlowerVisual.activeSelf)
        {
            FlowerVisual.SetActive(false);
        }
    }
    private void Update()
    {

        // if (handGrab.State == InteractableState.Select && !FlowerVisual.activeSelf)
        // {
        //     FlowerVisual.SetActive(true);
        // }
        // else if (handGrab.State == InteractableState.Normal && FlowerVisual.activeSelf)
        // {
        //     FlowerVisual.SetActive(false);

        // }
    }
}
