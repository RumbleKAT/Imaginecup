﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHP : MonoBehaviour {

    public Quaternion rot;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        transform.rotation = rot;
    }
}