using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI ammunitionText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI currentSpeedText;
    private int ammo;
    private int maxAmmo;
    void Awake()
    {
        GameData.Update();
        EventManager.OnGunAwake += GunAwake;
        EventManager.OnGunShoot += UpdateAmmo;
        EventManager.OnRealSpeedChange += UpdateRealSpeed;
        EventManager.OnSpeedChange += UpdateSpeed;
    }
    private void GunAwake(int ammo, int maxAmmo)
    {
        this.ammo = ammo;
        this.maxAmmo = maxAmmo;
        UpdateAmmo(ammo);
    }
    private void UpdateAmmo(int ammo)
    {
        ammunitionText.text = ammo + "/" + maxAmmo;
    }
    public void UpdateSpeed(float speed)
    {
        speedText.text = "SET SPEED: " + (int)speed + "KM/H";
    }
    public void UpdateRealSpeed(float speed)
    {
       currentSpeedText.text = "SPEED: " + speed.ToString(".00") + "KM/H";
    }
    private void OnDisable()
    {
        EventManager.OnGunAwake-=GunAwake;
        EventManager.OnGunShoot-=UpdateAmmo;
        EventManager.OnRealSpeedChange-=UpdateRealSpeed;
        EventManager.OnSpeedChange -= UpdateSpeed;
    }
}