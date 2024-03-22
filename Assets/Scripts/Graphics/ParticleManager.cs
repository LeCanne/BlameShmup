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

    IEnumerator Discard(GameObject gameObject)
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        yield return null;  
    }

    IEnumerator particleSpawn(GameObject spawnedObject, Collider2D collider, int HowMuch)
    {
        float posY = 0;
        float posX = 0;
        Debug.Log("ye");

        for (int i = 0; i < HowMuch; i++)
        {
           
            posX = Random.Range(collider.bounds.min.x - 0.5f, collider.bounds.max.x + 0.5f);
            posY = Random.Range(collider.bounds.min.y - 0.5f, collider.bounds.max.y + 0.5f);

            Vector3 pos = new Vector3(posX, posY);

            GameObject spawned = Instantiate(spawnedObject, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
            StartCoroutine(Discard(spawned));
            yield return new WaitForSeconds(0.1f);
        }
        
            yield return null;
    }
}
