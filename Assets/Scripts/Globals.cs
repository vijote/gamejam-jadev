using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Globals
{
    public static readonly int MAX_ENEMY_COUNT = 24;
}

public class State
{
    public static string Idle = "Idle";
    public static string Running = "Run";
    public static string Attacking = "Attack";
    public static string Dead = "Death";
}

public enum GameState
{
    Playing,
    Paused,
    Over
}

public enum SizeMaxScore
{
    Small = 10,
    Medium = 30,
    Large = 50,
}

public enum Size
{
    Small,
    Medium,
    Large
}

public enum Score
{
    Small = 1,
    Medium = 3,
    Large = 5
}

public class AnimationDictionary
{
    public static Dictionary<string, string> States = new Dictionary<string, string>() {
        { State.Idle, "Idle_A" },
        { State.Running, "Run" },
        { State.Attacking, "Attack" },
        { State.Dead, "Death" }
    };
}

public class ScoreDictionary
{
    public static Dictionary<Size, Score> Scores = new Dictionary<Size, Score>()
    {
        { Size.Small, Score.Small },
        { Size.Medium, Score.Medium },
        { Size.Large, Score.Large }
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

