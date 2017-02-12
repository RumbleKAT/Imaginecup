using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JSON : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string url = "http://easyfinder.azurewebsites.net/weather";
		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest (www));
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
			string data = www.text;
			string[] arr = data.Split(':');
			string a = arr [1].Substring (1, 2);
			Debug.Log ("RESULT DATA: " + a);


		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
}
