using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JSON : MonoBehaviour {

    public static float drg;

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
            drg = float.Parse(a);
            Debug.Log(drg);


		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}

}
