using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockText : MonoBehaviour
{
    public string inputType;

    private Text text;
    private string[] outputs;
    private int index; 


    void Start()
    {
        text = GetComponent<Text>();
        index = 0; 

        if(inputType == "numbers")
        {
            outputs = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }; 
        } else if(inputType == "letters")
        {
            outputs = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z"};
        }
    }

    
    public void IncreaseOutput()
    {
        index++;
        if (index == outputs.Length) index = 0; 
        text.text = outputs[index]; 
    }



    public void DecreaseOutput()
    {
        index--;
        if (index < 0) index = outputs.Length-1; 
        text.text = outputs[index]; 
    }
}
