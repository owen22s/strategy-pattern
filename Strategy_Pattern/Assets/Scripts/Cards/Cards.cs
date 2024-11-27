using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public GameObject[] cardPrefabs;
    private Camera mainCamera;
    public float cardSpacing = 2f;
    public int numberOfCards = 5;
    private List<GameObject> instantiatedCards = new List<GameObject>();

    void Start()
    {
        mainCamera = Camera.main;
        GenerateCardsInRow();
        TurnSystem.TurnEnded.AddListener(GenerateCardsInRow);
    }

    void GenerateCardsInRow()
    {
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
        for (int i = 0; i < numberOfCards; i++)
        {
            int randomIndex = Random.Range(0, cardPrefabs.Length);
            Vector3 cardPosition = new Vector3(startPosition.x + i * cardSpacing, startPosition.y, 0);
            GameObject newCard = Instantiate(cardPrefabs[randomIndex], cardPosition, Quaternion.identity);
            instantiatedCards.Add(newCard);

            Debug.Log("Generated a random card: " + cardPrefabs[randomIndex].name);
        }
    }
    void DestroyOldCards()
    {
        foreach (GameObject card in instantiatedCards)
        {
            Destroy(card);
        }
        instantiatedCards.Clear();
    }

    Vector3 GetBottomCenterPosition()
    {
        return mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.1f, mainCamera.nearClipPlane));
    }
}