using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;

    private CharacterController charController;
    private bool isHoldingItem;
    private bool disabled; 

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        disabled = false; 
    }


    private void Start()
    {
        isHoldingItem = false; 
    }

    private void Update()
    {
        if(!disabled)
        {
            PlayerMovement();
        }
    }

    private void PlayerMovement()
    {
        float verInput = Input.GetAxis(verticalInputName) * movementSpeed;
        float horInput = Input.GetAxis(horizontalInputName) * movementSpeed; 

        Vector3 forwardMovement = transform.forward * verInput;
        Vector3 rightMovement = transform.right * horInput;

        charController.SimpleMove(forwardMovement + rightMovement); 
    }


    public void HoldItem()
    {
        isHoldingItem = true; 
    }

    public void ReleaseItem()
    {
        isHoldingItem = false; 
    }


    public bool IsHoldingItem()
    {
        return isHoldingItem; 
    }


    public void FlipDisabled()
    {
        disabled = !disabled; 
    }
}
