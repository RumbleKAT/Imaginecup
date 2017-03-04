using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyWave : MonoBehaviour {

    public GameObject enemy_1;


    public float timBetweenWaves = 5f;
    private float countdown = 5f;
    public Transform start;
    private int waveIndex = 0;

    public Text waveCountdownText;
    public GameObject Clear;
    private float a;

    IEnumerator SpawnWave()
    {
        waveIndex++;
        Currency.Rounds++;

        for (int i = 0; i<waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }


    void SpawnEnemy()
    {
        
        //GameObject temp =
        Instantiate(enemy_1);
    }


    void Update()
    {

        a = JSON.drg / 10;

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timBetweenWaves;
            Debug.Log(a);
        }

        waveCountdownText.text = "00:" + Mathf.Round(countdown).ToString();

        countdown -= Time.deltaTime;


        if (waveIndex >= 15)
        {
            countdown = 30f;
            waveIndex = 1;
            Clear.active = true;
        }
    }
}
