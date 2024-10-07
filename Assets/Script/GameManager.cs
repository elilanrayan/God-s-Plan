using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private ChoicesDisplay choicesDisplay;
    [SerializeField] private Button species1;
    [SerializeField] private Button species2;

    void Start()
    {
        if (choicesDisplay == null)
        {
            choicesDisplay = FindObjectOfType<ChoicesDisplay>();
        }
    }

    void Update()
    {
        
    }

    public void MancheSuivante()
    {
        choicesDisplay.Firstspecies = choicesDisplay.Species[2];
        choicesDisplay.Secondspecies = choicesDisplay.Species[3];
        choicesDisplay.UpdateDisplay();
    }

}
