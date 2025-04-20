using UnityEngine;

public class Car_Movement : MonoBehaviour
{
    public Transform transform;
    public float speed = 4f;
    
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);

        //destrroy the car when it goes out of screen
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
        
    }
}
