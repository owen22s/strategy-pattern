using UnityEngine;

public class PlayArea : MonoBehaviour
{
    [SerializeField] private Energy energyScripts;  // Reference to the Energy script

    void Start()
    {
        // Initialization code can be placed here if needed
    }

    void Update()
    {
        // Update logic can be placed here if needed
    }

    // This method is called when another collider enters the trigger collider attached to the GameObject
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the Card component
        Card card = other.gameObject.GetComponent<Card>();
        if (card != null) // If the card component exists, then it’s a card
        {
            PlayCard(card); // Call PlayCard with the card
        }
    }

    public void PlayCard(Card card)
    {
        // Check if there is enough energy to play the card
        if (energyScripts.currentEnergy >= card.CardEnergyCost)
        {
            // Deduct the energy cost of the card
            energyScripts.currentEnergy -= card.CardEnergyCost;
            energyScripts.UpdateEnergyUI(); // Update energy UI after spending energy

            // Call the card's PlayCard method
            card.PlayCard();

            Debug.Log($"Played card: {card.name}. Remaining energy: {energyScripts.currentEnergy}");
        }
        else
        {
            Debug.Log("Not enough energy to play this card.");
        }
    }
}
