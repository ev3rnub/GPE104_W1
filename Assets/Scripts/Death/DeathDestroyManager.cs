using UnityEngine;
using System.Collections;

public class DeathDestroyManager : Death
{
    private Obstacle obstacleToRemove;
    public int someScoreValue = 10;

    public override void Die()
    {
        if (GameManager.someGameManager != null)
        {
            if (GameManager.someGameManager.obstacleList != null && obstacleToRemove != null)
            {
                GameManager.someGameManager.obstacleList.Remove(obstacleToRemove);
            }
            GameManager.someGameManager.someScore += someScoreValue;
            GameManager.someGameManager.someStatusMsg.text = $"Obtained {someScoreValue} points, total is now {GameManager.someGameManager.someScore}";
            StartCoroutine(ResetStatusMsg());
        }
        //removes gameobject from scene.
        Destroy(gameObject);

    }

    // after .3 seconds increase bullet force to 500
         IEnumerator ResetStatusMsg()
        {
            // Wait for exactly 1 seconds
            yield return new WaitForSeconds(1f);

            GameManager.someGameManager.someStatusMsg.text = "";
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
