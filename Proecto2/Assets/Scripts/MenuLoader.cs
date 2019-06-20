using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    public void Race()
    {
        SceneManager.LoadScene(2);
    }
    public void UltimateRace()
    {
        SceneManager.LoadScene(4);
    }
    public void Arcade()
    {
        SceneManager.LoadScene(3);
    }
}
