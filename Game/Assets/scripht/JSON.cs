using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class JSON : MonoBehaviour {

    public static float drg;
	private string country;
	private string url;

	// Use this for initialization
	void Start () {
		load ();
		Debug.Log (country);
		if (country == "Seoul") {
			Debug.Log ("Selected seoul");
			url = "http://easyfinder.azurewebsites.net/call";
		} else {
			Debug.Log ("Selected world");
			url = "http://easyfinder.azurewebsites.net/world?country=" + country;
		}
		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest (www));
	}

	public void load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) 
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			country = data.country;
		}	
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
			string data = www.text;
			//string[] arr = data.Split(':');
			//string a = arr [1].Substring (1, 2);
			Debug.Log ("RESULT DATA: " + data);
            drg = float.Parse(data);
            Debug.Log(drg);


		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}

}
