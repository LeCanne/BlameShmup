using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int Score;
    public float maxScore;
    public float timer;
    public GameObject scoreTxt;
    private Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = Vector3.zero;
        originalScale += scoreTxt.transform.localScale;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if(Score > maxScore)
        {
            maxScore = Score;
            
            if(scoreTxt.transform.localScale.magnitude < new Vector3(2,2,2).magnitude)
            scoreTxt.transform.localScale += new Vector3(0.2f,0.2f,0.2f);
           
            timer = 0;
            
            
        }

        if(timer > 1)
        {
            scoreTxt.transform.localScale = Vector3.Lerp(scoreTxt.transform.localScale, originalScale, 3 * Time.deltaTime);
        }
    }
}
