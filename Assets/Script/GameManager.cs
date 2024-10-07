using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    [SerializeField] private int laps = 0;
    private ChoicesDisplay choicesDisplay;
    [SerializeField] private Button species1;
    [SerializeField] private Button species2;

    public List<Choices> finalSpecies;
    public float OPoint;
    public float BPoint;

    [SerializeField] public Animator animatorRH;
    [SerializeField] public Animator animatorLH;
    [SerializeField] public Animator animatorLImage;
    [SerializeField] public Animator animatorRImage;

    [Header("Tooltip")]
    [SerializeField] public Animator animatorTooltip;
    [SerializeField] private TextMeshProUGUI tooltipText;
    [SerializeField] private Choices tooltipSpecies;
    [SerializeField] private bool CanDisplay;





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

        AudioManager audiomanager = AudioManager.Instance;

        if (audiomanager != null)
        {
            // Utilise gameManager pour accéder aux méthodes et propriétés de GameManager
        }
        else
        {
            Debug.LogError("GameManager instance is not set.");
        }


        if (choicesDisplay == null)
        {
            choicesDisplay = FindObjectOfType<ChoicesDisplay>();
        }


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

    }

    void Update()
    {
        if(laps >= 13)
        {
            AudioManager.Instance.PlaySFX("Bell");
            StartCoroutine(WaitAndDisplayEndPanel());
        }
    }

    public void MancheSuivante1()
    {
        // Enlever les espèces affichées précédemment par indice
        int indexFirst = choicesDisplay.Species.IndexOf(choicesDisplay.Firstspecies);
        int indexSecond = choicesDisplay.Species.IndexOf(choicesDisplay.Secondspecies);
        finalSpecies.Add(choicesDisplay.Firstspecies);
        BPoint = BPoint  + choicesDisplay.Firstspecies.effetBenevolant;
        OPoint = OPoint + choicesDisplay.Firstspecies.effetOrdre;

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
        animatorLImage.SetTrigger("LeftThrow");
        animatorRH.SetTrigger("Crush");
        animatorRImage.SetTrigger("Crush");
        AudioManager.Instance.PlaySFX("Throw");
        AudioManager.Instance.PlaySFX("Crush");

        tooltipSpecies = choicesDisplay.Firstspecies;
        if (choicesDisplay.Firstspecies.HasTooltip)
        {
            tooltipText.text = choicesDisplay.Firstspecies.tooltip;
            CanDisplay = true;
        }
      

        if (choicesDisplay.Species.Count > 1)
        {
            choicesDisplay.Firstspecies = choicesDisplay.Species[UnityEngine.Random.Range(0, choicesDisplay.Species.Count)];
            choicesDisplay.Secondspecies = choicesDisplay.Species[UnityEngine.Random.Range(0, choicesDisplay.Species.Count)];

            while (choicesDisplay.Secondspecies == choicesDisplay.Firstspecies)
            {
                choicesDisplay.Secondspecies = choicesDisplay.Species[UnityEngine.Random.Range(0, choicesDisplay.Species.Count)];
            }
        }
        else
        {
            Debug.Log("I don't have any Species in my data");
        }


        StartCoroutine(WaitAndUpdateDisplay());
        animatorRImage.SetTrigger("NewSpecies");
        animatorLImage.SetTrigger("NewSpecies");
        laps += 1;

    }
    
    public void MancheSuivante2()
    {
        // Enlever les espèces affichées précédemment par indice
        int indexFirst = choicesDisplay.Species.IndexOf(choicesDisplay.Firstspecies);
        int indexSecond = choicesDisplay.Species.IndexOf(choicesDisplay.Secondspecies);
        finalSpecies.Add(choicesDisplay.Secondspecies);
        BPoint = BPoint + choicesDisplay.Secondspecies.effetBenevolant;
        OPoint = OPoint + choicesDisplay.Secondspecies.effetOrdre;

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
        animatorLImage.SetTrigger("LeftCrush");
        animatorRH.SetTrigger("Throw");
        animatorRImage.SetTrigger("Throw");
        AudioManager.Instance.PlaySFX("Throw");
        AudioManager.Instance.PlaySFX("Crush");

        tooltipSpecies = choicesDisplay.Secondspecies;
        if (tooltipSpecies.HasTooltip)
        {
            tooltipText.text = tooltipSpecies.tooltip;
            CanDisplay = true;
        }

        if (choicesDisplay.Species.Count >= 1)
        {

            choicesDisplay.Firstspecies = choicesDisplay.Species[UnityEngine.Random.Range(0, choicesDisplay.Species.Count)];
            choicesDisplay.Secondspecies = choicesDisplay.Species[UnityEngine.Random.Range(0, choicesDisplay.Species.Count)];

            while (choicesDisplay.Secondspecies == choicesDisplay.Firstspecies)
            {
                choicesDisplay.Secondspecies = choicesDisplay.Species[UnityEngine.Random.Range(0, choicesDisplay.Species.Count)];
            }
        }
        else
        {
            Debug.Log("I don't have any Species in my data");
        }

        StartCoroutine(WaitAndUpdateDisplay());
        animatorRImage.SetTrigger("NewSpecies");
        animatorLImage.SetTrigger("NewSpecies");
        laps += 1;
    }

    private IEnumerator WaitAndUpdateDisplay()
    {
        yield return new WaitForSeconds(2);
        if (CanDisplay)
        {
            animatorTooltip.SetTrigger("ActiveTooltip");
            CanDisplay = false;
        }
        choicesDisplay.UpdateDisplay();
    }
    
    private IEnumerator WaitAndDisplayEndPanel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SampleScene");
    }

}
