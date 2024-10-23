using UnityEngine;

public class PlayArea : MonoBehaviour
{
    [SerializeField] private Energy energyScript;
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
        if (!CanPlayCard(card))
        {
            Debug.Log("Not enough energy to play this card.");
            return;
        }
        PlayCard(card);
    }

    private bool CanPlayCard(Card card)
    {
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
