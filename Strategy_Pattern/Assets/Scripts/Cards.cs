using UnityEngine;

public class Cards : MonoBehaviour
{
    // Array to hold card prefabs (assign in the Unity Inspector)
    public GameObject[] cardPrefabs;

    // Reference to the main camera
    private Camera mainCamera;

    // Horizontal spacing between cards
    public float cardSpacing = 1.5f; // Adjust this to control spacing between cards

    // Number of cards to generate
    public int numberOfCards = 5;

    void Start()
    {
        mainCamera = Camera.main;
        GenerateCardsInRow();
    }

    void GenerateCardsInRow()
    {
        if (cardPrefabs.Length == 0)
        {
            Debug.LogWarning("No card prefabs assigned!");
            return;
        }

        // Limit the number of cards to a maximum of 10
        if (numberOfCards > 10)
        {
            numberOfCards = 10;
        }

        // Get the starting position for the first card
        Vector3 startPosition = GetBottomCenterPosition();

        // Calculate the total width for all cards to center them properly
        float totalWidth = (numberOfCards - 1) * cardSpacing;

        // Offset the first card to the left, so the row of cards is centered
        startPosition.x -= totalWidth / 2;

        // Loop through and generate cards
        for (int i = 0; i < numberOfCards; i++)
        {
            int randomIndex = Random.Range(0, cardPrefabs.Length);
            Vector3 cardPosition = new Vector3(startPosition.x + i * cardSpacing, startPosition.y, 0);
            Instantiate(cardPrefabs[randomIndex], cardPosition, Quaternion.identity);

            Debug.Log("Generated a random card: " + cardPrefabs[randomIndex].name);
        }
    }

    Vector3 GetBottomCenterPosition()
    {
        return mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.1f, mainCamera.nearClipPlane));
    }
}
