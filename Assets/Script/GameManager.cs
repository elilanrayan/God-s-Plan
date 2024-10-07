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

    public List<Choices> finalSpecies;

    [SerializeField] public Animator animatorRH;
    [SerializeField] public Animator animatorLH;



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
        if(laps >= 5)
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
        animatorLH.SetTrigger("Throw");
        animatorRH.SetTrigger("Crush");

        choicesDisplay.Firstspecies = choicesDisplay.Species[UnityEngine.Random.Range(0, choicesDisplay.Species.Count)];
        choicesDisplay.Secondspecies = choicesDisplay.Species[UnityEngine.Random.Range(0, choicesDisplay.Species.Count)];

        if(choicesDisplay.Species.Count >= 1)
        {
            while (choicesDisplay.Secondspecies == choicesDisplay.Firstspecies)
            {
                choicesDisplay.Secondspecies = choicesDisplay.Species[UnityEngine.Random.Range(0, choicesDisplay.Species.Count)];
            }
        }


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
        animatorLH.SetTrigger("Crush");
        animatorRH.SetTrigger("Throw");

        choicesDisplay.Firstspecies = choicesDisplay.Species[UnityEngine.Random.Range(0, choicesDisplay.Species.Count)];
        choicesDisplay.Secondspecies = choicesDisplay.Species[UnityEngine.Random.Range(0, choicesDisplay.Species.Count)];

        if (choicesDisplay.Species.Count >= 1)
        {
            while (choicesDisplay.Secondspecies == choicesDisplay.Firstspecies)
            {
                choicesDisplay.Secondspecies = choicesDisplay.Species[UnityEngine.Random.Range(0, choicesDisplay.Species.Count)];
            }
        }

        choicesDisplay.UpdateDisplay();
        laps += 1;
    }

}
