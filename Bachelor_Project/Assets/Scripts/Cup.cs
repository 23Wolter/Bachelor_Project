using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public int amount;
    public float maxDistance;
    public Material defaultMaterial; 
    public Material activatedMaterial; 

    private WeightInput weight;
    private GameObject player;
    private Renderer renderer; 
    private bool activated;


    private void Start()
    {
        weight = GameObject.Find("Weight").GetComponent<WeightInput>();
        player = GameObject.Find("Player");
        renderer = GetComponent<Renderer>();
        activated = false; 
    }


    private void OnMouseOver()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < maxDistance)
        {
            renderer.material.EnableKeyword("_EMISSION");
        }
    }


    private void OnMouseExit()
    {
        renderer.material.DisableKeyword("_EMISSION");
    }



    private void OnMouseDown()
    {
        if(!activated)
        {
            weight.AddToInput(amount);
            renderer.material = activatedMaterial; 
        } else
        {
            weight.SubFromInput(amount);
            renderer.material = defaultMaterial; 
        }
        activated = !activated; 
    }
}
