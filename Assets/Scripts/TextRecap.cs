using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextRecap : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject position_diagramm;
    // Start is called before the first frame update
    void Start()
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


        foreach (var element in GameManager.Instance.finalSpecies)
        {
            if (element.HasPhraseRecap)
            {
                text.text = text.text + "\n" + element.phraseRecap ;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
            position_diagramm.SetActive(true);

        }
    }

}
