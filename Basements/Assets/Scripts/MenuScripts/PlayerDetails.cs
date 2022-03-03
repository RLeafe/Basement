using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDetails : MonoBehaviour
{
    public TMP_Text playerName;
    public TMP_Text crtLvl, nxtLvl;
    public Slider xpBar;

    // Start is called before the first frame update
    void Start()
    {
        xpBar.maxValue = 1000;

        playerName.text = PlayerInfo.PlayerName;
        crtLvl.text = PlayerInfo.CrtLvl.ToString();
        nxtLvl.text = PlayerInfo.NxtLvl.ToString();
        xpBar.value = PlayerInfo.exp;

        PlayerInfo.xpGain(80);
        crtLvl.text = PlayerInfo.CrtLvl.ToString();
        nxtLvl.text = PlayerInfo.NxtLvl.ToString();
        xpBar.value = PlayerInfo.exp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
