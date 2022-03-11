using NRKernal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Target Cube Script
/// </summary>
public class TargetCube: MonoBehaviour
{
    private MeshRenderer meshRender;

    void Awake()
    {
        meshRender = transform.GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Display event log using console
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Hit!");
    }

    /// <summary>
    /// Trigger Enter Event Handler
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter!");
        meshRender.material.color = new Color(1f, 0f, 0f);
    }

    /// <summary>
    /// Trigger Stay Event Handler
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        // Get Right Hand
        HandState handState = NRInput.Hands.GetHandState(HandEnum.RightHand);
        if(handState.currentGesture == HandGesture.Grab)
        {
            // Get Index Tip Position of right hand
            Vector3 handStateThumbTipPosition = handState.GetJointPose(HandJointID.IndexTip).position;
            // Set Hand R IndexTip Sphere position
            transform.position = handStateThumbTipPosition;
        }
    }

    /// <summary>
    /// Trigger Exit Event Handler
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit!");
        meshRender.material.color = new Color(1f, 1f, 1f);
    }
}
