using NRKernal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Target Cube Script
/// </summary>
public class TargetCube : MonoBehaviour
{
    private MeshRenderer meshRender;

    void Awake()
    {
        // Get mesh renderer
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
    /// Trigger Enter Event Handler
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter!");
        meshRender.material.color = new Color(0f, 1f, 0f);
    }

    /// <summary>
    /// Trigger Stay Event Handler
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        // Get right hand rotation value
        HandState handState = NRInput.Hands.GetHandState(HandEnum.RightHand);
        Quaternion handStateThumbTipRotation = handState.GetJointPose(HandJointID.Palm).rotation;
        Quaternion targetRotation = transform.rotation;
        targetRotation.z = handStateThumbTipRotation.z;
        transform.rotation = targetRotation;
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
