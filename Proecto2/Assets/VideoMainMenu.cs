using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocity = 10.0f;
    public float timer = 0.0f;
    public int i = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int seconds = (int)timer % 60;
        this.transform.localPosition = new Vector3(this.transform.localPosition.x - (velocity * Time.deltaTime), this.transform.localPosition.y + ((-9.81f + Random.Range(2, 9) + 5) * Time.deltaTime), this.transform.localPosition.z + (velocity * Time.deltaTime));
        this.transform.localRotation = new Quaternion(0.0f, -0.997993f, 0.0f, 0.06332435f);
        Debug.Log(seconds);

        if (seconds == 15 * i)
        {
            this.transform.localRotation = new Quaternion(0.0f, -0.997993f, 0.0f, 0.06332435f);
            this.transform.localPosition = new Vector3(164, 0.0f, -219);
            i++;
        }

    }
}
