using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

    public float speedMultiplier = 1f;
    public Text totalText;
    public double total = 0f; // public for testing... 
    private float clickHereButtonIncrementAmount = 1f;
    private float clickMultiplier = 1f;

    private void Start()
    {
        clickHereButtonIncrementAmount = Tools.baseClickValue;
    }

    private void Update(){
        totalText.text = Tools.DisplayNumberShort(total);
    }

    public void ClickHereButtonPressed(){
        total += clickHereButtonIncrementAmount * clickMultiplier;
    }

    public void AddValueFromBuyableObject(float value){
        total += value; 
    }

    public bool CheckIfPurchasePossible(float value){
        if(total >= value){
            total -= value;
            return true;
        }
        return false;
    }

    public double GetTotal(){
        return total;
    }

    public float GetSpeedMultiplier(){
        return speedMultiplier;
    }

    public void SetClickMultiplier(float value){
        clickMultiplier = value;
    }



}
