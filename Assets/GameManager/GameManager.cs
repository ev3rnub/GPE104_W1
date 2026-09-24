using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager someGameManager;

    public void Awake()
    {
        if (someGameManager = null)
        {
            someGameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
