using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    buildManager BuildManager;

    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        BuildManager = buildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        //겹쳐서 생기는 부분 없애기
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        //선택된 터렛이 없을때
        if (!BuildManager.CanBuild)
            return;

        //터렛이 생선된 자리일때
        if(turret != null)
        {
            return;
        }

        //build turret
        BuildManager.BuildTurretOn(this);

        BuildManager.SelctTurretToBuild(null);
    }

    void OnMouseEnter()
    {
        //겹쳐서 생기는 부분 없애기
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //선택된 터렛이 없을때
        if (!BuildManager.CanBuild)
            return;
       
        //돈이 없을때
        if (BuildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
           
        
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
