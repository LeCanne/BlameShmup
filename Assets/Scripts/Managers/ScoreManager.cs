using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int Score;
    public static int Multiplier;
    public int lifeTreshold = 5000;
    public float maxScore;
    public float timer;
    public float timerMulti;
    public bool done = true;

    public float multi;

    public PlayerMovement playermov;
    public GameObject scoreTxt;
    public GameObject multiplier;
    public Vector3 originalScale;
    public Vector3 originalScale2;
    public Vector3 newScale;
    public Vector3 newScale2;
    public Vector3 maxScale;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = Vector3.zero;
        originalScale += scoreTxt.transform.localScale;
        originalScale2 += multiplier.transform.localScale;
        timer = 2;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        timerMulti += Time.deltaTime;
        if(timerMulti > 0)
        {
            Multiplier = 1;
            multiplier.transform.localScale = Vector3.Lerp(multiplier.transform.localScale, originalScale2, 20 * Time.deltaTime);
        }
        if(Score > maxScore)
        {

            Debug.Log(maxScore);
            
            timerMulti = -3;
            if (Multiplier < 5)
            {
                Multiplier += 1;
                newScale2 = multiplier.transform.localScale;
                multiplier.transform.localScale += new Vector3(1f, 1f, 1f);
            }
            maxScore = Score;
            

            if (scoreTxt.transform.localScale.magnitude < maxScale.magnitude)
            {
                newScale = scoreTxt.transform.localScale;
               
                scoreTxt.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                
                

                done = false;
            }
          
           
            timer = 0;
            
            
        }
        if(done == false)
        {
            if(timer < 0.3f)
            {
                scoreTxt.transform.localScale = Vector3.Lerp(scoreTxt.transform.localScale, newScale - new Vector3(0.02f,0.02f), 3 * Time.deltaTime);
                multiplier.transform.localScale = Vector3.Lerp(multiplier.transform.localScale, newScale2 - new Vector3(0.02f, 0.02f), 3 * Time.deltaTime);
            }
            else
            {
                done = true;
            }
            
        }
        

        if(timer > 1)
        {
            scoreTxt.transform.localScale = Vector3.Lerp(scoreTxt.transform.localScale, originalScale, 3 * Time.deltaTime);
        }

        if(Score > lifeTreshold)
        {
            playermov.PlayerHealth += 1;
            lifeTreshold += 5000;

        }
    }
}
