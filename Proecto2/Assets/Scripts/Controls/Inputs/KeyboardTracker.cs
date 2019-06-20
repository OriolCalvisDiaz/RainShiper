using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardTracker : DeviceTracker
{
    /// <summary>
    /// Axis Key
    /// </summary>
    public AxisKeys[] aK;
    /// <summary>
    /// Button Key
    /// </summary>
    public KeyCode[] bK;

    public override void Refresh()
    {
        im = GetComponent<InputManager>();
        im.RefreshTracker();

        KeyCode[] newB = new KeyCode[im.bC];
        AxisKeys[] newA = new AxisKeys[im.aC];

        if(bK != null)
        {
            for(int i = 0; i < Mathf.Min(newB.Length, bK.Length); i++)
            {
                newB[i] = bK[i];
            }
        }
        bK = newB;
        if(aK != null)
        {
            for (int i = 0; i < Mathf.Min(newA.Length, aK.Length); i++)
            {
                newA[i] = aK[i];
            }
        }
        aK = newA;
    }

    private void Reset()
    {
        im = GetComponent<InputManager>();
        aK = new AxisKeys[im.aC];
        bK = new KeyCode[im.bC];
    }

    private void Update()
    {
        for(int i = 0; i < aK.Length; i++)
        {
            float val = 0f;
            if (Input.GetKey(aK[i].positive))
            {
                val += 1f;
                newData = true;
            }
            if (Input.GetKey(aK[i].negative))
            {
                val -= 1f;
                newData = true;
            }
            data.a[i] = val;
        }
        for(int i = 0; i < bK.Length; i++)
        {
            if (Input.GetKey(bK[i]))
            {
                data.b[i] = true;
                newData = true;
            }
        }

        if (newData)
        {
            im.ChessInput(data);
            newData = false;
            data.Reset();
        }
    }
}

[System.Serializable]
public struct AxisKeys
{
    public KeyCode positive;
    public KeyCode negative;
}
