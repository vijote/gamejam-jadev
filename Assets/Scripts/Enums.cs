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