using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using NaughtyAttributes;

public class Position_diagram : MonoBehaviour
{
    public RectTransform _image;

    public float _positionX;
    public float _positionY;


    private void Start()
    {
        _image.anchoredPosition = new Vector2(0f,0f);
    }

    [Button]
    public void MoveUI()
    {
        _image.anchoredPosition = new Vector2(_positionX, _positionY);
    }

   
   
}
