//Course: GPE104 
//Prof: Matthew Henry 
//Student: Chad V

using UnityEngine;
using System.Collections;
using System.Collections.Generic; // for List<>
using TMPro;
using System;

public class GameManager : MonoBehaviour
{   
    [Header("GameObjects")]
    public static GameManager someGameManager;
    public GameObject astroidPrefab;
    public GameObject bulletPrefab;
    public ControllerPlayer controllerPlayer; // get controller ref for player entity.
    public TextMeshProUGUI someValue;
    public TextMeshProUGUI someStatusMsg;
    public TextMeshProUGUI someAstroidValue;
    public TextMeshProUGUI someBulletValue;
    public TextMeshProUGUI someStageValue;
    public Pawn someSpaceShipPawn;
    
    [Header("Lists")]
    public List<Obstacle> obstacleList;  // Obstacle list to keep track of astroids/obstacles
    public List<Bullet> bulletList; // A Bullet list to keep limit how many projectiles we spawn if the player holds down space.
    public List<float> someStageList;
    
    [Header("Int's")]
    public int someScore;
    public int totalAstroidCnt = 5;
    public int stage = 1;

    [Header("Floats")]
    public float someMaxWidth = Screen.width;
    public float someMaxHeight = Screen.height;
    public float someStageSecTime = 2f;


    [Header("Bools")]
    public bool gameOver = false;


    //on awake(before start) if someGameManager is null assign gamemanger to this, and flag it to no destroy,
    //delete any duplicates. 
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
        StartCoroutine(StageOne(someStageSecTime));
        StartCoroutine(StageTwo(someStageSecTime * 4));
        StartCoroutine(StageThree(someStageSecTime * 8));
        StartCoroutine(StageFour(someStageSecTime * 10));
    }

    IEnumerator StageOne(float someSeconds)
    {
        yield return new WaitForSeconds(someSeconds);
        totalAstroidCnt += 2;
        someStatusMsg.text = "Stage One Completed!";
        someStageValue.text = stage.ToString();
    }

    IEnumerator StageTwo(float someSeconds)
    {
        yield return new WaitForSeconds(someSeconds);
        totalAstroidCnt += 4;
        someStatusMsg.text = "Stage Two Completed!";
        stage = 2;
        someStageValue.text = stage.ToString();
    }

    IEnumerator StageThree(float someSeconds)
    {
        yield return new WaitForSeconds(someSeconds);
        totalAstroidCnt += 6;
        someStatusMsg.text = "Stage Three Completed!";
        stage = 3;
        someStageValue.text = stage.ToString();
    }

    IEnumerator StageFour(float someSeconds)
    {
        yield return new WaitForSeconds(someSeconds);
        totalAstroidCnt += 8;
        someStatusMsg.text = "OVERTIME STAGE!";
        stage = 4;
        someStageValue.text = stage.ToString();
    }
    
    void Update()
    {

        CleanupObstacleList();
        SpawnAstroid();
        // if obstacle list is not null and obstacle count is less than 0 and controlerPlayer is not null, if Game over does not equal
        // false and controllerPlayer.somePawn is not null, print Victory to the debug log, and set gameOver to true;
        if (obstacleList != null)
        {

            //Debug.Log($"Astroid Count: {obstacleList.Count}");

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

        if (bulletList != null)
        {
            //Debug.Log($"Bullet Count: {bulletList.Count}");
            someBulletValue.text = bulletList.Count.ToString();
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

    //Astroid spawning
    void SpawnAstroid()
   {
        Vector3 spawnPos = new Vector3(0f, 0f, 0f);
        if (astroidPrefab != null && someAstroidValue.text != null)
        {
            string numberString = someAstroidValue.text;
            int number = Convert.ToInt32(numberString);

            if (number < totalAstroidCnt)
            {
                float minDistance = 5f;

                bool safeSpawn = false;
                while (!safeSpawn)
                {
                    float someXRange = UnityEngine.Random.Range(-10f, 10f);
                    float someYRange = UnityEngine.Random.Range(-5f, 5f);
                    spawnPos = new Vector3(someXRange, someYRange, 0f);

                    if (controllerPlayer != null && controllerPlayer.somePawn != null)
                    {
                        float distance = Vector3.Distance(spawnPos, controllerPlayer.somePawn.transform.position);
                        if (distance >= minDistance)
                        {
                            safeSpawn = true;
                        }
                    }
                    else
                    {
                        safeSpawn = true;
                    }
                }

                // Instantiate with position and add to obstacle list
                GameObject newAstroid = Instantiate(astroidPrefab, spawnPos, Quaternion.identity);
                float someFloat = UnityEngine.Random.Range(0.25f, 2f);
                newAstroid.transform.localScale = new Vector3(someFloat, someFloat, someFloat);

                // Get the Obstacle component and add to list
                Obstacle obstacle = newAstroid.GetComponent<Obstacle>();
                if (obstacle != null)
                {
                    obstacleList.Add(obstacle);
                }

              AsteroidBreak asteroidBreakScript = newAstroid.GetComponent<AsteroidBreak>();                                                                        
               if (asteroidBreakScript != null)                                                                                                                     
               {                                                                                                                                                    
                   asteroidBreakScript.astroidPrefab = astroidPrefab;                                                                                               
               } 
            }
        }
    }
}
