using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class country : MonoBehaviour {

	public string world;

	void Start () {
		//Button btn = yourButton.GetComponent<Button>();
		//btn.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
		Debug.Log (gameObject.tag);
		Debug.Log (world);
		save ();
		SceneManager.LoadScene (2);
	}

	public void save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		data.country = world;

		bf.Serialize (file, data);
		file.Close ();
		Debug.Log ("SAVED DATA!");
	}



}

[Serializable]
class PlayerData
{
	public string country;
}

