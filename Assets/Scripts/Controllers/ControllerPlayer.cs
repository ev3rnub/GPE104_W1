//Course: GPE104 
//Prof: Matthew Henry 
//Proj: Project 2 Milestone 2 - Move it, Trooper
//Student: Chad V

using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerPlayer : MyController
{
    private Camera cam; 

    public Key moveFwd = Key.W;
    public Key moveBak = Key.S;
    public Key rotateLeft = Key.A;
    public Key rotateRight = Key.D;
    public Key teleport = Key.T;
    public Key upArrow = Key.UpArrow;
    public Key downArrow = Key.DownArrow;
    public Key leftArrow = Key.LeftArrow;
    public Key rightArrow = Key.RightArrow;
    public Key quitGame = Key.Escape;

    public float turboMultiplier = 2f;
    public float someMaxWidth = Screen.width;
    public float someMaxHeight = Screen.height;

    // like init, but called start!
    void Start()
    {
        cam = Camera.main;
    }

    // called once per frame
    void Update()
    {
        if (somePawn != null)
        {
            // Check if either shift key is held
            bool turboHeld = Keyboard.current.leftShiftKey.isPressed
                          || Keyboard.current.rightShiftKey.isPressed;

            // check if W is being pressed, and if either of the shifts are being held.
            if (Keyboard.current[moveFwd].isPressed)
            {
                //Debug.Log("w was pressed!");
                // move fwd
                Vector3 direction = -somePawn.transform.up;
                if (turboHeld)
                {
                    somePawn.Move(direction * turboMultiplier);
                }
                else
                {
                    somePawn.Move(direction);    
                }
                
            }
            // check if s is beig pressed. 
            if (Keyboard.current[moveBak].isPressed)
            {
                //Debug.Log("s was pressed!");
                // move sprite, etc.
                somePawn.Move(somePawn.transform.up);
            }
            // check if a is being pressed.
            if (Keyboard.current[rotateLeft].isPressed)
            {
                //Debug.Log("a was pressed!");
                // move sprite, etc.
                somePawn.Rotate(1);
            }
            // check if d is being pressed.
            if (Keyboard.current[rotateRight].isPressed)
            {
                //Debug.Log("d was pressed!");
                // rotate.
                somePawn.Rotate(-1);
            }
            // check if escape was pressed.
            if (Keyboard.current[quitGame].isPressed)
            {
                //Debug.Log("ESCAPE was pressed!");
                Application.Quit();

                // If running inside the Unity Editor
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif
            }
            // check if teleport, T was pressed.
            if (Keyboard.current[teleport].wasPressedThisFrame)
            {
                //Debug.Log("T was pressed");
                //move at random
                // get screen/viewport resolution
                //Debug.Log($"Current Screen width/height = ({someMaxWidth}/{someMaxHeight})");
                // set random ranges from max width/height
                float randomPixelX = Random.Range(0f, someMaxWidth);
                float randomPixelY = Random.Range(0f, someMaxHeight);
                //Debug.Log($"X = {randomPixelX}");
                //Debug.Log($"Y = {randomPixelY}");

                Vector3 somePos = new Vector3(randomPixelX, randomPixelY, 0f);
                // 3. Convert screen (pixel) space → world space
                // z = 0 because we're in 2D, however worldPos is set to randomPixelX, randomPixelY, -10f due to the cam
                // IF i dont use ScreenToWorldPoint the sprite gets moved off of the screen.
                Vector3 worldPos = cam.ScreenToWorldPoint(
                    new Vector3(randomPixelX, randomPixelY, 0f)
                );

                //Vector3 worldPos = new Vector3(randomPixelX, randomPixelY, 0f);

                //Debug.Log($"Current World Pos to move to: {worldPos}");

                // 4. Move the attached sprite via transform.
                worldPos.z = 0f; // [RESEARCH: "Why cam.ScreenToWorldPoint sets worldPos z to -10f, resetting it to 0."]
                //Debug.Log($"NEW World Pos to move to: {worldPos}");
                somePawn.Teleport(worldPos);
            }

            // check arrow keys for teleport
            // [IDEA: "Teleport Mini GUI game where the teleport has to be 'charged', refocused, 
            // then once charged/refocused press arrow to teleport in said direction]
            // up
            if (Keyboard.current[upArrow].wasPressedThisFrame)
            {
                Vector3 somePos = somePawn.transform.position;
                somePos.y += 3;
                somePawn.Teleport(somePos);
                
            }
            // down
            if (Keyboard.current[downArrow].wasPressedThisFrame)
            {
                Vector3 somePos = somePawn.transform.position;
                somePos.y -= 3;
                somePawn.Teleport(somePos);
                
            }
            // left
            if (Keyboard.current[leftArrow].wasPressedThisFrame)
            {
                Vector3 somePos = somePawn.transform.position;
                somePos.x -= 3;
                somePawn.Teleport(somePos);
                
            }        
            // right
            if (Keyboard.current[rightArrow].wasPressedThisFrame)
            {
                Vector3 somePos = somePawn.transform.position;
                somePos.x += 3;
                somePawn.Teleport(somePos);
            } 
        }       
    }
}
