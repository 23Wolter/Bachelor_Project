using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockButtonCheck : MonoBehaviour
{
    public string[] passcode; 
    public Text[] lockTexts;
    public Material activatedMaterial;
    public GameObject Lock; 

    public float maxDistance = 10f;
    public float smooth = 2f;
    public Transform target;
    public Transform defaultPos;
    public OpenKitchenDoor frenchDoor; 

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

            if(lockTexts[0].text == passcode[0] && lockTexts[1].text == passcode[1] && lockTexts[2].text == passcode[2] && lockTexts[3].text == passcode[3])
            {
                if(!Lock.GetComponent<Rigidbody>())
                {
                    Lock.AddComponent<Rigidbody>();
                    frenchDoor.Activate(); 
                }
            }
        }
    }


    public void ToggleActivate()
    {
        active = !active;
        GetComponent<Renderer>().material = activatedMaterial; 
    }
}
