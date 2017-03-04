using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TurretBlueprint : MonoBehaviour {

    public GameObject prefab;
    public int cost;

    public GameObject upgardePrefab;
    public int upgaradeCost;


    public int GetSellAmount()
    {
        return cost / 2;
    }
}
