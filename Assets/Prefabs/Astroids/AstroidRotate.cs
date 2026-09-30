using UnityEngine;                                                                                                                                               
                                                                                                                                                                    
public class AstroidRotate : MonoBehaviour
{
   public int astroidRotateSpeed = 180;
   public float moveSpeed = 2f;

   private Vector3 moveDirection;
   private ScreenWrap screenWrapComponent;

   void Start()
   {
       // Set random movement direction
       float randomAngle = Random.Range(0f, 360f);
       moveDirection = new Vector3(Mathf.Sin(randomAngle * Mathf.Deg2Rad),Mathf.Cos(randomAngle * Mathf.Deg2Rad),0f);

       // Get reference to ScreenWrap component
       screenWrapComponent = GetComponent<ScreenWrap>();
   }

   void Update()
   {
       // Move the asteroid\
       transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

       // Handle screen wrapping if component exists
       if (screenWrapComponent != null)
       {
           screenWrapComponent.HandleWrap();
       }
       // Rotate the asteroid
       transform.Rotate(0, 0, 1 * astroidRotateSpeed * Time.deltaTime);
   }
}