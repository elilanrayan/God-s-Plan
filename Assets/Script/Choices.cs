using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New species", menuName = "Species")]
public class Choices : ScriptableObject
{

    public string nameObject;
    public int effetOrdre;
    public int effetBenevolant;
    public string tooltip;
    public bool HasTooltip;
    public Sprite assetImage;

}
