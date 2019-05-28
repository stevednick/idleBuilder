using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools {
    
    public static float baseCost = .2f;
    public static float costMultiplier = 15f;
    public static float basePayout = .01f;
    public static float basePayoutMultiplier = 18.2f;
    public static float baseClickValue = 0.01f;
    public static float costIncrease = 1.1f;
    public static float basePayoutTime = 0.5f;
    public static float PayoutTimeMultiplier = 1.5f;
    public static float upgradeClickBaseCost = 2f;
    public static float upgradeClickMultiplier = 2f;
    public static float upgradeClickCostMultiplier = 2.2f;
    public static int levelsBetweenUpgrade = 20;
    public static float UpgradeMultiplier = 2f;


	
    public static string DisplayNumberLong(float value){
        float v = value;
        string ending = "";
        if(v < 1000f){
            return "$" + v.ToString("0.##");
        }else if (v < 1000000){
            v /= 1000;
            ending = "Thousand";
        }else if (v < 1000000000){
            v /= 1000000;
            ending = "Million";
        }else if (v < 1000000000000){
            v /= 1000000000;
            ending = "Billion";
        }
        return "$" + v.ToString("#.###") + " " + ending;
    }

    public static string DisplayNumberShort(double value)
    {
        double v = value;
        string ending = "";
        if (v < 1000f)
        {
            return "$" + v.ToString("0.00");
        }
        else if (v < 1000000)
        {
            v /= 1000;
            ending = "K";
        }
        else if (v < 1000000000)
        {
            v /= 1000000;
            ending = "M";
        }
        else if (v < 1000000000000f)
        {
            v /= 1000000000f;
            ending = "B";
        }else if (v < 1000000000000000f){
            v /= 1000000000000;
            ending = "T";
        }else if (v < 1000000000000000000f){
            v /= 1000000000000000;
            ending = "q";
        }else if (v < 1000000000000000000000f){
            v /= 1000000000000000000f;
            ending = "Q";
        }
        return "$" + v.ToString("#.000") + ending;
    }
}
