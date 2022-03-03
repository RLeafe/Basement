using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConfirmButtonComp : MonoBehaviour
{
    public Button confButt;
    [HideInInspector] public bool checkButt;

    private MapTileComp gridTile;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo.buttName = "";
        checkButt = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!checkButt)
        {
            confButt.gameObject.SetActive(false);
        }
        else
        {
            confButt.gameObject.SetActive(true);
        }
        


    }
    public IEnumerator OnConfirmSelect()
    {
        yield return new WaitForSeconds(5f);

        
    }

    public void OnTileSelect()
    {
        PlayerInfo.buttName = EventSystem.current.currentSelectedGameObject.name;

        gridTile = GameObject.Find(PlayerInfo.buttName).GetComponentInParent<MapTileComp>();

        if (PlayerInfo.buttName != "")
        {
            Debug.Log("selected" + PlayerInfo.buttName);
            Difficulty.difLvl = Difficulty.level[gridTile.difLvl];
            checkButt = true;
            
        }
        else
        {
            checkButt = false;
        }

        Debug.Log(PlayerInfo.buttName + " " + Difficulty.level[gridTile.difLvl]);
        //Difficulty.difLvl = difLvl;
        //Debug.Log("D.difLvl: " + Difficulty.difLvl + " & " + "difLvl: " + difLvl);
    }
}
