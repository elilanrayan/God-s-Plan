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
        //foreach(element in list){
        //  text.text += element.recap;
        //
        //}

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
