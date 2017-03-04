using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemyWave2 : MonoBehaviour {

    public GameObject enemy_1;
    public Transform start;

    public float timBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;

    private float a;

    public Text waveCountdownText;

    public GameObject Clear;


    IEnumerator SpawnWave()
    {
        waveIndex++;
        Currency.Rounds++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(a);
        }
    }


    void SpawnEnemy()
    {
        Instantiate(enemy_1, start.transform);
    }

    void Start()
    {
        
    }


    void Update()
    {
        a = JSON.drg/10;

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timBetweenWaves;
            Debug.Log(a);
        }

        waveCountdownText.text = "00:"+Mathf.Round(countdown).ToString();

        countdown -= Time.deltaTime;


        if (waveIndex >= 15)
        {
            countdown = 30f;
            waveIndex = 1;
            Clear.active = true;
        }
    }
}
