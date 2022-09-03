using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private static int score;
    private static bool isGameOver = false;
    public static int Score { get => score; set => score = value; }
    public static bool IsGameOver { get => isGameOver; set => isGameOver = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
