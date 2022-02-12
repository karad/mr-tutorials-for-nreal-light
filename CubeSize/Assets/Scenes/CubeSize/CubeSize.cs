using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeSize : MonoBehaviour
{
    /// <summary>
    /// Cube PreFab
    /// </summary>
    GameObject spherePrefab;

    /// <summary>
    /// Initial Position for cube layout
    /// </summary>
    static readonly Vector3 INITIAL_POSITION = new Vector3(0.0f, -0.35f, 3f);

    /// <summary>
    /// Number of Cubes list per axis
    /// </summary>
    static readonly float DEPTH = 20f;

    /// <summary>
    /// Space for each Cubes
    /// </summary>
    static readonly float SPAN = 2f;

    // Start is called before the first frame update
    void Start()
    {
        spherePrefab = Resources.Load<GameObject>("MyCube");
        LayoutCubes(DEPTH, SPAN);
    }

    /// <summary>
    /// Layout Cubes
    /// </summary>
    /// <param name="depth"></param>
    /// <param name="span"></param>
    void LayoutCubes(float depth, float span)
    {
        for (float x = -depth; x <= depth; x = x += span)
        {
            for (float y = -depth; y <= depth; y += span)
            {
                for (float z = -depth; z <= depth; z += span)
                {
                    // Exclude own position
                    if (!(x == 0 && y == 0 && z == -2f))
                    {
                        CreateCube(x, y, z);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Put a cube  in the current scene
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    void CreateCube(float x, float y, float z)
    {
        GameObject sphere = Instantiate(spherePrefab);
        sphere.transform.position = new Vector3(INITIAL_POSITION.x + x, INITIAL_POSITION.y + y, INITIAL_POSITION.z + z);
    }
}
