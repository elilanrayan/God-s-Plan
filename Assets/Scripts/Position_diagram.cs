using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using NaughtyAttributes;

public class Position_diagram : MonoBehaviour
{
    public RectTransform _image;

    [Header("Variables pour postion le point")]
    [Range(-295f, 295f)]
    public float _positionX;
    [Range(-295f, 295f)]
    public float _positionY;


    private void Start()
    {
        GameManager gameManager = GameManager.Instance;

        if (gameManager != null)
        {
            // Utilise gameManager pour accéder aux méthodes et propriétés de GameManager
        }
        else
        {
            Debug.LogError("GameManager instance is not set.");
        }

        _image.anchoredPosition = new Vector2(0f,0f);
    }

    private void Update()
    {
        _image.anchoredPosition = new Vector2(GameManager.Instance.OPoint, GameManager.Instance.BPoint);
    }

    [Button]
    public void MoveUI()
    {
        _image.anchoredPosition = new Vector2(_positionX, _positionY);
    }

   
   
}
