using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    buildManager BuildManager;

    void Start()
    {
        BuildManager = buildManager.instance;
    }


    public void PurchaseStandardTurret()
    {
        Debug.Log("standard");
        BuildManager.SetTurretToBuild(BuildManager.standardTurretPrefab);
    }

    public void PurchaseAnotherTurret()
    {
        Debug.Log("Another");
        BuildManager.SetTurretToBuild(BuildManager.anotherTurretPrefab);

    }
}
