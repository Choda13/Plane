using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlaneController
{
    [SerializeField]PlaneMovement planeMovement;
    float pitch;
    float roll;
    float yaw;
    bool speedUp;
    bool slowDown;
    void FixedUpdate()
    {
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
    }
    public void SpeedUp(int value)
    {
        planeMovement.SpeedUp(value);
    }
    public void SlowDown(int value)
    {
        planeMovement.SlowDown(value);
    }
    public void Pitch(float value)
    {
        planeMovement.Pitch(value);
    }
    public void Roll(float value)
    {
        planeMovement.Roll(value);
    }
    public void Yaw(float value)
    {
        planeMovement.Yaw(value);
    }
}
