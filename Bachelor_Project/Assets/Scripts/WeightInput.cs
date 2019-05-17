using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightInput : MonoBehaviour
{
    public int correctInput;
    public TaskHandler taskHandler;
    public LockButtonCheck lockButton; 

    private Text text; 
    private string output;


    private void Start()
    {
        text = GetComponentInChildren<Text>();
        output = "0"; 
        text.text = output; 
    }


    public void AddToInput(int addition)
    {
        text.color = Color.white; 
        int input = int.Parse(output);
        input += addition;
        output = "" + input;
        text.text = output; 
    }


    public void SubFromInput(int subtract)
    {
        text.color = Color.white; 
        int input = int.Parse(output);
        input -= subtract;
        output = "" + input;
        text.text = output; 
    }


    public void CheckInput()
    {
        int input = int.Parse(output); 

        if(input == correctInput)
        {
            text.color = Color.green; 
            taskHandler.CheckOffTask(0);
            lockButton.ToggleActivate(); 
        } else
        {
            text.color = Color.red; 
        }
    }
}
