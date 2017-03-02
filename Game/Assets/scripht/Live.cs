using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Live : MonoBehaviour {

    public Text liveText;
	
	// Update is called once per frame
	void Update () {
        liveText.text = Currency.Lives.ToString();
	}
}
