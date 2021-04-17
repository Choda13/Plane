using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlaneMovement : MonoBehaviour
{
    public float forwardSpeed;
    public float rotationSpeed;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI score;
    public GameObject com;
    private int scoreCount;
    private float horizontalInput;
    private float verticalInput;
    private bool inSafeZone=false;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com.transform.position;
        speed.text = forwardSpeed + " KM/H";
    }
    void Update()
    {
        ChangeSpeed();
        SteerAircraft();
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
    }
    void SteerAircraft()
    {
        horizontalInput = Input.GetAxis("Yaw");
        verticalInput = Input.GetAxis("Pitch");
        transform.Rotate((Vector3.back * horizontalInput + Vector3.right * verticalInput) * rotationSpeed * Time.deltaTime);
    }
    void ChangeSpeed()
    {
        if (Input.GetKey(KeyCode.E))
        {
            forwardSpeed++;
            UpdateSpeed(forwardSpeed);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            forwardSpeed--;
            UpdateSpeed(forwardSpeed);
        }
    }
    void UpdateSpeed(float newSpeed)
    {
        speed.text = newSpeed + " KM/H";
    }
    void UpdateScore(float newScore)
    {
        score.text = "Score: " + newScore;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SafeZone")
            inSafeZone=true;
        else
        {
            scoreCount++;
            UpdateScore(scoreCount);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "SafeZone")
            inSafeZone=false;
    }
    void OnCollisionEnter()
    {
        if(inSafeZone)return;
        Restart();
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
