using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraComp : MonoBehaviour
{

    public Canvas mainMenu, playerInfo;
    public MenuLightComp menuLight;

    private bool storeActive = false, optionsActive = false;

    private Light StoreRight, StoreLeft, StoreTop;
    private Light OptionsLeft, OptionsRight, OptionsTop;

    private Vector3 StartPos, StartRot;

    // Start is called before the first frame update
    void Start()
    {
        StoreRight = GameObject.Find("StoreLightRight").GetComponent<Light>();
        StoreLeft = GameObject.Find("StoreLightLeft").GetComponent<Light>();
        StoreTop = GameObject.Find("StoreLightTop").GetComponent<Light>();

        OptionsLeft = GameObject.Find("OptionsLightLeft").GetComponent<Light>();
        OptionsRight = GameObject.Find("OptionsLightRight").GetComponent<Light>();
        OptionsTop = GameObject.Find("OptionsLightTop").GetComponent<Light>();

        StartPos = new Vector3(0f, 1f, -10f);
        StartRot = new Vector3(0f, 0f, 0f);

        transform.position = StartPos;
        transform.rotation = Quaternion.Euler(StartRot);
    }

    public void OnGameStart()
    {
        playerInfo.enabled = false;
        mainMenu.enabled = false;
    }

    public void OnFindClick()
    {
        mainMenu.enabled = false;
    }

    public void OnStoreClick()
    {
        mainMenu.enabled = false;

        if (storeActive) return;
        StartCoroutine(StoreLightingEnable());
    }

    public void OnOptionsClick()
    {
        mainMenu.enabled = false;
        playerInfo.enabled = false;

        if (optionsActive) return;
        StartCoroutine(OptionsLightingEnable());
    }
    
    public void OnBackClick()
    {
        StartCoroutine(BackWait());
    }

    IEnumerator BackWait()
    {

        yield return new WaitForSeconds(0.75f);

        if (playerInfo.enabled == false)
        {
            playerInfo.enabled = true;
        }

        mainMenu.enabled = true;
    }

    public void OnStoreLightingDisable()
    {
        StoreRight.intensity = 0;
        StoreLeft.intensity = 0;
        StoreTop.intensity = 0;

        storeActive = false;
    }

    IEnumerator StoreLightingEnable()
    {
        yield return new WaitForSeconds(0.75f);

        StoreRight.intensity = 1.5f;

        yield return new WaitForSeconds(0.75f);

        StoreLeft.intensity = 1.5f;

        yield return new WaitForSeconds(0.75f);

        StoreTop.intensity = 2;

        yield return new WaitForSeconds(1f);

        storeActive = true;

    }

    public void OnOptionsLightingDisable()
    {
        OptionsLeft.intensity = 0;
        OptionsRight.intensity = 0;
        OptionsTop.intensity = 0;

        optionsActive = false;
    }

    IEnumerator OptionsLightingEnable()
    {
        yield return new WaitForSeconds(0.75f);

        OptionsLeft.intensity = 1.5f;

        OptionsRight.intensity = 1.5f;

        OptionsTop.intensity = 2;

        yield return new WaitForSeconds(1f);

        optionsActive = true;

    }
}
