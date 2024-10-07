using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoicesDisplay : MonoBehaviour
{

    [SerializeField]private Choices Firstspecies;
    [SerializeField] private Choices Secondspecies;

    [SerializeField] private TextMeshProUGUI nameText1;
    [SerializeField] private TextMeshProUGUI ordrePoint1;
    [SerializeField] private TextMeshProUGUI benevolantPoint1;

    [SerializeField] private Image spriteSpecies1;

    [SerializeField] private TextMeshProUGUI nameText2;
    [SerializeField] private TextMeshProUGUI ordrePoint2;
    [SerializeField] private TextMeshProUGUI benevolantPoint2;

    [SerializeField] private Image spriteSpecies2;


    void Start()
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
