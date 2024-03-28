using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoretext;
    public TMP_Text MultiTxt;
    void Start()
    {
        
    }

   
    void Update()
    {
        scoretext.text = ScoreManager.Score.ToString("0000000");
        MultiTxt.text = ScoreManager.Multiplier.ToString("x.0");
    }
}
