using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipAnimation : MonoBehaviour
{
    private Animator m_Animator;
    
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            m_Animator.Play("PopUpIn");
           
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
             
        }
    }
}
