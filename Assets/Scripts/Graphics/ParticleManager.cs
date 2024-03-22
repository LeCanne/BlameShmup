using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    public static ParticleManager m_Instance;

    private void Awake() => m_Instance = this;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ParticleSpawner(GameObject SpawnedObject, Collider2D position, int HowMuch)
    {

        StartCoroutine(particleSpawn(SpawnedObject, position, HowMuch));
    }

    IEnumerator particleSpawn(GameObject spawnedObject, Collider2D collider, int HowMuch)
    {
        float posY = 0;
        float posX = 0;
        Debug.Log("ye");

        for (int i = 0; i < HowMuch; i++)
        {
           
            posX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
            posY = Random.Range(collider.bounds.min.y, collider.bounds.max.y);

            Vector3 pos = new Vector3(posX, posY);

            Instantiate(spawnedObject, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
        }
            yield return null;
    }
}
