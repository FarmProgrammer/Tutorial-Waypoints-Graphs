using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    public GameObject[] wayPoints;
    int currentWaypoint = 0;

    public float speed = 10;
    public float rotSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, wayPoints[currentWaypoint].transform.position) < 3)
            currentWaypoint++;
        

        if (currentWaypoint >= wayPoints.Length)
            currentWaypoint = 0;

        //transform.LookAt(wayPoints[currentWaypoint].transform);
        transform.Translate(0, 0, speed * Time.deltaTime);

        Quaternion lookAtWaypoint = Quaternion.LookRotation(wayPoints[currentWaypoint].transform.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookAtWaypoint, rotSpeed * Time.deltaTime);
    }
}
