# Hold Me Tight - MR Tutorial for Nreal Light

![Completion screen of sample](./Assets/HoldMeTight.png)

Now let's try to grab the touched GameObject and move it. This tutorial is a continuation of the "U Can Touch This" tutorial. If you have not yet comple "U Can Touch This", please proceed with the following tutorial first.

- [U Can Touch This - MR Tutorial for Nreal Light](https://github.com/karad/mr-tutorials-for-nreal-light/tree/main/UCanTouchThisCanTouchThis)

## Sample Repository

- mr-tutorials-for-nreal-light/HoldMeTight at main · karad/mr-tutorials-for-nreal-light [https://github.com/karad/mr-tutorials-for-nreal-light/tree/main/HoldMeTight](https://github.com/karad/mr-tutorials-for-nreal-light/tree/main/HoldMeTight)

## Run the sample

1. Clone Sample Repository, Change current directory to `HoldMeTight`. And Open with Unity.
2. (If you don’t have NRSDK) Download NRSDK 1.7.0 from [https://nreal-public.nreal.ai/download/NRSDKForUnityAndroid_1.7.0.unitypackage](https://nreal-public.nreal.ai/download/NRSDKForUnityAndroid_1.7.0.unitypackage)
3. Open `Build Setting`, change Platform to `Android`
4. Open `Project`, select `Assets` > `import package` > `Custom Package` and import `NRSDKForUnityAndroid_1.7.0.unitypackage`.
5. Check `Build Settings` > `Player Settings` by referring to [Configure Build Settings](https://nreal.gitbook.io/nrsdk-documentation/discover/quickstart-for-android#configure-build-settings)
6. Press `Build` form `Build Settings` panel
7. Install *.apk on Android or DevKit.

## Tutorial

### 1. First, complete "U Can Touch This"

- First, complete "U Can Touch This". This tutorial will continue with "U Can Touch This". You can also start by cloning the sample repository.

### 2. Check “Is Trigger” on “TargetCube1”

- Select `TargetCube1` from `Target` on the Scene.
- Check `Is Trigger` from Inspector Panel. By checking this box, you can trigger events when you touch game objects.

### 3. Chenge C# Script

- Open C# Script “TargetCube.cs” on `Assets` panel.
- Change the code as follows.

```csharp
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
```

### 4. Run the tutorial

- Press `Play` button and run the tutorial.

### 5. Build

1. Press `Build` form `Build Settings` panel
2. Install *.apk on Android or DevKit.