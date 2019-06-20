using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public abstract class Controller : MonoBehaviour
{
    public abstract void ReadInput(InputData data);

    protected Rigidbody rb;
    protected Collider coll;
    protected bool newInput;
}
