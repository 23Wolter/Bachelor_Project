using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    private MeshRenderer m_Renderer;
    private Color m_OriginalColor;
    private bool activated;

    private void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        m_OriginalColor = m_Renderer.material.color;
        activated = false; 
    }

    private void OnMouseOver()
    {
        if(!activated) m_Renderer.material.color = Color.red; 
    }

    private void OnMouseExit()
    {
        if(!activated) m_Renderer.material.color = m_OriginalColor; 
    }

    private void OnMouseDown()
    {
        m_Renderer.material.color = Color.blue;
        activated = true; 
    }
}
