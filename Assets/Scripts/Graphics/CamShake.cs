using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public float duration;
    public float magnitude;
    public GameObject parent;
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector2 originalPos = new Vector2(0,0);
        float elapsedTime = 0f;


        while (elapsedTime < duration)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.localPosition = new Vector2(xOffset, yOffset);
            
            elapsedTime += Time.deltaTime;
            yield return null;

        }

        gameObject.transform.position = parent.transform.position;
        

    }
}
