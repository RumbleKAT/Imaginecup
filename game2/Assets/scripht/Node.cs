using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlupprint;
    [HideInInspector]
    public bool isUpgrade = false;

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

        //터렛이 생선된 자리일때
        if(turret != null)
        {
            BuildManager.SelectNode(this);
            return;
        }

        //선택된 터렛이 없을때
        if (!BuildManager.CanBuild)
            return;

        //build turret
        //BuildManager.BuildTurretOn(this);
        BuildTurret(BuildManager.GetTurretToBuild());



        BuildManager.SelctTurretToBuild(null);
    }

    void BuildTurret(TurretBlueprint blueprint) {
        if (Currency.Money < blueprint.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        Currency.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlupprint = blueprint;

        Debug.Log("Money left:" + Currency.Money);

    }

    public void UpgradeTurret()
    {
        if (Currency.Money < turretBlupprint.upgaradeCost)
        {
            Debug.Log("Not enough Upgarde money");
            return;
        }

        Currency.Money -= turretBlupprint.upgaradeCost;

        //Get rid of old turret
        Destroy(turret);

        //build new one
        GameObject _turret = (GameObject)Instantiate(turretBlupprint.upgardePrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        isUpgrade = true;

        Debug.Log("Money left:" + Currency.Money);
    }

    public void SellTurret()
    {
        Currency.Money += turretBlupprint.GetSellAmount();
        Destroy(turret);
        turretBlupprint = null;
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
