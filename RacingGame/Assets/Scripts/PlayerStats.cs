using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerStats : MonoBehaviour
{
    public static float Money = 220;
    public static int Car = -1;
    public static Vector2 Grip = new Vector2(0, 0);
    public static Vector2 Acceleration = new Vector2(0, 0);
    public static Vector2 TopSpeed = new Vector2(0, 0);
    public static Vector2 Braking = new Vector2(0, 0);
    public static Vector2 Health = new Vector2(0, 0);
    public static Vector2 Damage = new Vector2(0, 0);
    public static bool TrackOneComplete = false;
    public static bool TracktwoComplete = false;
    public static bool InvertFPY;
    public static bool InvertTPY;
    public static float cameraSensitivityX = 500f;
    public static float cameraSensitivityY = 500f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
