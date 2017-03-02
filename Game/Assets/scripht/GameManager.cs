using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GmaeIsOVer;
    public GameObject gameOverUI;

    void Start()
    {
        GmaeIsOVer = false;
    }

	// Update is called once per frame
	void Update () {
        if (GmaeIsOVer)
        {
            return;
        }

	    if(Currency.Lives <= 0)
        {
            EndGame();
        }


        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
	}

    void EndGame()
    {
        GmaeIsOVer = true;
        Debug.Log("Game Over");

        gameOverUI.SetActive(true);
    }
}
