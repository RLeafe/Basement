using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class PlayerInfo
{
    public static string playerName = "fufie";
    private static int crtLvl = 4, nxtLvl = crtLvl + 1, xp = 160;

    public static GameObject[] activatedTiles = new GameObject[3];
    public static int[] tilePosition = new int[3];
    public static bool tilesActiveated = false;


    public static string buttName 
        {
            get; set;
        }

    public static string PlayerName
    {
        get { return playerName; }
    }

    public static int CrtLvl
    {
        get { return crtLvl; }
        set { crtLvl = value; }
    }

    public static int NxtLvl
    {
        get{ return nxtLvl; }
        set { nxtLvl = value; }
    }

    public static int exp
    {
        get { return xp; }
        set { xp = value; }
    }

    // Level of Difficulty
    public static int LoD { get; set; }

    public static void xpGain(int amt)
    {
        exp += amt;
        ChangeLvl();
    }
    public static void xpLoss(int amt)
    {
        exp -= amt * LoD;
        ChangeLvl();
    }

    private static void ChangeLvl()
    {
        if(exp >= 1000)
        {
            exp -= 1000;
            CrtLvl += 1;
            NxtLvl = CrtLvl + 1;
        }
        else if (exp < 0 && CrtLvl <= 2)
        {
            exp += 1000;
            CrtLvl -= 1;
            NxtLvl = CrtLvl + 1;
        }
    }

    //private static 
    //TODO: flashlight, battery, items
}
