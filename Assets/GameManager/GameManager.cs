//Course: GPE104 
//Prof: Matthew Henry 
//Student: Chad V

using UnityEngine;
using System.Collections.Generic; // for List<>

public class GameManager : MonoBehaviour
{
    public static GameManager someGameManager;

    // Obstacle list to keep track of astroids/obstacles
    public List<Obstacle> obstacleList;  

    public bool gameOver = false;
    // get controller ref for player entity.     
    public ControllerPlayer controllerPlayer;

    //on awake(before start) if someGameManager 
    public void Awake()
    {
        obstacleList = new List<Obstacle>();

        if (someGameManager == null)
        {
            someGameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // if obstacle list is not null and obstacle count is less than 0 and controlerPlayer is not null, if Game over does not equal
        // false and controllerPlayer.somePawn is not null, print Victory to the debug log, and set gameOver to true;
        if (obstacleList != null)
        {
            if (obstacleList.Count <= 0 && controllerPlayer != null)
            {
                if (gameOver == false && controllerPlayer.somePawn != null)
                {
                    Debug.Log("Victory!!");
                    gameOver = true;
                }
                
            }
        }

        // if game over is false and controller player is not null, and controllerPlayer.pawn is NULL, then fail as it means
        // our player died. 

        if (gameOver == false && controllerPlayer != null)
        {
            if (controllerPlayer.somePawn == null)
            {
                Debug.Log("FAILURE!!");
                gameOver = true;
            }
        }
    }
}
