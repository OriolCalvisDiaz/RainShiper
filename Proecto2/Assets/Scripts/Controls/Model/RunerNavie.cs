﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;


public class RunerNavie : Flight
{
    public PostProcessProfile[] PPV;
    public PostProcessVolume PostProces;

    public GameObject Panel;

    public List<PointPath> PointPosition;

    float accelRatePerSec;
    float decelRatePerSec;
    float breakRatePerSec;

    public PointPath EndPoint;

    float forwardVelocity;
    float currentTurnX, currentTurnY;
    public bool stop;
    public bool spaceControll = false;
    public bool checkUnspace = false;
    public bool checkSpace = false;

    public

    void Awake()
    {
        speed = normalSpeed;

        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        timer.text = (timeLeft).ToString();

    }

    // Start is called before the first frame update
    void Start()
    {
        accelRatePerSec = speed.Max / timeZeroToMax;
        decelRatePerSec = -speed.Max / timeZeroToMax;
        breakRatePerSec = -speed.Max / timeZeroToMax;
        forwardVelocity = 0f;
        currentTurnX = 0f;
        currentTurnY = 0f;
    }

    public override void ReadInput(InputData data)
    {
        if (!stop && !win && !lose)
        {
            if (data.a[0] != 0f)
            {
                if (transform.localRotation.x <= 90)
                    currentTurnY = turnAnglePerSec * Time.deltaTime * (data.a[0] > 0 ? -1 : 1);
                else
                    currentTurnY = turnAnglePerSec * Time.deltaTime * (data.a[0] > 0 ? 1 : -1);
            }

            if (data.a[1] != 0f)
                currentTurnX = turnAnglePerSec * Time.deltaTime * (data.a[1] > 0 ? 1 : -1);

            //JUMPFLY
            if (data.b[0] == true)
                Accel(accelRatePerSec);

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
        }
        else
        {
            if (data.b[0] == true)
            {
                spaceControll = true;
            }
        }
        newInput = true;
    }

    public override bool Grounded() => Physics.Raycast(transform.position, Vector3.down, RayLarge);

    private void LateUpdate()
    {
        timer.text = (Mathf.Round(timeLeft)).ToString();

        if (win)
        {
            Panel.SetActive(true);
        }
        if (!stop && !win && !lose)
        {

            if (forwardVelocity != 0f)
                rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(currentTurnX, currentTurnY, 0));

            if (!accelChange)
                Accel(decelRatePerSec);

            rb.velocity = transform.forward * -forwardVelocity;


            currentTurnY = currentTurnX = 0f;
            accelChange = false;
            onSpace = true;

            RaycastHit hit;
            Debug.DrawRay(transform.position, Vector3.down, Color.red, 10f);
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 10f))
            {
                if (hit.collider.tag == "Race")
                {
                    onSpace = false;
                    changeState = false;
                    ChargeVelocity();
                }
            }

            if (onSpace)
            {
                ChargeVelocity();
                lose = CountDown();
            }

            changeState = false;
            //hit.collider.transform.position == PointPosition[indexOfPoints].PointPosition.position && hit.collider.isTrigger ||
            if (countPortals <= PointPosition.ToArray().Length - 1)
            {
                if (Vector3.Distance(PointPosition[countPortals].PointPosition.position, transform.position) < 15f)
                {
                    countPortals++;
                }
            }
        }
        else
        {
///

        }
        newInput = false;

        if ((countPortals >= 9))
        {
            if (Vector3.Distance(EndPoint.PointPosition.position, transform.position) < 5f)
            {
                win = true;
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Space" && !onTransition)
        {
            onTransition = true;
        }
        else if (other.gameObject.tag == "Space" && !onTransition && other.gameObject.tag == "PowerUp")
        {
            onTurbo = onSpace = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Space" && onTransition)
        {
            if (!onSpace)
                onSpace = true;
            else
                onSpace = false;

            onTransition = false;
        }
        if (other.gameObject.GetComponent<PointPath>() != null)
        {
            if (other.gameObject.tag == "PowerUp" && other.gameObject.GetComponent<PointPath>().speed == true)
            {
                onTurbo = true;
                if (comboSpeed <= 4)
                {
                    increseCombo();
                    ChargeVelocity();
                }

                other.gameObject.GetComponent<PointPath>().speed = false;

                switch (comboSpeed)
                {
                    case 1:
                        PostProces.profile = PPV[1];
                        panelsVelocity.color = Color.Lerp(actualColor, Color.blue, 1f);
                        timeLeft = 3;
                        break;
                    case 2:
                        PostProces.profile = PPV[2];
                        panelsVelocity.color = Color.Lerp(actualColor, Color.green, 1f);
                        timeLeft = 5;
                        break;
                    case 3:
                        PostProces.profile = PPV[3];
                        panelsVelocity.color = Color.Lerp(actualColor, Color.yellow, 1f);
                        timeLeft = 7;
                        break;
                    case 4:
                        PostProces.profile = PPV[4];
                        panelsVelocity.color = Color.Lerp(actualColor, Color.red, 1f);
                        timeLeft = 10;
                        break;
                    case 5:
                        PostProces.profile = PPV[5];
                        panelsVelocity.color = Color.Lerp(actualColor, Color.black, 1f);
                        timeLeft = 15;
                        break;
                }
            }
        }
    }
    public override void increseCombo() => comboSpeed++;
    public override void ResetCombo() => comboSpeed = 0;

    public override void ChargeVelocity()
    {
        if (onTurbo)
            speed = superSpeed;
        else if (onSpace && !onTurbo)
            speed = spaceSpeed;
        else
            speed = normalSpeed;

    }

    public override void Accel(float a)
    {
        forwardVelocity += a * Time.deltaTime;
        forwardVelocity = Mathf.Clamp(forwardVelocity, 0, speed.Max);
        accelChange = true;
    }

    public override void SuperSpeed(float a)
    {
        speed.Max -= normalSpeed.Max * Time.deltaTime;
        speed.Min -= normalSpeed.Min * Time.deltaTime;

        forwardVelocity += a * Time.deltaTime;
        forwardVelocity = Mathf.Clamp(forwardVelocity, 0, speed.Max);
        accelChange = true;
    }

    public override bool CountDown()
    {
        if (numLifes > 2)
        {
            return true;
        }
        else
        {
            if (timeLeft >= 0)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0)
                {
                    PostProces.profile = PPV[0];
                    timer.text = "0";
                    onTurbo = false;
                    panelsVelocity.color = Color.Lerp(actualColor, Color.white, 1f);
                }
                else
                {
                    timer.text = (Mathf.Round(timeLeft)).ToString();
                }

                if (onSpace)
                {
                    if (timeLeft <= 0)
                    {
                        life -= (1 * Time.deltaTime);
                        panelsLife[numLifes].fillAmount = life / 3;
                        if (panelsLife[numLifes].fillAmount == 0)
                        {
                            life = 3;
                            numLifes++;
                        }
                    }
                }
            }
            else
            {
                comboSpeed = 0;
                timeLeft = 0;
            }
            return false;
        }
    }

}

