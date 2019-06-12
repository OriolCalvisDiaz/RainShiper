using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : Controller
{
    public float speed = 2.0f;
    Vector3 flyVerocity;
    [MinMaxSlider(-0.5f, 0.5f)]
    public MinMax posY;

    public override void ReadInput(InputData data)
    {
        flyVerocity = Vector3.zero;

        if(data.a[0] != 0f)
        {
            flyVerocity += Vector3.forward * data.a[0] * speed;
        }
        if(data.a[1] != 0f)
        {
            flyVerocity += Vector3.right * data.a[1] * speed;
        }
        newInput = true;
    }

    void LateUpdate()
    {
        if (!newInput)
        {
            flyVerocity = Vector3.zero;
        }
        float y = 0f;
        newInput = false;

        if(transform.localPosition.y > 2.5f)
        {
            y = -0.5f;
            Debug.Log("1");

        }
        else if(transform.localPosition.y > 0.0f && transform.localPosition.y < 2.5f)
        {
            Debug.Log("2");

            y = rb.velocity.y + (posY.RandomValue * Time.deltaTime);
        }
        if(transform.localPosition.y < 1.0f )
        {
            Debug.Log("3");

            y = +0.5f;
        }
        else if(transform.localPosition.y < 2.5f && transform.localPosition.y > 1.0f)
        {
            Debug.Log("4");

            y = 0.0f;
            y = rb.velocity.y + (posY.RandomValue * Time.deltaTime);
        }

        rb.velocity = new Vector3(flyVerocity.x, y, flyVerocity.z);

        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += Vector3.right * Time.deltaTime * speed;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position += Vector3.forward * Time.deltaTime * speed;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position += Vector3.left * Time.deltaTime * speed;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += Vector3.back * Time.deltaTime * speed;
        //}
    }
}
