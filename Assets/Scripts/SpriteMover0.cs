//Course: GPE104 
//Prof: Matthew Henry 
//Proj: Project 2 Milestone 1 - My First Sprite Mover
//Student: Chad V


//imports
using UnityEngine;
using UnityEngine.InputSystem; // use Unity's NEW input system


// woot first class in c# SpriteMover0
public class SpriteMover0 : MonoBehaviour
{
    
    // set priv var for camera ref
    private Camera cam;
    public int someMaxWidth = Screen.width;
    public int someMaxHeight = Screen.height;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // get objects name and print to debug log stating our sprite mover is attached;
    

    void Start()
    {
        // get player objects name
        string playerObjectName = gameObject.name;
        // get camera reference
        cam = Camera.main;

        // debug log
        Debug.Log("Sprite Mover attached to Sprite" + playerObjectName);
        Debug.Log($"Current Screen Width/Height: {someMaxWidth}, {someMaxHeight}");
    }

    // Update is called once per frame
    // In SpriteMover0 we will check to see if any key is pressed, if so,
    // We get the visible screen space/size and move  the sprite to a random position.

    void Update()
    {
        //is any key pressed?
        if (Keyboard.current.anyKey.wasPressedThisFrame)
                {
                    // Find which specific key was pressed
                    foreach (Key key in System.Enum.GetValues(typeof(Key)))
                    {
                        // Random movement of player2d Sprite
                        if (key == Key.None) continue;
                        if (Keyboard.current[key].wasPressedThisFrame)
                        {
                            Debug.Log($"Key pressed: {key}");
                            // move randomly
                            MoveToRandomViewportPosition();
                            break;
                        }
                    }
                    // Escape detectection
                    // if so, quit
                    if (Keyboard.current.escapeKey.wasPressedThisFrame)
                        {
                            Debug.Log("escapeKey was pressed!");
                            QuitGame();
                            // move sprite, etc.
                        }                    

                    // Future Use: WSAD input detection 
                    if (Keyboard.current.aKey.wasPressedThisFrame)
                        {
                            Debug.Log("A was pressed!");
                            // move sprite, etc.
                        }
                    if (Keyboard.current.dKey.wasPressedThisFrame)
                        {
                            Debug.Log("D was pressed!");
                            // move sprite, etc.
                        }
                    if (Keyboard.current.wKey.wasPressedThisFrame)
                        {
                            Debug.Log("W was pressed!");
                            // move sprite, etc.
                        }
                    if (Keyboard.current.sKey.wasPressedThisFrame)
                        {
                            Debug.Log("S was pressed!");
                            // move sprite, etc.
                        }
                }
    }

    void MoveToRandomViewportPosition()
    {
        Debug.Log($"Current Screen width/height = ({someMaxWidth}/{someMaxHeight})");

        // 2. Pick a random pixel position within that range
        float randomPixelX = Random.Range(0f, someMaxWidth);
        float randomPixelY = Random.Range(0f, someMaxHeight);

        // 3. Convert screen (pixel) space → world space
        //    z = 0 because we're in 2D, however worldPos is set to randomPixelX, randomPixelY, -10f due to the cam
        Vector3 worldPos = cam.ScreenToWorldPoint(
            new Vector3(randomPixelX, randomPixelY, 0f)
        );

        Debug.Log($"Current World Pos to move to: {worldPos}");

        // 4. Move the attached sprite via transform.
        worldPos.z = 0f; // [RESEARCH: "Why cam.ScreenToWorldPoint sets worldPos z to -10f, resetting it to 0."]
        Debug.Log($"NEW World Pos to move to: {worldPos}");
        transform.position = worldPos;
        Debug.Log($"Screen: ({randomPixelX:F0}, {randomPixelY:F0}) >> World: {worldPos}");
    }

    void MoveNorth()
    {
        // Future Use
        // 0. Set a fixed amt of pixels to move our player2d Sprite by
        int someMoveAmt = 50;  // e.g., 50 pixels

        // 1. Get viewport resolution use it as max width/height
        if (someMaxWidth >= 0)
        {
            someMaxWidth  = Screen.width;   // e.g., 1920
        }
        if (someMaxHeight >= 0)
        {
            someMaxHeight = Screen.height;  // e.g., 1080
        }
    }

    void QuitGame()
    {
        // In a built player, close the application
        Debug.Log("INSIDE QUITGAME");
        Application.Quit();

        // If running inside the Unity Editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
