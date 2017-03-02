using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public float speed = 10f;

    public int health = 100;

    public int value = 50;

    private Transform target;
    private int wavepointIndex = 0;

    public GameObject deathEffect;

    void Start()
    {
        target = wayPoint.points[0];
        transform.position = new Vector3(17.55f,0.565f,18.215f);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("aaaaaaaaaaaa");
        if (health<= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect =Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Currency.Money += value;
        Destroy(gameObject);
    }


    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.LookAt(target);
        if(Vector3.Distance(transform.position,target.position)<= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= wayPoint.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = wayPoint.points[wavepointIndex];
        
    }

    void EndPath()
    {
        Currency.Lives--;
        Destroy(gameObject);

    }
}
