using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKitchenDoor : MonoBehaviour
{
    public float smooth = 2f;
    public string doorSide;
    public Transform player;
    public float maxDistance = 10f;

    private bool rotate = false;
    private bool open = false;
    private bool activate = false; 

    private void Update()
    {
        if (rotate)
        {
            if (doorSide == "left")
            {
                if (!open)
                {
                    Quaternion targetRotation = Quaternion.Euler(transform.localRotation.x, 90f, transform.localRotation.z);
                    transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);

                    if (targetRotation.y < transform.localRotation.y + 0.01f)
                    {
                        rotate = false;
                        open = true;
                    }
                }
                else
                {
                    Quaternion targetRotation = Quaternion.Euler(transform.localRotation.x, 0f, transform.localRotation.z);
                    transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);

                    if (targetRotation.y > transform.localRotation.y - 0.01f)
                    {
                        rotate = false;
                        open = false;
                    }
                }
            }
            else if (doorSide == "right")
            {
                if (!open)
                {
                    Quaternion targetRotation = Quaternion.Euler(transform.localRotation.x, -90f, transform.localRotation.z);
                    transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);

                    if (targetRotation.y > transform.localRotation.y - 0.01f)
                    {
                        rotate = false;
                        open = true;
                    }
                }
                else
                {
                    Quaternion targetRotation = Quaternion.Euler(transform.localRotation.x, 0f, transform.localRotation.z);
                    transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);

                    if (targetRotation.y < transform.localRotation.y + 0.01f)
                    {
                        rotate = false;
                        open = false;
                    }
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(player.position, transform.position) < maxDistance && activate)
        {
            rotate = true;
        }
    }

    public void Activate()
    {
        activate = true; 
    }
}
