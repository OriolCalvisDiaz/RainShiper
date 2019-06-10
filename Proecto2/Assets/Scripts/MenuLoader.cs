using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Race()
    {
        SceneManager.LoadScene(2);
    }
    public void UltimateRace()
    {
        SceneManager.LoadScene(3);
    }
    public void Arcade()
    {
        SceneManager.LoadScene(4);
    }
    public void MultipleArcade()
    {
        SceneManager.LoadScene(5);
    }
}
