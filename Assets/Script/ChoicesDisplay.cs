using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicesDisplay : MonoBehaviour
{

    public Choices species;

    public Text nameText;
    public Text ordrePoint;
    public Text benevolantPoint;

    public Image spriteSpecies;

    void Start()
    {
        nameText.text = species.nameObject;

        ordrePoint.text = species.effetOrdre.ToString();
        benevolantPoint.text = species.effetBenevolant.ToString();

        spriteSpecies.sprite = species.assetImage;
    }


}
