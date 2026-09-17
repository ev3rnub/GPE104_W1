//Course: GPE104 
//Prof: Matthew Henry 
//Proj: Project 2 Milestone 1 - My First Sprite Mover

//Student: Chad Verbus
//Date: 09/17/2026@08:37AM

//imports
using UnityEngine;
using UnityEngine.InputSystem; // use Unity's NEW input system


// woot first class in c# SpriteMover0
public class SpriteMover0 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // get objects name and print to debug log stating our sprite mover is attached;
    
    void Start()
    {
        string objectName = gameObject.name;
        Debug.Log("Sprite Mover attached to Sprite" + objectName);
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
                        if (key == Key.None) continue;
                        if (Keyboard.current[key].wasPressedThisFrame)
                        {
                            Debug.Log($"Key pressed: {key}");
                            break;
                        }
                    }
                }
        //if so
        //get screen resolution
        //pick random range within said resolution
        //move sprite
        
    }
}
