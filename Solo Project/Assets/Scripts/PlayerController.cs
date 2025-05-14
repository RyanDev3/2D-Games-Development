using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y < 4.5f) transform.Translate(0, playerSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y > -4.5f) transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
        }
    }

    void FixedUpdate()
    {
        
    }
}
