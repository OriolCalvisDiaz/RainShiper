using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Player : Controller
{
    public float life;
    public int numLifes;
    public float score;
    [Header("Tiempo Restante")]
    public float timeLeft = 1;
    public bool win, lose;
}
