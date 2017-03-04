using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ranking : MonoBehaviour {

	public Text first;
	public Text second;
	public Text third;
	public Text fourth;
	public Text fifth;


	// Use this for initialization
	void Start () {
		string url2 = "http://easyfinder.azurewebsites.net/ranking";
		WWW www = new WWW (url2);
		StartCoroutine (WaitForRequest (www));
	}
	
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);

			string a = www.text;
			char b = ':';
			string[] ranking = a.Split (b);
			//string[] result = new Array (ranking.Length - 1);

			for (int i = 0; i < ranking.Length-1; i++) {
				ranking [i] = (ranking.Length-1)-i + "TH :" + ranking [i];
				Debug.Log (ranking [i]);
				if ((ranking.Length - 1) - i == 1) 
				{
					first.text = ranking [i];
				}
				else if((ranking.Length - 1) - i == 2)
				{
					second.text = ranking [i];
				}
				else if((ranking.Length - 1) - i == 3)
				{
					third.text = ranking [i];
				}
				else if((ranking.Length - 1) - i == 4)
				{
					fourth.text = ranking [i];
				}
				else 
				{
					fifth.text = ranking [i];
				}
			}


		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
	public void changescene()
	{
		SceneManager.LoadScene (2);
	}
}
