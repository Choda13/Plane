using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlaneMovementPhysics : MonoBehaviour
{
    public GameObject centerOfMass;
    public float speed;
    public float liftForceK;
    public GameObject pitchForcePoint;
    public float pitchForceK;
    public GameObject YawForcePoint;
    public float yawForceK;
    public GameObject LeftRollForcePoint;
    public GameObject RightRollForcePoint;
    public float rollForceK;
    public float WorldVelocity;
    public float LocalVelocity;
    public float maxSpeed;
    public float minSpeed;
    float force;
    float liftForce;
    float pitchInput;
    float rollInput;
    float gravity;
    float yawInput;
    float rightRollForce;
    Rigidbody Rigidbody;
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.centerOfMass = centerOfMass.transform.localPosition;
        Physics.gravity*=2;
    }
    void FixedUpdate()
    {
        ChangeYaw();
        ChangePitch();
        ChangeRoll();
        ChangeSpeed();
        PlaneForwardMovement();
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Physics.gravity/=2;
        }
    }
    void PlaneForwardMovement()
    {
        force = speed * Rigidbody.mass * Rigidbody.drag;  
        liftForce = transform.InverseTransformDirection(Rigidbody.velocity).z * liftForceK;
        Rigidbody.AddForce(transform.forward * force);
        Rigidbody.AddForce(transform.up * liftForce);
        WorldVelocity = Rigidbody.velocity.z;
        LocalVelocity = transform.InverseTransformDirection(Rigidbody.velocity).magnitude;
        EventManager.CallRealSpeedChange(LocalVelocity);
    }
    void ChangeSpeed()
    {
        if(Input.GetKey(KeyCode.S) && speed != minSpeed)
            speed--;
        else if(Input.GetKey(KeyCode.W) && speed != maxSpeed)
            speed++;
        EventManager.CallSpeedChange(speed);
    }
    void ChangeYaw()
    {
        yawInput = Input.GetAxis("Yaw");
        Rigidbody.AddForceAtPosition(-transform.right * yawInput * yawForceK, YawForcePoint.transform.position, ForceMode.Impulse);
    }
    void ChangePitch()
    {
        pitchInput = Input.GetAxis("Pitch");
        Rigidbody.AddForceAtPosition(-transform.up * pitchInput * pitchForceK, pitchForcePoint.transform.position, ForceMode.Impulse);
    }
    void ChangeRoll()
    {
        rollInput = Input.GetAxis("Roll");
        Rigidbody.AddForceAtPosition(-transform.up * rollInput * rollForceK, RightRollForcePoint.transform.position, ForceMode.Impulse);
        Rigidbody.AddForceAtPosition(transform.up * rollInput * rollForceK, LeftRollForcePoint.transform.position, ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.relativeVelocity.y > 10)
            print(other.relativeVelocity.y +"RIP");
        else
            print(other.relativeVelocity.y);
    }
}