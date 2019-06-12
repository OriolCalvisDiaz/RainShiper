using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Range(0,10)]
    /// <summary>
    /// AxisCount
    /// </summary>
    public int aC;
    [Range(0,20)]
    /// <summary>
    /// ButtonCount
    /// </summary>
    public int bC;

    public Controller controller;

    public void ChessInput(InputData data)
    {
        controller.ReadInput(data);
    }

    public void RefreshTracker()
    {
        DeviceTracker dt = GetComponent<DeviceTracker>();
        if(dt != null)
        {
            dt.Refresh();
        }
    }
}

public struct InputData
{
    /// <summary>
    /// axes
    /// </summary>
    public float[] a; 

    /// <summary>
    /// buttons
    /// </summary>
    public bool[] b;

    /// <summary>
    /// Set Axis and Button
    /// </summary>
    /// <param name="i">Axis</param>
    /// <param name="j">Button</param>
    public InputData(int i, int j)
    {
        a = new float[i];
        b = new bool[j];
    }
    
    public void Reset(int i = 0, int j = 0)
    {

        if (i < a.Length)
        {
            a[i] = 0f;
            i++;
        }
        if (j < b.Length)
        {
            b[j] = false;
            j++;
        }
        if (i < a.Length || j < b.Length)
        {
            Reset(i, j);

        }
    }
}