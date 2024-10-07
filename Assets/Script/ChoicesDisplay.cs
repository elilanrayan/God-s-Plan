using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoicesDisplay : MonoBehaviour
{
    [SerializeField] public Choices Firstspecies;
    [SerializeField] public Choices Secondspecies;

    [Header("Première Espece")]
    [SerializeField] private TextMeshProUGUI nameText1;
    [SerializeField] private TextMeshProUGUI ordrePoint1;
    [SerializeField] private TextMeshProUGUI benevolantPoint1;
    [SerializeField] private Image spriteSpecies1;

    [Header("Deuxième Espece")]
    [SerializeField] private TextMeshProUGUI nameText2;
    [SerializeField] private TextMeshProUGUI ordrePoint2;
    [SerializeField] private TextMeshProUGUI benevolantPoint2;
    [SerializeField] private Image spriteSpecies2;

    [Header("Liste")]
    [SerializeField] public List<Choices> Species;

    void Start()
    {
    }

    public void UpdateDisplay()
    {
        nameText1.text = Firstspecies.nameObject;
        ordrePoint1.text = Firstspecies.effetOrdre.ToString();
        benevolantPoint1.text = Firstspecies.effetBenevolant.ToString();
        spriteSpecies1.sprite = Firstspecies.assetImage;

        nameText2.text = Secondspecies.nameObject;
        ordrePoint2.text = Secondspecies.effetOrdre.ToString();
        benevolantPoint2.text = Secondspecies.effetBenevolant.ToString();
        spriteSpecies2.sprite = Secondspecies.assetImage;
    }
}
