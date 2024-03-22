using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoretext;
    void Start()
    {
        
    }

   
    void Update()
    {
        scoretext.text = ScoreManager.Score.ToString("0000000");
    }
}
