using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    /// <summary>
    /// Target Object
    /// </summary>
    public GameObject TargetCube;

    /// <summary>
    /// Rotation Type
    /// </summary>
    public RotationTypeEnum RotationType;

    /// <summary>
    /// Number of rotations at a time
    /// </summary>
    private static readonly int ROTATE = 1;

    /// <summary>
    /// Press flag
    /// </summary>
    private bool isPressed = false;

    /// <summary>
    /// Rotation Type Enum
    /// </summary>
    public enum RotationTypeEnum
    {
        LEFT,
        RIGHT
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            if (RotationType == RotationTypeEnum.RIGHT)
            {
                TargetCube.transform.Rotate(new Vector3(0, ROTATE, 0));
            }
            else if (RotationType == RotationTypeEnum.LEFT)
            {
                TargetCube.transform.Rotate(new Vector3(0, -ROTATE, 0));
            }
        }
    }

    /// <summary>
    /// Pointer up event handler
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    /// <summary>
    ///  Pointer down event handler
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
}
