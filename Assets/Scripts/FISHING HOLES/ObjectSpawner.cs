using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // Object to instantiate
    public GameObject hook; // Hook GameObject
    public int minObjects = 3; // Minimum number of objects
    public int maxObjects = 5; // Maximum number of objects

    private void Start()
    {
        // Randomly instantiate objects around the player
        int numberOfObjects = Random.Range(minObjects, maxObjects + 1);

        for (int i = 0; i < numberOfObjects; i++)
        {
            InstantiateObject();
        }
    }

    private void Update()
    {
        // Check if the hook collides with any instantiated objects
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10f);

        foreach (Collider col in hitColliders)
        {
            if (col.CompareTag("SpawnedObject"))
            {
                // Handle hook collision with the object
                Debug.Log("Hook collided with " + col.name);
                Destroy(col.gameObject);
                InstantiateObject();
            }
        }
    }

    void InstantiateObject()
    {
        // Get a random plane to instantiate the object on
        GameObject[] planes = GameObject.FindGameObjectsWithTag("SpawnPlane");
        GameObject randomPlane = planes[Random.Range(0, planes.Length)];

        // Instantiate the object on the selected plane
        Vector3 randomPosition = randomPlane.transform.position + new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
        Instantiate(objectPrefab, randomPosition, Quaternion.identity);
    }
}
