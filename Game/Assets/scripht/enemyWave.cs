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

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);

        if(waveIndex >= 10)
        {
            countdown = 30f;
            waveIndex = 1;
        }
    }
}
