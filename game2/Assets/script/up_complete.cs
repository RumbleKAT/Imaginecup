using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class up_complete : MonoBehaviour {

	public GameObject complete;
	public GameObject fail;

	public void cancel()
	{
		complete.SetActive (false);
		fail.SetActive (false);
	}
}
