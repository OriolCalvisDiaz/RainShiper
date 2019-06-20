using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPath : MonoBehaviour
{
    public Collider PointCollider;
    public Transform PointPosition;
    public bool speed = true;
    public GameObject Sphere;

    public void PasAPortal() => Sphere.SetActive(false);
}

