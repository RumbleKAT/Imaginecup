using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Nodeclick : MonoBehaviour {

    public Color hoverColor;
    public static Vector3 positionOffset;
    public Quaternion rotationOffset;
    public Vector3 UIpositionOffset;

    private GameObject turret;
    private GameObject treeUi;

    BuildTree BuildManager;

    private Renderer rend;
    private Color startColor;

    [Header("Optional")]
    public GameObject tree;
    public GameObject UI;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        BuildManager = BuildTree.instance;
    }

    void OnMouseDown()
    {
        //겹쳐서 생기는 부분 없애기
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        //터렛이 생선된 자리일때
        if (!BuildManager.CanBuild)
        {
            return;
        }

        if (turret != null)
        {
            return;
        }

        //build turret
        if (hoverColor.r <= 200f)
        {
            BuildManager.BuildtreeOn(this);

            BuildManager.SetTurretToBuild(null);
        }
        
        
    }


    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    public Vector3 GetBuildUIPosition()
    {
        return transform.position + UIpositionOffset;
    }


    void OnMouseEnter()
    {
        //겹쳐서 생기는 부분 없애기
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(tree == null)
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
