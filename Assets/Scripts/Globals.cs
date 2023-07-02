using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class State
{
    public static string Idle = "Idle";
    public static string Running = "Run";
    public static string Attack = "Attack";
}

public enum Size
{
    Small,
    Medium,
    Large
}

public class SizeHelper : MonoBehaviour
{
    public static Size GetRandomSize()
    {
        Size[] enumValues = (Size[])Enum.GetValues(typeof(Size));
        int randomIndex = UnityEngine.Random.Range(0, enumValues.Length);
        return enumValues[randomIndex];
    }
}

public class AnimationDictionary
{
    public static Dictionary<string, string> States = new Dictionary<string, string>() {
        { "Idle", "Idle" },
        { "Run", "Run" },
        { "Attack", "Attack" },
    };
}

public class PlayableArea {
    public static Vector3 bottomLeftCorner = new Vector3(-7.25f, 0f, -17.77f);
    public static Vector3 bottomRightCorner = new Vector3(60.1f, 0f, -17.77f);
    public static Vector3 topLeftCorner = new Vector3(-7.25f, 0f, 29.906f);
    public static Vector3 topRightCorner = new Vector3(60.1f, 0f, 29.906f);

    public static Vector3 playableAreaCenter = (PlayableArea.bottomLeftCorner + PlayableArea.bottomRightCorner + PlayableArea.topLeftCorner + PlayableArea.topRightCorner) / 4f;
    public static Vector3 playableAreaSize = new Vector3(
        Mathf.Abs(PlayableArea.topRightCorner.x - PlayableArea.topLeftCorner.x),
        Mathf.Abs(PlayableArea.topLeftCorner.y - PlayableArea.bottomLeftCorner.y),
        Mathf.Abs(PlayableArea.topRightCorner.z - PlayableArea.bottomRightCorner.z)
    );
}

