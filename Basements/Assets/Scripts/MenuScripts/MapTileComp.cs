using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapTileComp : MonoBehaviour
{
    public bool isActive = false, isHouse = false;
    [SerializeField] public GameObject[] houses;
    [SerializeField] public ParticleSystem particle;
    [SerializeField] public Button gridButton;
    [SerializeField] public GameObject gridCanvas;
    [SerializeField] public TMP_Text level;
    [HideInInspector] public int difLvl;

    private GameObject houseClone;
    private ParticleSystem particleClone;
    private int activatedHouse;
    private Vector3 houseRotation;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        Difficulty.CalculateDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayParticleSys()
    {
        var makeParticleIfNull = particleClone == null;
        var particlePos = transform.position;

        if (makeParticleIfNull)
        {
            particleClone = Instantiate(particle, particlePos, Quaternion.identity);
        }

        var hasParticleStopped = particleClone != null && particleClone.isStopped;

        if (hasParticleStopped)
        {
            particleClone.Play();
            gridCanvas.SetActive(true);
        }
        
    }

    public void StopParticleSys()
    {
        var stopAllFX = GameObject.FindGameObjectsWithTag("GridParticleSys");
        var hideAllCanvas = GameObject.FindGameObjectsWithTag("GridTileCanvas");

        if (stopAllFX.Length > 0)
        {
            for (int i = 0; i < stopAllFX.Length; i++)
            {
                Destroy(stopAllFX[i]);
            }
        }
        if (hideAllCanvas.Length > 0)
        {
            for (int i = 0; i < hideAllCanvas.Length; i++)
            {
                hideAllCanvas[i].SetActive(false);
            }
        }
    }

    public void OnHouseCreate()
    {
        if (isActive && !isHouse)
        {
            if (gridButton.interactable == false)
            {
                gridButton.interactable = true;
            }

            difLvl = Random.Range(0, Difficulty.level.Length);

            level.text = Difficulty.level[difLvl].ToString();

            houseRotation = new Vector3(0f, Random.Range(-45f, 45f), 0f);
            activatedHouse = Random.Range(0, houses.Length);
            var housePos = transform.position;

            houseClone = Instantiate(houses[activatedHouse], housePos, Quaternion.Euler(houseRotation));

            for (int i = 0; i < PlayerInfo.activatedTiles.Length; i++)
            {
                var houseNotActive = PlayerInfo.activatedTiles[i] == null && houseClone != null;

                if (houseNotActive)
                {
                    PlayerInfo.activatedTiles[i] = houseClone;
                }
            }

            isHouse = true;
        }

    }

    public void OnHouseDestroy()
    {
        for(int i=0; i<PlayerInfo.activatedTiles.Length; i++)
        {
            if (PlayerInfo.activatedTiles[i] != null) return;

            for (int x = 0; x < houses.Length; x++)
            {
                Destroy(houseClone);
            }

            if (gridButton.interactable == true)
            {
                gridButton.interactable = false;
            }

            StopParticleSys();

            isHouse = false;
        }
        
    }

    public void OnActiveChangeColourGreen()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    public void OnActiveChangeColourRed()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
