using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGridComp : MonoBehaviour
{
    [SerializeField] public GameObject[] mapTiles;

    [HideInInspector] public bool isActive;
    [SerializeField] private bool tilesActiveated = false;

    private int[] tilePosition = new int[3];

    // Start is called before the first frame update
    void Start()
    {
        mapTiles = GameObject.FindGameObjectsWithTag("MapTile");

        if(PlayerInfo.tilesActiveated == true)
        {
            tilesActiveated = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckTilesActive();
        SetTilesToActive();
    }

    void CheckTilesActive()
    {
        if (tilesActiveated) return;

        // Loop through all elements
        for (int i = 0; i < mapTiles.Length; i++)
        {
            // if element is true
            if (mapTiles[i].GetComponent<MapTileComp>().isActive == true)
            {

                // break early and loop again
                tilesActiveated = true;
                break;
            }
            // set to false if all elements are false loop did not break
            tilesActiveated = false;
        }
    }

    void SetTilesToActive()
    {
        if (!tilesActiveated)
        {
            for(int i=0; i<tilePosition.Length; i++)
            {
                tilePosition[i] = Random.Range(0, mapTiles.Length);
                if(tilePosition[1] == tilePosition[0])
                {
                    tilePosition[1] = Random.Range(0, mapTiles.Length);
                }
                if (tilePosition[2] == tilePosition[1] || tilePosition[2] == tilePosition[0])
                {
                    tilePosition[2] = Random.Range(0, mapTiles.Length);
                }
            }

            for (int x = 0; x < tilePosition.Length; x++)
            {

                mapTiles[tilePosition[x]].GetComponent<MapTileComp>().isActive = true;
                mapTiles[tilePosition[x]].GetComponent<MapTileComp>().OnHouseCreate();
                mapTiles[tilePosition[x]].GetComponent<MapTileComp>().OnActiveChangeColourGreen();
                tilesActiveated = true;
            }

        }

    }

    // TEMP
    public void refresh()
    {
        for (int i = 0; i < tilePosition.Length; i++)
        {
            if (tilesActiveated) return;

            mapTiles[tilePosition[i]].GetComponent<MapTileComp>().isActive = false;
            mapTiles[tilePosition[i]].GetComponent<MapTileComp>().OnHouseDestroy();
            mapTiles[tilePosition[i]].GetComponent<MapTileComp>().OnActiveChangeColourRed();
            tilesActiveated = false;

        }
    }
}
