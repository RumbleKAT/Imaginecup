using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop1 : MonoBehaviour {

    BuildTree buildTree;
    MakeResource MR;

    public Tree waterTree;
    public Tree sunTree;
    public Tree o2Tree;
    public Tree allTree;

    void Start()
    {
        buildTree = BuildTree.instance;
        
    }



    public void SelectTree1()
    {
        Debug.Log("Tree1");
        buildTree.SetTurretToBuild(waterTree);
        Nodeclick.positionOffset = new Vector3(0f, 0.3f, 0f);
        MakeResource.SelectResource = 0;
    }

    public void SelectTree2()
    {
        Debug.Log("Tree2");
        buildTree.SetTurretToBuild(sunTree);
        Nodeclick.positionOffset = new Vector3(0f, 0f, 0f);
        MakeResource.SelectResource = 1;
    }

    public void SelectTree3()
    {
        Debug.Log("Tree3");
        buildTree.SetTurretToBuild(o2Tree);
        Nodeclick.positionOffset = new Vector3(0f, 0f, 0f);
        MakeResource.SelectResource = 2;

    }

    public void SelectTree4()
    {
        Debug.Log("Tree4");
        buildTree.SetTurretToBuild(allTree);
        Nodeclick.positionOffset = new Vector3(0f, 0f, 0f);
        MakeResource.SelectResource = 3;

    }

}
