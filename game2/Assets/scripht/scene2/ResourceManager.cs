using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class ResourceManager : MonoBehaviour {

	public static int Water;
    public static int Sun;
    public static int O2;

    public Text leftWater;
    public Text leftSun;
    public Text leftO2;
    public Text CurrencyfineDust;

    void Start()
    {
        Water = 1000;
        Sun = 1000;
        O2 = 1000;

        Debug.Log(Water + "    " + Sun + "    " + O2);
    }

    void Update()
    {
        leftWater.text = Water.ToString();
        leftSun.text = Sun.ToString();
        leftO2.text = O2.ToString();
        CurrencyfineDust.text = JSON.drg.ToString();
    }
}
