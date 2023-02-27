using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] wayPoints;
    int CurrentWPIndex = 0;

    [SerializeField] float speed = 1f;

    void Update()
        {   
          if(Vector3.Distance(transform.position, wayPoints[CurrentWPIndex].transform.position)<.1f)
            {
                CurrentWPIndex ++;
            // if there are no more waypoints go back to start
                if(CurrentWPIndex >= wayPoints.Length)
                    {
                       CurrentWPIndex = 0;
                    }
            }
          // move one game unit per second 
          transform.position = Vector3.MoveTowards(transform.position, wayPoints[CurrentWPIndex].transform.position, speed * Time.deltaTime);
        }
}
