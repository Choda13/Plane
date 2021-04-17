using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static HUDManager manager = GameObject.Find("UI").GetComponent<HUDManager>();
    public static void Update()
    {
        manager = GameObject.Find("UI").GetComponent<HUDManager>();
    }
}
