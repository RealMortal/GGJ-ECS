using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class BubbleDecay : MonoBehaviour
{

    public int maxHealth = 30;     // Maximum health of the bubble (30 seconds to die)
    [HideInInspector]
    public int currentHealth;
    private SpriteRenderer spriteRenderer;
    private float timePerHealth;  // Time to lose 1 health
    private float timer;          // Tracks time for health decrement
    public TextMeshProUGUI textMeshProUGUI;


    public AudioClip bubblePopSound; // Drag the audio clip in the Inspector
    private AudioSource audioSource;
    private bool notGameOver = true;
    public GameOver gameOverScript;
    void Start()
    {
        Time.timeScale = 1.0f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        timePerHealth = 1f; // 1 second per health point
        timer = 0f;

        // Add an AudioSource component to the bubble if it doesn't exist
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the bubble pop sound
        audioSource.clip = bubblePopSound;
        audioSource.playOnAwake = false; // Ensure it doesn't play automatically
    }

    void Update()
    {
        if (notGameOver)
        {
            // Reduce health over time
            timer += Time.deltaTime;
            if (timer >= timePerHealth && currentHealth > 0)
            {
                timer = 0f;
                currentHealth--;

                // Update sprite based on current health

            }

            // Destroy the bubble when health reaches 0
            if (currentHealth <= 0)
            {
                // Play the pop sound
                audioSource.Play();

                // Destroy the bubble after the sound finishes
                Destroy(gameObject, bubblePopSound.length);
                gameOverScript.GG();
                notGameOver = false;

            }

            textMeshProUGUI.text = currentHealth.ToString();
        }
     
       
    }

   

    public void Heal(int amount)
    {
        // Heal the bubble and prevent health from exceeding maxHealth
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }
}