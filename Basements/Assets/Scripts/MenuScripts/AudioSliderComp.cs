using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioSliderComp : MonoBehaviour
{
    public AudioSource audioClip;
    public float volumeStart = 0.5f;
    public bool playOnStart = true;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        audioClip = GetComponent<AudioSource>();
        audioClip.loop = true;
        audioClip.volume = volumeStart;
        if (playOnStart)
        {
            audioClip.Play(0);
        }

        slider.value = volumeStart;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateVolume();
    }

    void CalculateVolume()
    {
        audioClip.volume = slider.value;
    }
}
