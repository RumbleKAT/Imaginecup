using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;



public class userdata : MonoBehaviour {

	public Text score;
	public InputField username;
	private int userscore;
	private string userID;

	public GameObject complete;
	public GameObject fail;
	
	void Start()
	{
		load (); //load your score;
		complete.SetActive (false);
		fail.SetActive (false);
	}

	void Update () {
		
	}

	public void load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerScore.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerScore.dat", FileMode.Open);
			PlayerScore data = (PlayerScore)bf.Deserialize (file);
			file.Close ();

			userscore = data.score;
			score.text = userscore.ToString ();
		} else {
			Debug.Log ("File not Found");
		}
	}
	public void send()
	{
		userID = username.text; // usertext load 
		string url = "http://easyfinder.azurewebsites.net/userdata?user_ID="+userID+"&user_SCORE="+userscore;
		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest (www));
	}

	public void back()
	{
		SceneManager.LoadScene (2);
	}


	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
			complete.SetActive (true);

		} else {
			Debug.Log("WWW Error: "+ www.error);
			fail.SetActive (true);

		}    
	}

}
