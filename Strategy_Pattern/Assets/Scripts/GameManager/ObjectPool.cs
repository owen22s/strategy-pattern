using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] cardPrefabs; // List of card prefabs to instantiate from
    public int amountPooled = 20; // Number of cards to pool

    // List to store pooled cards
    private List<GameObject> pooledCards = new List<GameObject>();

    void Start()
    {
        // Initialize the pool with inactive cards
        for (int i = 0; i < amountPooled; i++)
        {
            GameObject obj = Instantiate(cardPrefabs[i]);
            obj.SetActive(false); // Set them inactive initially
            pooledCards.Add(obj); // Add to the pool
        }
    }

    // Method to get a card from the pool
    public GameObject GetPooledCard()
    {
        foreach (GameObject card in pooledCards)
        {
            if (!card.activeInHierarchy) // Check for an inactive card
            {
                return card;
            }
        }

        // Optionally, if no cards are available, you can add logic to expand the pool
        Debug.LogWarning("No inactive cards available in the pool.");
        return null;
    }
}
