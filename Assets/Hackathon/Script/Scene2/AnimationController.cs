using System.Collections;
using UnityEngine;

public class AnimationContoller : MonoBehaviour
{
    [SerializeField] GameObject panoramicPannel;
    [SerializeField] GameObject ControllerOrb;

    private Animator animator;
    private LineAnimationController lineAnimationController;
    private bool panoramicPannelStatus = false;

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

    public void OnTerrainAnimationComplete()
    {
        if (panoramicPannelStatus)
        {
            panoramicPannel.SetActive(true);
        }
    }

    public void OnOrbTriggered()
    {
        //Dissolve the map
        animator.SetBool("MapDissolve", true);
        //Start Redraw Line
        lineAnimationController.StartLineRedraw();
        //Set Active panoramic pannel 
        panoramicPannelStatus = true;
        //Set Active controller orb
        ControllerOrb.SetActive(true);
    }

}
