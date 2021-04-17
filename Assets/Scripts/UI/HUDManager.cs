using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI ammunitionText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI currentSpeedText;
    public int maxAmmunition;
    void Awake()
    {
        maxAmmunition = Gun.maxAmmunition;
        GameData.Update();
    }
    public void UpdateAmmo(int ammo)
    {
        ammunitionText.text = ammo + "/" + maxAmmunition;
    }
    public void UpdateSpeed(int speed)
    {
        speedText.text = "SET SPEED: " + speed + "KM/H";
    }
    public void UpdateRealSpeed(float speed)
    {
       currentSpeedText.text = "SPEED: " + speed.ToString(".00") + "KM/H";
    }
}
