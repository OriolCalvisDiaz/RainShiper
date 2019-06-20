using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllGamesAndScenes : MonoBehaviour
{
    public UnlockWaves uw;
    public Button a;
    public Button b;
    public Button c;


    void Start()
    {
        if(uw.tutorial == false)
        {
            b.interactable = false;
            c.interactable = false;
        }
        else
        {
            b.interactable = true;
            c.interactable = false;
        }
        if (uw.run == false) {
            c.interactable = false;
        }
        else
        {
            c.interactable = true;
        }
    }
}
