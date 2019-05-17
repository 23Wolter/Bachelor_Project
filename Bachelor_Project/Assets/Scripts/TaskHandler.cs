using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskHandler : MonoBehaviour
{
    public RawImage[] taskCheckoff_no; 
    public RawImage[] taskCheckoff_yes;
    public RawImage[] bigTaskCheckoff_no;
    public RawImage[] bigTaskCheckoff_yes;
    public Text[] passcodes; 

    public void CheckOffTask(int taskIndex)
    {
        //for the to do list on the wall
        //mark task as done 
        Color c1 = taskCheckoff_no[taskIndex].color;
        c1.a = 0f;
        taskCheckoff_no[taskIndex].color = c1;

        Color c2 = taskCheckoff_yes[taskIndex].color;
        c2.a = 255f;
        taskCheckoff_yes[taskIndex].color = c2;


        //for the to do list on the camera canvas
        //mark task as done 
        Color bc1 = bigTaskCheckoff_no[taskIndex].color;
        bc1.a = 0f;
        bigTaskCheckoff_no[taskIndex].color = bc1;

        Color bc2 = bigTaskCheckoff_yes[taskIndex].color;
        bc2.a = 255f;
        bigTaskCheckoff_yes[taskIndex].color = bc2;


        //set passcode for the specific task
        passcodes[taskIndex].text = "BD"; 
    }
}
