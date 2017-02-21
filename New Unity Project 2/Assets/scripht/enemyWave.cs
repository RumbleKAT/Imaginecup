using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyWave : MonoBehaviour {

    public GameObject enemy_1;


    public float timBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;

    public Text waveCountdownText;

    
    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i<waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }


    void SpawnEnemy()
    {
        Instantiate(enemy_1, transform);
    }


    void Update()
    {

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }
}
