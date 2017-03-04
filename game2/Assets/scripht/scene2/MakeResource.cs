using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MakeResource : MonoBehaviour {

    public float countDown = 100f;
    public TextMesh countDownText;


    public static int SelectResource;


    [Header("Optional")]
    public int Resources;

    Tree treeR;

    void Start()
    {
        Resources = SelectResource;
        Debug.Log(SelectResource);
    }

    void Update()
    {
        
        if(countDown > 0)
        {
            countDown -= Time.deltaTime;
            countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

            countDownText.text = string.Format("{0:00.00}", countDown);
        }
        else
        countDownText.text = "CLICK";

        
        /*
        if (Input.GetMouseButton(0))
        {
            
        }*/
    }

    void OnMouseDown()
    {
        if (countDownText.text == "CLICK")
        {
            countDown = 30f;
            Debug.Log(countDown);

            ResourceUp();

        }
    }

    void ResourceUp()
    {
        
        if (Resources == 0)
            ResourceManager.Water += 100;
        Debug.Log("aaaa");
        if (Resources == 1)
            ResourceManager.Sun += 100;
        if (Resources == 2)
            ResourceManager.O2 += 100;
        if (Resources == 3)
        {
            ResourceManager.Water += 100;
            ResourceManager.Sun += 100;
            ResourceManager.O2 += 100;
        }
    }


}
