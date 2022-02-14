using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandTrack : MonoBehaviour, IPointerClickHandler
{
    /// <summary>
    /// Counter Text GameObject
    /// </summary>
    public Text targetText;

    /// <summary>
    /// Counter value
    /// </summary>
    private int counter = 0;

    /// <summary>
    /// HandTracking Click Handler
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        counter++;
        targetText.text = counter.ToString();
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
