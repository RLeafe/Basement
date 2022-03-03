using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuLightComp : MonoBehaviour
{
    public Light menuLight;

    private int chanceToFlicker, flickerIntensity;
    private float oldIntensity;
    public bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        menuLight.GetComponent<Light>();
        oldIntensity = menuLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted) return;

        chanceToFlicker = Random.Range(0, 1001);
        flickerIntensity = Random.Range(1, 4);

        OnLightFlicker();
    }

    public void OnGameStart()
    {
        gameStarted = true;

        StartCoroutine(GameStart());
    }

    void OnLightFlicker()
    {
        if(chanceToFlicker == 500)
        {
            StartCoroutine(lightFlicker());
        }
    }

    IEnumerator LoadLevel() 
    {
        yield return new WaitForSeconds(5.0f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1.5f);

        menuLight.enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;

        StartCoroutine(LoadLevel());
    }

    IEnumerator lightFlicker()
    {
        yield return new WaitForSeconds(2.5f);

        menuLight.intensity = menuLight.intensity / flickerIntensity;

        yield return new WaitForSeconds(0.2f);

        menuLight.intensity = oldIntensity;
    }

}
