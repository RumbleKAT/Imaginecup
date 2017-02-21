﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = wayPoint2.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= wayPoint2.points.Length - 1)
        {
            Destroy(gameObject);
        }

        wavepointIndex++;
        target = wayPoint2.points[wavepointIndex];
    }
}
