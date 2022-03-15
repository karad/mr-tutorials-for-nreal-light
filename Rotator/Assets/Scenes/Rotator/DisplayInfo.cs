using NRKernal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Display about user actions
/// </summary>
public class DisplayInfo : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public Text info;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Numeric display of right hand palm rotation value
        HandState handState = NRInput.Hands.GetHandState(HandEnum.RightHand);
        if (handState != null)
        {
            info.text = handState.GetJointPose(HandJointID.Palm).rotation.z.ToString();
        };
    }
}
