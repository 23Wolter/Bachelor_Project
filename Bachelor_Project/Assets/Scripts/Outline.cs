using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    public GameObject outline;
    public GameObject toDoListBig;

    private PlayerLook playerLook;
    private PlayerMove playerMove; 

    private void Start()
    {
        playerLook = GameObject.Find("PlayerCamera").GetComponent<PlayerLook>();
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>(); 
    }

    private void OnMouseEnter()
    {
        outline.SetActive(true); 
    }


    private void OnMouseExit()
    {
        outline.SetActive(false); 
    }


    private void OnMouseDown()
    {
        bool disabled = playerLook.FlipDisabled();
        playerMove.FlipDisabled(); 
        toDoListBig.SetActive(disabled); 
    }
}
