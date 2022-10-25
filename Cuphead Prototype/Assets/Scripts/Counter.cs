using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public static int rubbish = 0;

  public TMP_Text rubbishCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Displays the current counter to the screen
        rubbishCount.text = "Rubbish: " + rubbish;
    }
}
