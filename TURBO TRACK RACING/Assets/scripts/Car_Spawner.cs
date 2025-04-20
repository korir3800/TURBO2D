using System.Collections;
using UnityEngine;

public class Car_Spawner : MonoBehaviour
{
    public GameObject[] car; // Array of car prefabs to spawn

    void Start()
    {
        StartCoroutine(SpawnCars()); // Start spawning cars repeatedly
    }

    void Cars()
    {
        int rand = Random.Range(0, car.Length); // Pick a random car
        float randXPos = Random.Range(-1.8f, 1.8f); // Pick a random X position

        // Spawn the car at the chosen position with a 90-degree rotation
        Instantiate(car[rand], new Vector3(randXPos, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 90));
    }

    IEnumerator SpawnCars()
    {
        while (true) // Infinite loop to keep spawning cars
        {
            yield return new WaitForSeconds(3); // Wait 3 seconds
            Cars(); // Spawn a car
        }
    }
}
