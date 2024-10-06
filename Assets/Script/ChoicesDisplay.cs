using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoicesDisplay : MonoBehaviour
{

    public Choices species;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI ordrePoint;
    public TextMeshProUGUI benevolantPoint;

    public Image spriteSpecies;

    void Start()
    {
        nameText.text = species.nameObject;

        ordrePoint.text = species.effetOrdre.ToString();
        benevolantPoint.text = species.effetBenevolant.ToString();

        spriteSpecies.sprite = species.assetImage;
    }


}
