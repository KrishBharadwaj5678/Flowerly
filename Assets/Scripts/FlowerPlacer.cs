using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class FlowerPlacer : MonoBehaviour
{
    public GameObject[] flowerPrefabs; // Array to hold flower prefabs

    [SerializeField] private ARPlaneManager planeManager; // Assign in Inspector
    [SerializeField] private ARRaycastManager raycastManager; // Assign in Inspector
    private List<ARRaycastHit> hits = new List<ARRaycastHit>(); // To store raycast hits

    void Update()
    {
        // Ensure there is at least one touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch phase is "Began"
            if (touch.phase == TouchPhase.Began)
            {
                // Perform a raycast at the touch position
                bool collision = raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon);

                if (collision)
                {
                    // Instantiate a random flower prefab
                    GameObject flower = Instantiate(flowerPrefabs[Random.Range(0, flowerPrefabs.Length)]);
                    flower.transform.position = hits[0].pose.position; // Place the flower at the detected plane
                    flower.transform.rotation = hits[0].pose.rotation; // Align flower with the plane's orientation

                    // Set a tag for the flower prefab
                    flower.tag = "Flower"; // Tag the instantiated flower with "Flower"
                }
                else
                {
                    Debug.Log("No plane hit detected.");
                }
            }
        }
    }

    // Method to reset (clear) all placed flowers by tag
    public void ResetFlowers()
    {
        // Find all GameObjects with the "Flower" tag
        GameObject[] flowers = GameObject.FindGameObjectsWithTag("Flower");

        // Destroy each flower
        foreach (GameObject flower in flowers)
        {
            if (flower != null)
            {
                Debug.Log($"Destroying flower at: {flower.transform.position}");
                Destroy(flower); // Destroy each flower GameObject
            }
        }

        Debug.Log("All flowers have been reset.");
    }
}
