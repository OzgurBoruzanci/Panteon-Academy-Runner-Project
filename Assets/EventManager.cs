using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static Action<Vector3> PlayerPosition;
    public static Action<Vector3> PlayerFirstPosition;
    public static Action<string> FirstCome;
    public static Action AddCoin;
    public static Action EndGame;
    public static Action RestartBtn;
}