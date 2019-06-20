using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class MapaRandomGeneric : MonoBehaviour
{

    public Transform[] posicion;
    public int amount;
    public Transform Parent;
    // Start is called before the first frame update
    void Start()
    {
        MakeScene();
    }

    void MakeScene()
    {
        for(int i = amount; i > 0; i--)
        {

            float x = Random.value * 400f + 20f;
            float z = Random.value * 450f + 20f;
            if(x > -5f && x < 5f && z > -5f && z < 5f) {
                continue;
            }

            Quaternion rot = Quaternion.Euler(0f, Random.value * 360f, 0f);
            Transform clone;
            clone = Instantiate(posicion[0], new Vector3(x, -12, z), rot, transform);
            clone = Instantiate(posicion[1], new Vector3(z, -15, x), rot, transform);

            //clone.transform.SetParent();
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
