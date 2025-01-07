using UnityEngine;

public class AnimationContoller : MonoBehaviour
{
    [SerializeField] GameObject panoramicPannel;
    [SerializeField] GameObject ControllerOrb;

    private Animator animator;
    private LineAnimationController lineAnimationController;


    private void Start()
    {
        lineAnimationController = transform.parent.GetComponentInChildren<LineAnimationController>();
        animator = GetComponent<Animator>();
        SceneEvents.instance.OrbTriggered += OnOrbTriggered;
    }

    public void OnAnimationComplete()
    {
        SceneEvents.instance.InvokeStartEvent();
    }

    public void OnOrbTriggered()
    {
        //Start Redraw Line
        lineAnimationController.StartLineRedraw();
        //Dissolve the map
        animator.SetBool("MapDissolve", true);
        //Set Active panoramic pannel 
        panoramicPannel.SetActive(true);
        //Set Active controller orb
        ControllerOrb.SetActive(true);
    }
}
