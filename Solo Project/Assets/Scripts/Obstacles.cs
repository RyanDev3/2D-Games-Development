using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private float minStopXPosition;
    [SerializeField] private float maxStopXPosition;
    private float stopXPosition;

    [SerializeField] private float speed;
    [SerializeField] private int damageAmount = 1;

    private bool isPositioned;

    void Start()
    {
        stopXPosition = Random.Range(minStopXPosition + 0.0f, maxStopXPosition + 0.0f);
    }

    void Update()
    {
        if (!isPositioned)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (transform.position.x < stopXPosition)
        {
            isPositioned = true;
            transform.position = new Vector2(stopXPosition, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}