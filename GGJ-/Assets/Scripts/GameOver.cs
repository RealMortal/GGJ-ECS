using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenu;
    public void GG()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
