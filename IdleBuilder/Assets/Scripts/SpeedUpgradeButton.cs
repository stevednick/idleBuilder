using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpgradeButton : MonoBehaviour {

    private int level = 0;
    public float multipler = 0.9f;
    public float upgradeCost;
    public float upgradeCostMultiplier;
    private Text buttonText;
    public GameControllerScript gameControllerScript;
	void Start () {
        buttonText = GetComponentInChildren<Text>();
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        gameControllerScript.speedMultiplier = GetCurrentSpeedMultipler();
        TextUpdate();
	}
    private void Update()
    {
        SetColour();
    }

    void TextUpdate(){
        buttonText.text = "Level " + level + " " + Tools.DisplayNumberShort(GetUpgradeCost());
    }
    float GetCurrentSpeedMultipler(){
        return Mathf.Pow(multipler, level);
    }

    public void CheckIfUpgradePossible(){
        if(gameControllerScript.CheckIfPurchasePossible(GetUpgradeCost())){
            level += 1;
            gameControllerScript.speedMultiplier = GetCurrentSpeedMultipler();
            TextUpdate();
        }
    }
    private float GetUpgradeCost(){
        return upgradeCost * (Mathf.Pow(upgradeCostMultiplier, level));
    }
    private void SetColour() // This is something which should be in a upgradebutton class...
    {
        GetComponentInChildren<Button>().GetComponent<Image>().color = GetUpgradeCost() < gameControllerScript.GetTotal() ? Color.white : Color.grey;
    }
}
