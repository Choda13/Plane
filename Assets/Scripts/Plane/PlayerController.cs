using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerController : MonoBehaviour
{
    #region public varaibles
    public ParticleSystem explosionFX;
    public ParticleSystem flameFX;
    public ParticleSystem nukeFX;
    public Vector3 nukeSize;
    public Vector3 flameOffset;
    public GameObject centerOfMass;
    public float speed;
    public float collisionSpeedLimit;
    public float liftForceK;
    public GameObject pitchForcePoint;
    public float pitchForceK;
    public GameObject YawForcePoint;
    public float yawForceK;
    public GameObject LeftRollForcePoint;
    public GameObject RightRollForcePoint;
    public float rollForceK;
    public float LocalVelocity;
    public float maxSpeed;
    public float minSpeed;

    #endregion

    #region private variables
    float force;
    float liftForce;
    float pitchInput;
    float rollInput;
    float gravity;
    float yawInput;
    float rightRollForce;
    bool engineWorks;
    bool isCrashed;
    int health;
    Rigidbody Rigidbody;
    #endregion
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.centerOfMass = centerOfMass.transform.localPosition;
        Physics.gravity *= 2;
        engineWorks = true;
        isCrashed = false;
        health=100;
    }
    void FixedUpdate()
    {
        if (engineWorks)
        {
            ChangeYaw();
            ChangePitch();
            ChangeRoll();
            ChangeSpeed();
        }
        PlaneForwardMovement();
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Physics.gravity /= 2;
        }
    }
    #region Movement
    void PlaneForwardMovement()
    {
        if (engineWorks)
        {
            force = speed * Rigidbody.mass * Rigidbody.drag;
            Rigidbody.AddForce(transform.forward * force);
        }
        liftForce = transform.InverseTransformDirection(Rigidbody.velocity).z * liftForceK;
        Rigidbody.AddForce(transform.up * liftForce);
        LocalVelocity = transform.InverseTransformDirection(Rigidbody.velocity).magnitude;
        EventManager.CallRealSpeedChange(LocalVelocity);
    }
    void ChangeSpeed()
    {
        if (Input.GetKey(KeyCode.S) && speed != minSpeed)
            speed--;
        else if (Input.GetKey(KeyCode.W) && speed != maxSpeed)
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
    
    #endregion
    void PlaneCrashed()
    {
        engineWorks = false;
        isCrashed = true;
        speed = 0;
        EventManager.CallOnCrash();
        EventManager.CallSpeedChange(speed);
        Instantiate(explosionFX, transform.position + flameOffset, flameFX.transform.rotation, transform);
        StartCoroutine(BigExplosionTrigger());
    }
    void PlaneExplosion(Collision other)
    {
        if (other.impulse.magnitude/Rigidbody.mass > collisionSpeedLimit && !isCrashed)
        {
            PlaneCrashed();
        }
        if (isCrashed)
        {
            ContactPoint[] contactPoints = new ContactPoint[other.contacts.Length];
            other.GetContacts(contactPoints);
            foreach (var i in contactPoints)
            {
                Instantiate(explosionFX, i.point, Quaternion.FromToRotation(explosionFX.transform.up, i.normal));
                Instantiate(flameFX, i.point, flameFX.transform.rotation, transform);
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        PlaneExplosion(other);
    }
    void OnDisable()
    {
        StopAllCoroutines();
    }
  
    #region Coroutines
     IEnumerator BigExplosion()
    {
        var bigBoom = Instantiate(nukeFX, transform.position, nukeFX.transform.rotation, transform);
        var scale = bigBoom.transform.localScale;
        var flame = Instantiate(flameFX, transform.position, flameFX.transform.rotation, transform);
        bigBoom.transform.localScale += nukeSize;
        flame.transform.localScale += nukeSize/2;
        yield return null;
    }
    IEnumerator BigExplosionTrigger()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (LocalVelocity < 0.005)
            {
                StartCoroutine(BigExplosion());
                break;
            }
        }
    }
    #endregion
}