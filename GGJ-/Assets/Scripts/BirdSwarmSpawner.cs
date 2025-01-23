using UnityEngine;

public class BirdSwarmSpawner : MonoBehaviour
{
    public GameObject birdPrefab;      // Prefab of the bird
    public Transform spawnPoint;       // The starting point for the birds
    public float spawnDelay = 0.5f;    // Time delay between spawning birds
    public float minY = -3f;           // Minimum Y position for spawning
    public float maxY = 3f;            // Maximum Y position for spawning
    public float birdSpeed = 5f;       // Speed of the birds moving to the left
    public int numberOfBirds = 10;     // Total number of birds to spawn

    private bool swarmTriggered = false; // Flag to check if swarm is triggered
    private bool spawnTrigger = false;
    void Update()
    {
        // Example trigger (press space to spawn swarm)
        if (spawnTrigger && !swarmTriggered)
        {
            swarmTriggered = true;
            StartCoroutine(SpawnBirds());
        }
    }

    private System.Collections.IEnumerator SpawnBirds()
    {
        for (int i = 0; i < numberOfBirds; i++)
        {
            // Spawn a bird at a random Y position
            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(spawnPoint.position.x, randomY, spawnPoint.position.z);
            GameObject bird = Instantiate(birdPrefab, spawnPosition, Quaternion.Euler(0, 180, 0));
            // Add movement to the bird
            bird.AddComponent<BirdMovement>().speed = birdSpeed;

            // Wait for the next spawn
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnTrigger = true;
        }
    }
}

public class BirdMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Move the bird to the left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Destroy the bird if it goes off-screen
        if (transform.position.x < -10f) // Adjust the value based on your scene
        {
            Destroy(gameObject);
        }
    }
}



