using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class Flight : Player
{
    public Color actualColor;

    public Text timer;
    public Text scoreLabel;

    public Image panelsVelocity;
    public Image[] panelsLife;

    [MinMaxSlider(-100f, 100f)]
    public MinMax speed;

    [MinMaxSlider(-100f, 100f)]
    public MinMax normalSpeed;

    [MinMaxSlider(-100f, 100f)]
    public MinMax spaceSpeed;

    [MinMaxSlider(-100f, 100f)]
    public MinMax superSpeed;

    public int countPortals = 0;

    public int comboSpeed = 0;

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
    public bool onTransition;
    public bool onTurbo;

    public bool accelChange;
    public bool changeState;


    public virtual bool Grounded() => false;

    public virtual void increseCombo() {}
    public virtual void ResetCombo() {}

    public virtual void ChargeVelocity(){}

    public virtual void Accel(float a) {}

    public virtual void SuperSpeed(float a) {}

    public virtual bool CountDown()=> false;

}
