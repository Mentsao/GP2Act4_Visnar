using UnityEngine;

public class ShacoUltimate : MonoBehaviour
{
    public GameObject player; // Reference to the player
    public GameObject clonePrefab; // Prefab for the clone
    public float cloneDuration = 5f; // How long the clone lasts
    public Vector3 spawnOffset = new Vector3(2, 0, 0); // Position offset for the clone

    private GameObject activeClone;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Press 'R' to activate the ultimate
        {
            if (activeClone == null) // Ensure only one clone exists at a time
            {
                SpawnClone();
            }
        }
    }

    void SpawnClone()
    {
        // Spawn the clone at an offset from the player's position
        Vector3 spawnPosition = player.transform.position + spawnOffset;
        activeClone = Instantiate(clonePrefab, spawnPosition, player.transform.rotation);

        // Copy basic appearance of the player to the clone
        CopyAppearance(player, activeClone);

        // Destroy the clone after the specified duration
        Destroy(activeClone, cloneDuration);
    }

    void CopyAppearance(GameObject original, GameObject clone)
    {
        Renderer originalRenderer = original.GetComponent<Renderer>();
        Renderer cloneRenderer = clone.GetComponent<Renderer>();

        if (originalRenderer != null && cloneRenderer != null)
        {
            cloneRenderer.material = originalRenderer.material;
        }
    }
}
