using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;


    private GameObject turret;

    buildManager BuildManager;

    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        BuildManager = buildManager.instance;
    }

    void OnMouseDown()
    {
        //겹쳐서 생기는 부분 없애기
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        //선택된 터렛이 없을때
        if (BuildManager.GetTurretToBuild() == null)
            return;

        //터렛이 생선된 자리일때
        if(turret != null)
        {
            return;
        }

        //build turret
        GameObject turretToBuild = buildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        //겹쳐서 생기는 부분 없애기
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //선택된 터렛이 없을때
        if (BuildManager.GetTurretToBuild() == null)
            return;

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
