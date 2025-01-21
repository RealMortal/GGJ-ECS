using UnityEngine;

public class BubbleEffect : MonoBehaviour
{
    public float wobbleSpeed = 5f;       // Speed of the wobble effect
    public float wobbleIntensity = 0.1f; // Intensity of the wobble  
    private Vector3 originalScale;

    void Start()
    {
        // Get the material
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Wobble effect using Perlin noise for smoother randomness
        float wobbleX = Mathf.PerlinNoise(Time.time * wobbleSpeed, 0) * wobbleIntensity;
        float wobbleY = Mathf.PerlinNoise(0, Time.time * wobbleSpeed) * wobbleIntensity;
        transform.localScale = new Vector3(
            originalScale.x + wobbleX,
            originalScale.y - wobbleY,
            originalScale.z);



    }
}
