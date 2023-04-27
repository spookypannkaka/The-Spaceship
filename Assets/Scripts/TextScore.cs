using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScore : MonoBehaviour
{
    public TMP_Text hitsText;

    // Start is called before the first frame update
    void Start()
    {
        hitsText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        hitsText.text = "Antal nuddar: " + Score.numberOfHits.ToString();
    }
}
