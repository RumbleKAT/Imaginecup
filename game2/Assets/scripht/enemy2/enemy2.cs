﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy2 : MonoBehaviour {

    public float speed = 10f;

    public float health = 100;

    public int value = 50;

    private Transform target;
    private int wavepointIndex = 0;
    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    void Start()
    {
        target = wayPoint2.points[0];
        transform.position = new Vector3(17.55f, 0.565f, 18.215f);

    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.fillAmount = health / 100;
        Debug.Log("aaaaaaaaaaaa");
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Currency.Money += value;
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        transform.LookAt(target);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= wayPoint2.points.Length -1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = wayPoint2.points[wavepointIndex];
        
    }

    void EndPath()
    {
        Currency.Lives--;
        Destroy(gameObject);

    }
}
