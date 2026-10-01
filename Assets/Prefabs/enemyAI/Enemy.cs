using UnityEngine;

public class EnemyAIScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float chaseRange = 10f;
    private Transform playerTransform;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Find player if not already found
        if (playerTransform == null)
        {                                                                                                            
              GameObject player = GameObject.FindGameObjectWithTag("Player");
              if (player != null)
              {
                  playerTransform = player.transform;
              }
        }
        // If player found, chase them                                                                                                                        
        if (playerTransform != null)
        { 
              Vector3 direction = playerTransform.position - transform.position;
              float distance = direction.magnitude;
              // Only chase if player is within range
              if (distance < chaseRange)
              {
                  // Move towards player
                  rb.linearVelocity = direction.normalized * moveSpeed;
              }
        }
    }                                                                                                                                                         
}