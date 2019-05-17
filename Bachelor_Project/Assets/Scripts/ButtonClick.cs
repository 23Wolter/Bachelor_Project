using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public float maxDistance = 10f;
    public float smooth = 2f;
    public Transform target;
    public Transform defaultPos; 

    private WeightInput weight;
    private GameObject player;
    private bool clicking;
    private bool unclicking;
    private bool active; 

    private void Start()
    {
        weight = GetComponentInParent<WeightInput>();
        player = GameObject.Find("Player");
        clicking = false;
        unclicking = false;
        active = false; 
    }


    private void Update()
    {
        if(clicking)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, smooth * Time.deltaTime);
            
            if(transform.position.y < target.position.y + 0.02f)
            {
                clicking = false;
                unclicking = true; 
            }
        } else if(unclicking)
        {
            transform.position = Vector3.Lerp(transform.position, defaultPos.position, smooth * Time.deltaTime);

            if(transform.position.y > defaultPos.position.y - 0.002f)
            {
                unclicking = false; 
            }
        }
    }


    private void OnMouseOver()
    {
        if(active)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < maxDistance)
            {
                GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            }
        }
    }


    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }


    private void OnMouseDown()
    {
        if(active)
        {
            clicking = true; 
            weight.CheckInput(); 
        }
    }


    public void SetActivate(bool value)
    {
        active = value; 
    }

    public void ToggleActivate()
    {
        active = !active;  
    }
}
