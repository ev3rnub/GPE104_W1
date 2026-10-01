using UnityEngine;

public class AsteroidBreak : MonoBehaviour
{
   public float astroidSize;
   public float minSize = 0.25f;
   public GameObject astroidPrefab;
   public int breakCount = 2;
   public bool broken = false;
   private Death death;

   void Start()
   {
        death = GetComponent<Death>();
        astroidSize = gameObject.transform.localScale.x;
   }

   void OnTriggerEnter2D(Collider2D other)
   {
       // Check if the colliding object is a bullet
       if (other.CompareTag("Bullet"))
       {
           // Only break if asteroid is large enough
           if (astroidSize > minSize)
           {
               // Create smaller asteroids
               for (int i = 0; i < breakCount; i++)
               {                                                                                                                                                
                   // Calculate random direction for each new asteroid                                                                                          
                   float angle = Random.Range(0f, 360f);                                                                                                        
                   Vector3 direction = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad),0f);
                   // Instantiate smaller asteroid
                   GameObject newAstroid = Instantiate(astroidPrefab, transform.position, Quaternion.identity);
                                      // Set the new asteroid to be smaller and properly initialize                                                                                    
                   AsteroidBreak newAstroidScript = newAstroid.GetComponent<AsteroidBreak>();                                                                       
                   if (newAstroidScript != null)                                                                                                                    
                   {                                                                                                                                                
                       newAstroidScript.astroidPrefab = this.astroidPrefab; // This is the key fix                                                                  
                       newAstroidScript.astroidSize = astroidSize / 2f;                                                                                             
                       newAstroid.transform.localScale = new Vector3(astroidSize / 2f, astroidSize / 2f, astroidSize / 2f);                                         
                   }
               }
           }

           // Destroy the original asteroid
           death.Die();
       }
   }
}