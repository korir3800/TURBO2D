using System.Collections;
using UnityEngine;

public class Coin_Spawner : MonoBehaviour
{

    public GameObject Coinprefab; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CoinSpawner());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CoinSpawn()
    {
        float rand = Random.Range(-1.8f, 1.8f);
        Instantiate(Coinprefab, new Vector3(rand,transform.position.y,transform.position.z),Quaternion.identity);
    }

    IEnumerator CoinSpawner()
    {
        while (true)
        {
            int time = Random.Range(10, 20);
            yield return new WaitForSeconds(2f);
            CoinSpawn();
        }

    }
}
