using NRKernal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hand Controller for Tip
/// </summary>
public class HandController : MonoBehaviour
{
    /// <summary>
    /// IndexTip GameObject
    /// </summary>
    public GameObject hand_R_IndexTip;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get Right Hand
        HandState handState = NRInput.Hands.GetHandState(HandEnum.RightHand);
        // Get Index Tip Position of right hand
        Vector3 handStateThumbTipPosition = handState.GetJointPose(HandJointID.IndexTip).position;
        // Set Hand R IndexTip Sphere position
        hand_R_IndexTip.transform.position = handStateThumbTipPosition;
    }
}
