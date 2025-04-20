
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 5f; // Speed of the player movement
    public float rotationSpeed = 5f; // Speed of the player's rotation
    public Score_Manager ScoreValue;


    public GameObject GameOverpanel;

    void Start()
    {
        GameOverpanel.SetActive(false);
    }

    void Update()
    {
        Movement(); // Handle player movement
        Clamp(); // Keep player within screen boundaries
    }

    void Movement()
    {
        // Move right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new UnityEngine.Vector3(speed * Time.deltaTime, 0, 0);
            transform.rotation = UnityEngine.Quaternion.Lerp(transform.rotation, UnityEngine.Quaternion.Euler(0, 0, -70), rotationSpeed * Time.deltaTime);
        }

        // Move left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new UnityEngine.Vector3(speed * Time.deltaTime, 0, 0);
            transform.rotation = UnityEngine.Quaternion.Lerp(transform.rotation, UnityEngine.Quaternion.Euler(0, 0, 130), rotationSpeed * Time.deltaTime);
        }

        // Gradually reset rotation to 90° when no key is pressed
        if (transform.rotation.z != 0)
        {
            transform.rotation = UnityEngine.Quaternion.Lerp(transform.rotation, UnityEngine.Quaternion.Euler(0, 0, 90), 10f * Time.deltaTime);
        }
    }

    void Clamp()
    {
        // Restrict player's position to screen limits
        UnityEngine.Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -1.8f, 1.8f);
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        // If player collides with a car, stop the game (commented out)
        if (Collision.gameObject.tag == "Cars")
        {

            // // Uncomment to stop the game on collision
            Time.timeScale = 0;

            GameOverpanel.SetActive(true);

        }
        if (Collision.gameObject.tag == "Coin")
        {

            // // Uncomment to stop the game on collision
            Destroy(Collision.gameObject);
        }
        {

        }
    }
}
