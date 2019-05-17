using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockButton : MonoBehaviour
{
    public LockText lockText;
    public string buttonFunction; 

    public float maxDistance = 10f;
    public float smooth = 2f;
    public Transform target;
    public Transform defaultPos;

    private GameObject player;
    private bool clicking;
    private bool unclicking;
    private bool active;

    private void Start()
    {
        player = GameObject.Find("Player");
        clicking = false;
        unclicking = false;
        active = false;
    }


    private void Update()
    {
        if (clicking)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, smooth * Time.deltaTime);
            if (transform.position.x > target.position.x - 0.02f)
            {
                clicking = false;
                unclicking = true;
            }
        }
        else if (unclicking)
        {
            transform.position = Vector3.Lerp(transform.position, defaultPos.position, smooth * Time.deltaTime);

            if (transform.position.x < defaultPos.position.x + 0.02f)
            {
                unclicking = false;
            }
        }
    }


    private void OnMouseOver()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < maxDistance)
        {
            GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
        
    }


    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }


    private void OnMouseDown()
    {
        clicking = true;

        if (buttonFunction == "+") lockText.IncreaseOutput();
        else if (buttonFunction == "-") lockText.DecreaseOutput(); 
    }


    public void ToggleActivate()
    {
        active = !active;
    }
}
