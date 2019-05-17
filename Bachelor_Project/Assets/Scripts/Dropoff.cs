using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropoff : MonoBehaviour
{
    public Material activeMaterial;
    public Material almostActivatedMaterial; 
    public Material nonActiveMaterial;
    public Renderer button;

    private ButtonClick buttonClick;
    private List<GameObject> objectsEntered;
    private bool bowlFound;


    private void Start()
    {
        buttonClick = button.gameObject.GetComponent<ButtonClick>();
        objectsEntered = new List<GameObject>(); 
        bowlFound = false; 
    }


    private void OnTriggerEnter(Collider other)
    {
        objectsEntered.Add(other.gameObject);

        foreach(GameObject go in objectsEntered)
        {
            if(go.tag == "DogBowl")
            {
                button.material = almostActivatedMaterial;
                bowlFound = true; 
            }

            if(go.tag == "DogFood" && bowlFound)
            {
                button.material = activeMaterial;
                buttonClick.SetActivate(true);  
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        objectsEntered.Remove(other.gameObject); 

        if(other.gameObject.tag == "DogBowl")
        {
            button.material = nonActiveMaterial;
            buttonClick.SetActivate(false);
            bowlFound = false; 
        }

        if(other.gameObject.tag == "DogFood" && bowlFound)
        {
            button.material = almostActivatedMaterial; 
            buttonClick.SetActivate(false);
        } else if(other.gameObject.tag == "DogFood")
        {
            button.material = nonActiveMaterial; 
            buttonClick.SetActivate(false);
        }
    }
}
