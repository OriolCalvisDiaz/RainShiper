using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : Controller
{


    [MinMaxSlider(-100f, 100f)]
    public MinMax speed;

    [MinMaxSlider(-100f, 100f)]
    public MinMax normalSpeed;

    [MinMaxSlider(-100f, 100f)]
    public MinMax spaceSpeed;

    [Range(0f,100f)]
    public float timeZeroToMax = 2.5f;
    [Range(0f, 100f)]
    public float timeMaxToZero = 6f;
    [Range(0f, 100f)]
    public float timeBreakToZero = 1f;
    [Range(0f, 100f)]
    public float RayLarge = 4f;
    [Range(-360f, 360f)]
    public float turnAnglePerSec = 90f;

    public bool onSpace;

    float accelRatePerSec;
    float decelRatePerSec;
    float breakRatePerSec;

    float forwardVelocity;
    float currentTurnX, currentTurnY;
    public bool accelChange;

    private void Start()
    {
        accelRatePerSec = speed.Max / timeZeroToMax;
        decelRatePerSec = -speed.Max / timeZeroToMax;
        breakRatePerSec = -speed.Max / timeZeroToMax;
        forwardVelocity = 0f;
        currentTurnX = 0f;
        currentTurnY = 0f;
        speed = normalSpeed;
    }

    public override void ReadInput(InputData data)
    {

        if (data.a[0] != 0f)
        {
            currentTurnY = turnAnglePerSec * Time.deltaTime * (data.a[0] > 0 ? -1 : 1);
        }
        if (data.a[1] != 0f)
        {
            currentTurnX = turnAnglePerSec * Time.deltaTime * (data.a[1] > 0 ? 1 : -1);
        }
        //flyVerocity += (Vector3.up * data.a[1]) * vel;

        //JUMPFLY
        if (data.b[0] == true)
        {
            Accel(accelRatePerSec);
        }
        if (data.b[1] == true) { }
            //ESC
        if (data.b[2] == true)
        {
            forwardVelocity += breakRatePerSec * Time.deltaTime;
            forwardVelocity = Mathf.Max(forwardVelocity, speed.Min);
            accelChange = true;
        }
        if (data.b[7] == true) { }
            //Pause

        newInput = true;
    }

    bool Grounded() => Physics.Raycast(transform.position, Vector3.down, RayLarge);

    void LateUpdate()
    {
        if (forwardVelocity != 0f)
        {
            rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(currentTurnX, currentTurnY, 0));
        }
        if (!accelChange) { 
            Accel(decelRatePerSec);
        }
        rb.velocity = transform.forward * -forwardVelocity;

        newInput = false;
        currentTurnY = currentTurnX = 0f;
        accelChange = false;
    }

    void ResetMovement()
    {

    }

    void Accel(float a)
    {
        forwardVelocity += a * Time.deltaTime;
        forwardVelocity = Mathf.Clamp(forwardVelocity, 0, speed.Max);
        accelChange = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Space")
        {
            if (onSpace)
            {
                speed = normalSpeed;
                onSpace = false;
                Debug.Log("in");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Space")
        {
            if (!onSpace)
            {
                speed = spaceSpeed;
                onSpace = true;
                Debug.Log("out");

            }
        }
    }
}
