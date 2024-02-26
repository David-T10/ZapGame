using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{

    [SerializeField] private GameObject[] wayPointsArr;
    private int currWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(wayPointsArr[currWaypointIndex].transform.position, transform.position) < .1f) 
        {
            currWaypointIndex++;
            if (currWaypointIndex >= wayPointsArr.Length) 
            {
                currWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPointsArr[currWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
