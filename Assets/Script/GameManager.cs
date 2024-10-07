using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    private ChoicesDisplay choicesDisplay;
    [SerializeField] private Button species1;
    [SerializeField] private Button species2;

    private List<Choices> finalSpecies;

    private int laps = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (choicesDisplay == null)
        {
            choicesDisplay = FindObjectOfType<ChoicesDisplay>();
        }
    }

    void Update()
    {
        if(laps >= 15)
        {
            //Active ecran fin
        }
    }

    public void MancheSuivante1()
    {
        // Enlever les espèces affichées précédemment par indice
        int indexFirst = choicesDisplay.Species.IndexOf(choicesDisplay.Firstspecies);
        int indexSecond = choicesDisplay.Species.IndexOf(choicesDisplay.Secondspecies);
        finalSpecies.Add(choicesDisplay.Firstspecies);

        if (indexFirst > indexSecond)
        {
            choicesDisplay.Species.RemoveAt(indexFirst);
            choicesDisplay.Species.RemoveAt(indexSecond);
        }
        else
        {
            choicesDisplay.Species.RemoveAt(indexSecond);
            choicesDisplay.Species.RemoveAt(indexFirst);
        }

        choicesDisplay.Firstspecies = choicesDisplay.Species[4];
        choicesDisplay.Secondspecies = choicesDisplay.Species[5];
        choicesDisplay.UpdateDisplay();
        laps += 1;
    }
    
    public void MancheSuivante2()
    {
        // Enlever les espèces affichées précédemment par indice
        int indexFirst = choicesDisplay.Species.IndexOf(choicesDisplay.Firstspecies);
        int indexSecond = choicesDisplay.Species.IndexOf(choicesDisplay.Secondspecies);
        finalSpecies.Add(choicesDisplay.Secondspecies);

        if (indexFirst > indexSecond)
        {
            choicesDisplay.Species.RemoveAt(indexFirst);
            choicesDisplay.Species.RemoveAt(indexSecond);
        }
        else
        {
            choicesDisplay.Species.RemoveAt(indexSecond);
            choicesDisplay.Species.RemoveAt(indexFirst);
        }

        choicesDisplay.Firstspecies = choicesDisplay.Species[4];
        choicesDisplay.Secondspecies = choicesDisplay.Species[5];
        choicesDisplay.UpdateDisplay();
        laps += 1;
    }

}
