using UnityEngine;

public class DeathDestroyManager : Death
{
    private Obstacle obstacleToRemove;

    public override void Die()
    {
        if (GameManager.someGameManager != null)
        {
            if (GameManager.someGameManager.obstacleList != null && obstacleToRemove != null)
            {
                GameManager.someGameManager.obstacleList.Remove(obstacleToRemove);
            }
        }
        //removes gameobject from scene.
        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obstacleToRemove = GetComponent<Obstacle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
