using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public GameObject player; 
    public float maxDistance = 5f;
    public float pickedupDistance = 10f; 
    public Transform playercam;
    public PlayerHandsScript playerHands;

    private bool pickedUp;
    private PlayerMove playerScript;
    private Rigidbody rb;


    private void Start()
    {
        playerScript = player.GetComponent<PlayerMove>();
        pickedUp = false;
        rb = GetComponent<Rigidbody>();
    }



    private void OnMouseOver()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < maxDistance)
        {
            GetComponentInChildren<Renderer>().material.EnableKeyword("_EMISSION");
        }
    }


    private void OnMouseExit()
    {
            GetComponentInChildren<Renderer>().material.DisableKeyword("_EMISSION"); 
    }


    private void OnMouseDown()
    {
        if(!pickedUp && !playerScript.IsHoldingItem())
        {
            if(Vector3.Distance(player.transform.position, transform.position) < maxDistance)
            {
                rb.useGravity = false; 
                pickedUp = true;
                playerHands.HoldItem(rb); 
                playerScript.HoldItem(); 
            }
        } else if(pickedUp)
        {
            rb.useGravity = true;
            pickedUp = false;
            playerHands.ThrowItem(rb); 
            playerScript.ReleaseItem();
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        rb.useGravity = true;
        pickedUp = false;
        playerHands.ReleaseItem(); 
        playerScript.ReleaseItem();
    }
}
