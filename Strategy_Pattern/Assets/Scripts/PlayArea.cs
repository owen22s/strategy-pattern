using UnityEngine;

public class PlayArea : MonoBehaviour
{
    [SerializeField] private Energy energyScript;  // Reference to the Energy script
    [SerializeField] private Health healthScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Card card = other.gameObject.GetComponent<Card>();
        if (card != null)
        {
            TryPlayCard(card);
        }
    }

    private void TryPlayCard(Card card)
    {
        // Check if the player has enough energy to play the card
        if (!CanPlayCard(card))
        {
            Debug.Log("Not enough energy to play this card.");
            return;  // Exit the method if there isn't enough energy
        }
        PlayCard(card);
    }

    private bool CanPlayCard(Card card)
    {
        // Check if the current energy is greater than or equal to the card's energy cost
        return energyScript.CurrentEnergy >= card.CardEnergyCost;
    }

    private void PlayCard(Card card)
    {
        healthScript.TakeDamage(card.damageAmount);
        energyScript.SpendEnergy(card.CardEnergyCost);
        card.PlayCard();
        Debug.Log($"Played card: {card.name}. Remaining energy: {energyScript.CurrentEnergy}");
    }
}
