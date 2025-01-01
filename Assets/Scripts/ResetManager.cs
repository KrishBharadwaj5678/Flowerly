using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour
{
    private List<GameObject> placedFlowers = new List<GameObject>(); // Keeps track of all placed flower models

    // Method to add a placed flower to the list
    public void AddFlower(GameObject flower)
    {
        placedFlowers.Add(flower);
    }

    // Method to clear all placed flowers
    public void ResetFlowers()
    {
        foreach (GameObject flower in placedFlowers)
        {
            Destroy(flower); // Destroy the flower object
        }
        placedFlowers.Clear(); // Clear the list
    }
}
