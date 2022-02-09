# Cube Rotation - MR Tutorial for Nreal light

## Sample Repository

- [mr\-tutorials\-for\-nreal\-light/CubeRotation at main · karad/mr\-tutorials\-for\-nreal\-light](https://github.com/karad/mr-tutorials-for-nreal-light/tree/main/CubeRotation)

## Run the sample

1. Download NRSDK 1.7.0 from [https://nreal-public.nreal.ai/download/NRSDKForUnityAndroid_1.7.0.unitypackage](https://nreal-public.nreal.ai/download/NRSDKForUnityAndroid_1.7.0.unitypackage)
2. Open `Build Setting`, change Platform to `Android`
3. Open `Project`, select `Assets` > `import package` > `Custom Package` and import `NRSDKForUnityAndroid_1.7.0.unitypackage`.
4. Check `Build Settings` > `Player Settings` by referring to [Configure Build Settings](https://nreal.gitbook.io/nrsdk-documentation/discover/quickstart-for-android#configure-build-settings)
5. Press `Build` form `Build Settings` panel
6. Install *.apk on Android or DevKit.

## Tutorial

### 1. Setting up the project for Nreal development

1. See [Quickstart for Android - NRSDK Documentation](https://nreal.gitbook.io/nrsdk-documentation/discover/quickstart-for-android#configure-build-settings) and configure the build settings.
2. Download NRSDK 1.7.0 from [https://nreal-public.nreal.ai/download/NRSDKForUnityAndroid_1.7.0.unitypackage](https://nreal-public.nreal.ai/download/NRSDKForUnityAndroid_1.7.0.unitypackage)
3. Open `Project`, select `Assets` > `import package` > `Custom Package` and import `NRSDKForUnityAndroid_1.7.0.unitypackage`.

### 2. Put a Canvas in the scene

1. Put `Canvas` from `Create` > `UI`
2. Set property on `Inspector` panel
    1. `Render Mode` : World Space
    2. `Pos X` : 0 , `Pos Y` : -0.35 `Pos Z` : 3
    3. `Scale`
        1. `X` : 0.005 , `Y` : 0.005 , `Z` : 0.005

### 3. Put Text in Canvas

1. Put `Text` as a child of `Canvas`
    1. `Pos X` : 0, `Pos Y` : -30, `Pos Z` : 3
2. Change Text to “Rotate Cube” on `Inspector` panel.
3. Change Color to “FFFFFF” on `Inspector` panel.

### 4. Create C# Script in Assets

1. Create `C# Script` in the asset with the file name "RotateButton.cs".
2. Write the code as follows

```csharp
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
```

### 5. Put Cube in the Scene

1. Put `Cube` in the Scene
    1. Change name to “RotatableCube”
    2. `Pos X` : 0, `Pos Y` : 0, `Pos Z` : 8

### 6. Put “Rotate Right” Button in Canvas

1. Put `Button` as a child of `Canvas`
    1. `Pos X` : 60, `Pos Y` : 0, `Pos Z` : 0
    2. `Width` : 100
2. Change Text to “Rotate Right” from nested `Text`.
3. Attach the `RotateButton.cs` on `Inspector` panel.
    1. Set `Target Cube` to RotatableCube you just created.
    2. Set `Rotation Type` to RIGHT.

### 7. Put “Rotate Left” Button in Canvas

1. Put `Button` as a child of `Canvas`
    1. `Pos X` : -60, `Pos Y` : 0, `Pos Z` : 0
    2. `Width` : 100
2. Change Text to “Rotate Left” from nested `Text`.
3. Attach the `RotateButton.cs` on `Inspector` panel.
    1. Set `Target Cube` to RotatableCube you just created.
    2. Set `Rotation Type` to LEFT.