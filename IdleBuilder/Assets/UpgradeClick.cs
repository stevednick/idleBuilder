using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeClick : MonoBehaviour {


    private int level = 0;
    private Text buttonText;
    private GameControllerScript gameControllerScript;

    private void Start()
    {
        buttonText = GetComponentInChildren<Text>();
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        TextUpdate();
    }

    private void Update()
    {
        SetColour();
    }
    private float GetClickMultipler(){
        return Mathf.Pow(Tools.upgradeClickMultiplier, level);
    }
    private float GetUpgradeCost()
    {
        return Tools.upgradeClickBaseCost * (Mathf.Pow(Tools.upgradeClickCostMultiplier, level));
    }
    public void CheckIfUpgradePossible()
    {
        if (gameControllerScript.CheckIfPurchasePossible(GetUpgradeCost()))
        {
            level += 1;
            gameControllerScript.SetClickMultiplier(GetClickMultipler());
            TextUpdate();
        }
    }
    void TextUpdate()
    {
        buttonText.text = "Level " + level + " " + Tools.DisplayNumberShort(GetUpgradeCost());
    }

    private void SetColour()
    {
        GetComponentInChildren<Button>().GetComponent<Image>().color = GetUpgradeCost() < gameControllerScript.GetTotal() ? Color.white : Color.grey;
    }
}
