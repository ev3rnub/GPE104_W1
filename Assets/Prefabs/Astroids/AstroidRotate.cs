using UnityEngine;

public class AstroidRotate : MonoBehaviour
{
    public int astroidRotateSpeed = 180;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,1 * astroidRotateSpeed * Time.deltaTime);
    }
}
