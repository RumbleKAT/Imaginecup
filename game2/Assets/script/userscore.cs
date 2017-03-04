using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class userscore : MonoBehaviour {

	public Text score;
	private int sendscore;
	private bool turn;

	// Use this for initialization
	void Start () {
		turn = false;
	}
	
	// Update is called once per frame
	void Update () {
		sendscore = int.Parse(score.text);
		Debug.Log (sendscore);
		if (turn == true) {
			changescene ();
		}
	}

	public void savescore()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerScore.dat");

		PlayerScore data = new PlayerScore ();
		data.score = sendscore;

		bf.Serialize (file, data);
		file.Close ();
		Debug.Log ( sendscore + "SAVED DATA!");
		turn = true;
	}

	void changescene()
	{
		SceneManager.LoadScene (4);
	}

	public void gotoRank()
	{
		SceneManager.LoadScene (5);
	}

}
[Serializable]
class PlayerScore
{
	public int score;
}