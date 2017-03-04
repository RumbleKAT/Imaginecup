using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    buildManager BuildManager;

    void Start()
    {
        BuildManager = buildManager.instance;
    }


    public void SelectStandardTurret()
    {
        Debug.Log("standard");
        BuildManager.SelctTurretToBuild(standardTurret);
        Debug.Log(standardTurret.cost);
    }

    public void SelectMissileLau()
    {
        Debug.Log("Another");
        BuildManager.SelctTurretToBuild(missileLauncher);

    }
}
