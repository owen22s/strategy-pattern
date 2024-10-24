using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    // Array to hold card prefabs (assign in the Unity Inspector)
    public GameObject[] cardPrefabs;
    private Camera mainCamera;
    public float cardSpacing = 1.5f;
    public int numberOfCards = 5;

    // List to keep track of instantiated cards
    private List<GameObject> instantiatedCards = new List<GameObject>();

    void Start()
    {
        mainCamera = Camera.main;
        GenerateCardsInRow();
        TurnSystem.TurnEnded.AddListener(GenerateCardsInRow);
    }

    void GenerateCardsInRow()
    {
        // Destroy old cards before generating new ones
        DestroyOldCards();

        if (cardPrefabs.Length == 0)
        {
            Debug.LogWarning("No card prefabs assigned!");
            return;
        }

        if (numberOfCards > 10)
        {
            numberOfCards = 10;
        }

        Vector3 startPosition = GetBottomCenterPosition();
        float totalWidth = (numberOfCards - 1) * cardSpacing;
        startPosition.x -= totalWidth / 2;

        // Generate new cards
        for (int i = 0; i < numberOfCards; i++)
        {
            int randomIndex = Random.Range(0, cardPrefabs.Length);
            Vector3 cardPosition = new Vector3(startPosition.x + i * cardSpacing, startPosition.y, 0);
            GameObject newCard = Instantiate(cardPrefabs[randomIndex], cardPosition, Quaternion.identity);

            // Store the new card in the list
            instantiatedCards.Add(newCard);

            Debug.Log("Generated a random card: " + cardPrefabs[randomIndex].name);
        }
    }

    // Method to destroy all old cards
    void DestroyOldCards()
    {
        foreach (GameObject card in instantiatedCards)
        {
            Destroy(card);
        }
        // Clear the list after destroying the cards
        instantiatedCards.Clear();
    }

    Vector3 GetBottomCenterPosition()
    {
        return mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.1f, mainCamera.nearClipPlane));
    }
}
