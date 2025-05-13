using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //float directionY = Input.GetAxisRaw("Vertical");
        //playerDirection = new Vector2(0, directionY).normalized;

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
