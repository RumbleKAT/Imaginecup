using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTree : MonoBehaviour {

    public static BuildTree instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;
    }

    public GameObject Tree1;
    public GameObject Tree2;
    public GameObject Tree3;
    public GameObject Tree4;

    public GameObject Tree1_UI;
    public GameObject Tree2_UI;
    public GameObject Tree3_UI;
    public GameObject Tree4_UI;

    private Tree treeToBuild;
    private Tree treeToUI;

    
    public void SetTurretToBuild(Tree tree)
    {
        treeToBuild = tree;
        treeToUI = tree;
    }


    public void BuildtreeOn(Nodeclick node)
    {
        if (ResourceManager.Water < treeToBuild.cost)
        {
            Debug.Log("Not water");
            return;
        }
        if (ResourceManager.Sun < treeToBuild.cost)
        {
            Debug.Log("Not Sun");
            return;
        }
        if (ResourceManager.O2 < treeToBuild.cost)
        {
            Debug.Log("Not O2");
            return;
        }

        ResourceManager.Water -= treeToBuild.cost;
        ResourceManager.Sun -= treeToBuild.cost;
        ResourceManager.O2 -= treeToBuild.cost;

        GameObject turret = (GameObject)Instantiate(treeToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        GameObject TreeUis = (GameObject)Instantiate(treeToUI.TreeUI, node.GetBuildUIPosition(), node.rotationOffset);
        node.tree = turret;
        node.UI = TreeUis;
        

        Debug.Log("Money left:" );
        Debug.Log(ResourceManager.Water + "    " + ResourceManager.Sun + "    " + ResourceManager.O2);
    }

    public bool CanBuild { get { return treeToBuild != null; } }
    //public bool HasMoney { get { return Currency.Money >= turretToBuild.cost; } }
}

