using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target1, target2;
    private int wavepointIndex = 0;

    void Start()
    {
        target1 = PathPoints.points[0];
        //target2 = PathPoints2.points2[0];
    }

    void Update()
    {
        //if (spawnpoint = 1)
        //{
            Vector2 direction = target1.position - transform.position;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            if (Vector2.Distance(transform.position, target1.position) <= 0.2f)
            {
                GetNextPath();
            }
        //}
        //else
        /*{
            Vector2 direction = target2.position - transform.position;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            if (Vector2.Distance(transform.position, target2.position) <= 0.2f)
            {
                GetNextPath();
            }
        }*/
    }

     void GetNextPath()
    {
        if (wavepointIndex >= PathPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target1 = PathPoints.points[wavepointIndex];
    }
}
