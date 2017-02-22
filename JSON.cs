using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;

public class JSON : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string url = "http://easyfinder.azurewebsites.net/call";
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

			string value = makevalue (www.text);
			string grade = makegrade (www.text);

			float resultValue = float.Parse (value);
			Debug.Log ("Value :" + resultValue + "/n" + "Grade: " + grade);

		
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
	private string makevalue(string jsonString)
	{
		JsonData jsonPlayer = JsonMapper.ToObject (jsonString);
		string value = jsonPlayer ["value"].ToString();

		return value;
	}
	private string makegrade(string jsonString)
	{
		JsonData jsonPlayer = JsonMapper.ToObject (jsonString);
		string grade = jsonPlayer ["grade"].ToString();

		return grade;
	}



}
