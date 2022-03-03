using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    private int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = Difficulty.difLvl;

        Debug.Log(difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
