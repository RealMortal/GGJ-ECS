using UnityEngine;

public class LoadLevel : MonoBehaviour
{

    public GameObject nextLevelUI;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            nextLevelUI.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
