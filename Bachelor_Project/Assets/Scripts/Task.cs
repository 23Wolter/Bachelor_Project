using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    [SerializeField] private RawImage check_no;
    [SerializeField] private RawImage check_yes; 

    private void OnMouseDown()
    {
        Color no_color = check_no.color;
        no_color.a = 0.0f;
        check_no.color = no_color;

        Color yes_color = check_yes.color;
        yes_color.a = 1.0f;
        check_yes.color = yes_color;
    }
}
