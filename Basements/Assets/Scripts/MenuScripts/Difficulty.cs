using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Difficulty
{
    public static int difLvl;
    public static int[] level = new int[3];

    public static void CalculateDifficulty()
    {
        switch (PlayerInfo.CrtLvl)
        {
            case 0:
            case 1:
            case 2:
                TierOne();
                break;

            case 3:
            case 4:
            case 5:
                TierTwo();
                break;

            case 6:
            case 7:
            case 8:
                TierThree();
                break;

            case 9:
            case 10:
            case 11:
                TierFour();
                break;

            default:
                if (PlayerInfo.CrtLvl >= 12)
                {
                    TierFive();
                }
                else { Debug.LogError("CacluateDifficulty - Could not find the player level.");  }
                break;
        }
    }

    public static void TierOne()
    {
        PlayerInfo.LoD = 0;
        level[0] = 1;
        level[1] = 1;
        level[2] = 2;
    }
    public static void TierTwo()
    {
        PlayerInfo.LoD = 2;
        level[0] = 3;
        level[1] = 4;
        level[2] = 5;
    }
    public static void TierThree()
    {
        PlayerInfo.LoD = 4;
        level[0] = 6;
        level[1] = 7;
        level[2] = 8;
    }
    public static void TierFour()
    {
        PlayerInfo.LoD = 6;
        level[0] = 9;
        level[1] = 10;
        level[2] = 11;
    }
    public static void TierFive()
    {
        PlayerInfo.CrtLvl -= 1;
        PlayerInfo.exp = 0;
        level[0] = 12;
        level[1] = 13;
        level[2] = 14;
    }

}
