using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandsScript : MonoBehaviour
{
    public Rigidbody emptyHands;
    public float throwForce;

    private FixedJoint playerHands;


    private void Start()
    {
        playerHands = GetComponent<FixedJoint>(); 
    }



    public void HoldItem(Rigidbody item)
    {
        if(GetComponent<FixedJoint>())
        {
            playerHands.connectedBody = item;
        } else
        {
            playerHands = gameObject.AddComponent<FixedJoint>();
            playerHands.connectedBody = item; 
        }
    }


    public void ReleaseItem()
    {
        if(playerHands)
        {
            playerHands.connectedBody = emptyHands; 
        }
    }


    public void ThrowItem(Rigidbody item)
    {
        Vector3 force = item.gameObject.transform.position - transform.position;
        item.AddForce(force * throwForce);

        ReleaseItem(); 
    }
}
