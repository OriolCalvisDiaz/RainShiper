using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FeedBackPoints
{
    public bool available = true;
    public PointPath Point;
}

public class PoolPartyObjectives : MonoBehaviour
{
    [SerializeField]
    private List<FeedBackPoints> feedBackPointsList = new List<FeedBackPoints>();

    private void Start()
    {
        foreach (FeedBackPoints point in feedBackPointsList)
        {
            point.available = true;
        }
    }

    public FeedBackPoints getPoint(int i)
    {
        if (feedBackPointsList[i].available)
        {
            return feedBackPointsList[i];
        }
        return null;
    }

    public List<FeedBackPoints> getTexts() => feedBackPointsList;
}
