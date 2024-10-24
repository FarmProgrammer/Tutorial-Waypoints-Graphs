using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    public GameObject[] wayPoints;
    int currentWaypoint = 0;

    public float speed = 10;
    public float rotSpeed = 10;

    GameObject tracker;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        Destroy(tracker.GetComponent<Collider>());
        tracker.transform.position = transform.position;
        tracker.transform.rotation = transform.rotation;
    }

    void ProgressTracker()
    {
        if (Vector3.Distance(tracker.transform.position, wayPoints[currentWaypoint].transform.position) < 3)
            currentWaypoint++;


        if (currentWaypoint >= wayPoints.Length)
            currentWaypoint = 0;

        tracker.transform.LookAt(wayPoints[currentWaypoint].transform);
        tracker.transform.Translate(0, 0, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        ProgressTracker();

        //transform.LookAt(wayPoints[currentWaypoint].transform);
        transform.Translate(0, 0, speed * Time.deltaTime);

        Quaternion lookAtWaypoint = Quaternion.LookRotation(wayPoints[currentWaypoint].transform.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookAtWaypoint, rotSpeed * Time.deltaTime);
    }
}
