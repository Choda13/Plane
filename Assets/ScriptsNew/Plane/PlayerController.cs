using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlaneController
{
    [SerializeField]PlaneMovement planeController;
    float pitch;
    float roll;
    float yaw;
    bool speedUp;
    bool slowDown;
    void FixedUpdate()
    {
        if(planeController == null)
        {
            Debug.LogError("[PlayerController] planeController is not initialized");
            return;
        }
        pitch = Input.GetAxis("Pitch");
        roll = Input.GetAxis("Roll");
        yaw = Input.GetAxis("Yaw");

        speedUp = Input.GetButton("SpeedUp");
        slowDown = Input.GetButton("SlowDown");

        if(pitch != 0)   Pitch(pitch);
        if(roll != 0)    Roll(roll);
        if(yaw != 0)     Yaw(yaw);
        
        if(speedUp)     SpeedUp(1);
        if(slowDown)    SlowDown(1);
        EventManager.CallRealSpeedChange(planeController.RealSpeed);
    }
    public void SpeedUp(int value)
    {
        planeController.SpeedUp(value);
        EventManager.CallSpeedChange(planeController.Speed);
    }
    public void SlowDown(int value)
    {
        planeController.SlowDown(value);
        EventManager.CallSpeedChange(planeController.Speed);
    }
    public void Pitch(float value)
    {
        planeController.Pitch(value);
    }
    public void Roll(float value)
    {
        planeController.Roll(value);
    }
    public void Yaw(float value)
    {
        planeController.Yaw(value);
    }
}
