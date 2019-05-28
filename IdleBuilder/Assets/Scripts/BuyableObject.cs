using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyableObject : MonoBehaviour {
    
    private int level = 0;
    public float baseReturn = 1f;
    public float baseCost = 10f; 
    public float costIncrease = 1.1f;
    public float delay = 1f; // for the time being.. 
    private float nextPayoutTime; 
    public int itemNumber;
    GameControllerScript gameControllerScript;
    Text buttonText;
    public Text numberOwnedText;
    public Text titleText;


	
    void Start () {
        buttonText = GetComponentInChildren<Button>().GetComponentInChildren<Text>();
        SetValues();
        DisplayLevel();
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        nextPayoutTime = Time.time;
        nextPayoutTime = GetNextPayoutTime();
	}

    private void SetValues(){
        baseCost = Tools.baseCost * Mathf.Pow(Tools.costMultiplier, itemNumber);
        costIncrease = Tools.costIncrease;
        baseReturn = Tools.basePayout * Mathf.Pow(Tools.basePayoutMultiplier, itemNumber);
        delay = Tools.basePayoutTime * Mathf.Pow(Tools.PayoutTimeMultiplier, itemNumber);
        DisplayPayout();
    }

    private void DisplayLevel()
    {
        buttonText.text = Tools.DisplayNumberShort(GetCurrentCost());
        numberOwnedText.text = "Owned: " + level;
    }
    private void DisplayPayout(){
        titleText.text = "Payout " + Tools.DisplayNumberShort(GetPayoutAmount());
    }
	
	public void Update () {
        SetColour();
        if(Time.time >= nextPayoutTime){
            nextPayoutTime = GetNextPayoutTime();
            Payout();
        }
	}

    private float GetPayoutAmount(){
        return baseReturn * level * Mathf.Pow(Tools.UpgradeMultiplier, CheckUpgradeLevel());
    }
    private int CheckUpgradeLevel(){
        return (int)Mathf.Floor(level / (float)Tools.levelsBetweenUpgrade);
    }

    private void Payout(){
        gameControllerScript.AddValueFromBuyableObject(GetPayoutAmount());
    }

    public void LevelUp(){
        if(level == 0){
            nextPayoutTime = GetNextPayoutTime();
        }
        level += 1;
        DisplayLevel();
        DisplayPayout();
    }

    private float GetNextPayoutTime(){
        return nextPayoutTime + (delay * gameControllerScript.GetSpeedMultiplier());
    }

    public void CheckIfUpgradePossible(){
        if (gameControllerScript.CheckIfPurchasePossible(GetCurrentCost())){
            LevelUp();
        }
    }

    private float GetCurrentCost(){
        return baseCost * Mathf.Pow(costIncrease, level);
    }

    private void SetColour(){
        GetComponentInChildren<Button>().GetComponent<Image>().color = GetCurrentCost() < gameControllerScript.GetTotal() ? Color.white : Color.grey;
    }



}
