using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public  GameObject[] fruits;
    public GameObject bomb;
    public float maxX;
    private int randomIndex;

    private void Start()
    {
        Invoke("StartSpawning", 1f);
    }
    public void StartSpawning()
    {
        //every 6 seconds later , call this function, 1 time.
        InvokeRepeating("SpawnFruitGroups", 1, 6f);
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnFruitGroups");
        StopCoroutine("SpawnFruit");
        StopCoroutine("SpawnBomb");
    }
    public void SpawnFruitGroups()
    {
        StartCoroutine("SpawnFruit");

        if(Random.Range(0,6) > 2)
        {
            SpawnBomb();
        }
    }


    IEnumerator SpawnFruit()
    {
        for(int i = 0;i< 5; i++)
        {
            randomIndex = Random.Range(0, 3);
            float rand = Random.Range(-maxX, maxX);
            Vector3 pos = new Vector3(rand, transform.position.y, 0);
            GameObject f = Instantiate(fruits[randomIndex], pos, Quaternion.identity) as GameObject;
            f.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 14f), ForceMode2D.Impulse);
            f.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-15f,15f));
            yield return new WaitForSeconds(0.5f);
        }
       
    }

    public void SpawnBomb()
    {
      
        float rand = Random.Range(-maxX, maxX);
        Vector3 pos = new Vector3(rand, transform.position.y, 0);
        GameObject f = Instantiate(bomb, pos, Quaternion.identity) as GameObject;
        f.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 14f), ForceMode2D.Impulse);
        f.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-30f, 30f));
    }
    
}
