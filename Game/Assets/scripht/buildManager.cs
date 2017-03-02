using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildManager : MonoBehaviour {

    public static buildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;
    }

    public GameObject missileLauncherPrefab;
    public GameObject standardTurretPrefab;

    private TurretBlueprint turretToBuild;

    

    public void BuildTurretOn(Node node)
    {
        if(Currency.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        Currency.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(),Quaternion.identity);
        node.turret = turret;

        Debug.Log("Money left:" + Currency.Money);
    }

    public void SelctTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public bool CanBuild { get { return turretToBuild != null;} }
    public bool HasMoney { get { return Currency.Money >= turretToBuild.cost; } }
}
