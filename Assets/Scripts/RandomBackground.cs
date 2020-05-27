using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBackground : MonoBehaviour
{
    public Sprite[] backgrounds; 

    private Image chosen; 

    // Use this for initialization
    void Start()
    {
        chosen = GetComponent<Image>();
        Sprite randomBG = backgrounds[Random.Range(0, backgrounds.Length)];
        chosen.sprite = randomBG;
    }
    // Update is called once per frame
    void Update()
    {

    }

}