using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "DataUser", menuName = "SaveGame", order = 1)]
public class UnlockWaves : ScriptableObject
{
    public bool tutorial;
    public bool run;
    public bool godPlayer;
}
