using NRKernal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PinchStrength : MonoBehaviour
{
    /// <summary>
    /// Pinch Strength Bar for Left Hand
    /// </summary>
    public Slider pinchStrengthLeftHand;

    /// <summary>
    /// Pinch Strength Bar for Right Hand
    /// </summary>
    public Slider pinchStrengthRightHand;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HandState handStateRight = NRInput.Hands.GetHandState(HandEnum.RightHand);
        float pinchStrengthRight = handStateRight.pinchStrength;
        pinchStrengthRightHand.value = pinchStrengthRight;

        HandState handStateLeft = NRInput.Hands.GetHandState(HandEnum.LeftHand);
        float pinchStrengthLeft = handStateLeft.pinchStrength;
        pinchStrengthLeftHand.value = pinchStrengthLeft;
    }
}
