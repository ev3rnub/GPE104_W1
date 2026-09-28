//Course: GPE104 
//Prof: Matthew Henry 
//Student: Chad V

using UnityEngine;
using System.Collections;
using System.Collections.Generic; // for List<>
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager someGameManager;
    public float someMaxWidth = Screen.width;
    public float someMaxHeight = Screen.height;
    public GameObject astroidPrefab;
    public int astroidSpawnCnt = 3;

    
    public List<Obstacle> obstacleList;  // Obstacle list to keep track of astroids/obstacles
    public bool gameOver = false;
    public ControllerPlayer controllerPlayer; // get controller ref for player entity.
    public int someScore; 
    public TextMeshProUGUI someValue;
    public TextMeshProUGUI someStatusMsg;
    public TextMeshProUGUI someAstroidValue;

    //player pawn reference to spawn new astroids later. 
    public Pawn someSpaceShipPawn;

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

    void Start()
    {
        // WIP/Future use;
        // Debug.Log("in START");

        // for (int i = 0; i < astroidSpawnCnt; i++)
        // {                                                                                                                                                            
        //    SpawnAstroid();
        // }  
    }

    void Update()
    {

        CleanupObstacleList(); // for some reason I'm getting duplicate astroids in my obstacleList. Need to troubleshoot  this. 
        // if obstacle list is not null and obstacle count is less than 0 and controlerPlayer is not null, if Game over does not equal
        // false and controllerPlayer.somePawn is not null, print Victory to the debug log, and set gameOver to true;
        if (obstacleList != null)
        {

            Debug.Log($"Astroid Count: {obstacleList.Count}");

            if (obstacleList.Count <= 0 && controllerPlayer != null)
            {
                if (gameOver == false && controllerPlayer.somePawn != null)
                {
                    Debug.Log("Victory!!");
                    gameOver = true;
                }
                
            }
            someAstroidValue.text = obstacleList.Count.ToString();
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

        if (someValue != null)
        {
            someValue.text = "" + someScore;
        }

        if (gameOver)
        {
            Application.Quit();

            // If running inside the Unity Editor
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }

   void CleanupObstacleList()
   {
        // Remove null entries from the list
        // item => item == null: This is a lambda expression acting as a condition:
        // item: Represents the current object being evaluated in the list.
        // =>: The lambda operator (read as "goes to").
        // item == null: The check being performed.
        obstacleList.RemoveAll(item => item == null);
   }

    void SpawnAstroid()
    {
        if (astroidPrefab != null)
        {
           float someXRange = Random.Range(-10f, 10f);                                                                                                              
           float someYRange = Random.Range(-5f, 5f);                                                                                                                
           Vector3 somePos = new Vector3(someXRange, someYRange, 0f);                                                                                               
                                                                                                                                                                    
           // Instantiate with position and add to obstacle list                                                                                                    
           GameObject newAstroid = Instantiate(astroidPrefab, somePos, Quaternion.identity);                                                                        
                                                                                                                                                                    
           // Get the Obstacle component and add to list                                                                                                            
           Obstacle obstacle = newAstroid.GetComponent<Obstacle>();                                                                                                 
           if (obstacle != null)                                                                                                                                    
           {                                                                                                                                                        
               obstacleList.Add(obstacle);                                                                                                                          
           }
        }
    }
}
