using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NodeUI : MonoBehaviour {

    public GameObject ui;

    private Node target;

    public Text upgradeCost;
    public Button UpgradeButton;

    public Text sellAmount;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition() + new Vector3(0f,1.7f,0f);

        if (!target.isUpgrade)
        {
            upgradeCost.text = "$" + target.turretBlupprint.upgaradeCost;
            UpgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done";
            UpgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlupprint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
    
    public void Upgrade()
    {
        target.UpgradeTurret();
        buildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        buildManager.instance.DeselectNode();

    }
}
