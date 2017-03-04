using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DontBuild : MonoBehaviour {

    public Color hoverColor;
    public Vector3 positionOffset;


    private GameObject turret;

    BuildTree BuildManager;

    private Renderer rend;
    private Color startColor;

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
        if (turret != null)
        {
            return;
        }

    }

    void OnMouseEnter()
    {
        //겹쳐서 생기는 부분 없애기
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
