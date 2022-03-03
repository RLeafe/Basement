using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitchLight : MonoBehaviour
{
    public MenuLightComp menuLight;
    public Light switchLight;
    public float t = 0.0f;

    private float waitForRed = 2.5f;
    private float maxInt = 1.0f, minInt = 0.0f;

    // Start is called before the first frame update
    void Start() 
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (!menuLight.gameStarted)
        {
            switchLight.intensity = Mathf.Lerp(minInt, maxInt, t);

            t += 0.5f * Time.deltaTime;

            if (t > 1.0f)
            {
                float temp = maxInt;
                maxInt = minInt;
                minInt = temp;
                t = 0.0f;
            }
        }
        else if (menuLight.gameStarted && switchLight.enabled && waitForRed >= 0)
        {
            StartCoroutine(GameStart());
        }

        GameStartCheck();

    }

    IEnumerator GameStart() 
    {

        yield return new WaitForSeconds(1.95f);

        switchLight.enabled = false;

        switchLight.intensity = 0.5f;
        t = 0.5f;

        switchLight.color = Color.red;

        yield return new WaitForSeconds(waitForRed);

        waitForRed--;

        switchLight.enabled = true;

        switchLight.color = Color.red;
    }

    private void GameStartCheck()
    {
        if (switchLight.enabled && waitForRed <= 0)
        {
            switchLight.intensity = Mathf.Lerp(minInt, maxInt, t);

            t += 0.5f * Time.deltaTime;

            if (t > 1.0f)
            {
                float temp = maxInt;
                maxInt = minInt;
                minInt = temp;
                t = 0.0f;
            }
        }
    }

}
