using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomDog : MonoBehaviour
{
    public Texture[] photos;

    private RawImage imageHolder;


    private void Start()
    {
        //Is only used so the script can be disabled
    }


    private void Awake()
    {
        imageHolder = GetComponentInChildren<RawImage>();
        int rand = (int) Mathf.Floor(Random.Range(0, 3));
        imageHolder.texture = photos[rand];

        int randAge = 0; 
        switch(rand)
        {
            case 0:
                randAge = (int) Mathf.Floor(Random.Range(2000, 2018));
                break;

            case 1: 
                randAge = (int) Mathf.Floor(Random.Range(2007, 2018));
                break;

            case 2: 
                randAge = (int) Mathf.Floor(Random.Range(2010, 2018));
                break;

            case 3: 
                randAge = (int) Mathf.Floor(Random.Range(2012, 2018));
                break;
        }
        GameObject.Find("Age").GetComponent<Text>().text = "" + randAge; 
    }

}
