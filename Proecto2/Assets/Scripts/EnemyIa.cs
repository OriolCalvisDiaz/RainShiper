using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIa : MonoBehaviour
{
    public List<PointPath> PointPosition;
    public int indexOfPoints = 0;
    public int indexOfPortal = 0;
    public PointPath StartPoint;
    public PointPath EndPoint;
    public float distanceToCollide;

    [MinMaxSlider(-100f, 100f)]
    public MinMax speed;

    [MinMaxSlider(-100f, 100f)]
    public MinMax superSpeed;

    public Color rayColor = Color.green;
    public NextPointPath NextOne;

    public NavMeshAgent agent;

    public int loop = 0;

    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;

        Vector3 previous = StartPoint.PointPosition.position;
        Vector3 position = StartPoint.PointPosition.position;

        foreach (PointPath path in PointPosition)
        {

            position = path.PointPosition.position;
            Gizmos.DrawLine(previous, position);
            previous = path.PointPosition.position;
            Gizmos.DrawSphere(position, 1f);
            
        }
        position = EndPoint.PointPosition.position;
        Gizmos.DrawLine(previous, position);


    }
    // Start is called before the first frame update
    void Start()
    {
        NextOne.Next(StartPoint.PointCollider, StartPoint.PointPosition, indexOfPoints);
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = speed.RandomValue;
        //Debug.DrawRay(this.transform.position, Vector3.down, Color.blue, 3f);
        //RaycastHit Hit;
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, 3f))
        //{
        //    //if(Vector3.Distance(this.transform.position, Hit.transform.)
        //    if (Vector3.Distance(this.transform.position, Hit.point) < 3f) {
        //        transform.position = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
        //    }
        //}
        if (!(indexOfPoints >= PointPosition.ToArray().Length-1))
        {

            agent.destination = PointPosition[indexOfPoints].PointPosition.position;

            this.transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);

                //hit.collider.transform.position == PointPosition[indexOfPoints].PointPosition.position && hit.collider.isTrigger ||
                if (Vector3.Distance(PointPosition[indexOfPoints].PointPosition.position, transform.position ) < distanceToCollide)
                {
                    indexOfPoints++;
                    NextOne.Next(PointPosition[indexOfPoints].PointCollider, PointPosition[indexOfPoints].PointPosition, indexOfPoints);

                }
        }
        else
        {
            agent.destination = EndPoint.PointPosition.position;
            if (Player.win == false)
            {
                Player.lose = true;
            }

        }

        //this.GetComponentInChildren<Rigidbody>().rotation.SetLookRotation(this.transform); //= //Quaternion.Euler(this.GetComponentInChildren<Rigidbody>().rotation.eulerAngles ));

    }
}

[System.Serializable]
public struct NextPointPath
{
    public Collider PointCollider;
    public Transform PointPosition;
    public int num;

    public void Next(Collider a, Transform b, int c)
    {
        PointCollider = a;
        PointPosition = b;
        num = c;
    }

}