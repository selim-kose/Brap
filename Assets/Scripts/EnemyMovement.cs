using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 3.0f;  // Movement speed of the enemy
    public float stoppingDistance = 2f;  // Distance at which the enemy stops approaching the player

    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the player object in the scene
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Calculate the distance between the enemy and the player
            float distance = Vector2.Distance(transform.position, player.position);

            // Move towards the player if not within the stopping distance
            if (distance > stoppingDistance)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            // Rotate to face the player
            //Vector2 lookDirection = player.position - transform.position;
            //float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }
}
