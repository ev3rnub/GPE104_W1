//Course: GPE104 
//Prof: Matthew Henry 
//Student: Chad V

using UnityEngine;

public class DeathDestroy : Death
{
    public override void Die()
    {
        Destroy(gameObject);
    }
}
