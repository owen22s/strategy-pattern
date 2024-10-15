using UnityEngine;

public class Card : MonoBehaviour, ICard
{
    public int CardEnergyCost;
    public float damageAmount = 10f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Controleer of de speler is geraakt
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Pak het Health-script van de speler
            Health playerHealth = collision.gameObject.GetComponent<Health>();

            // Controleer of de speler een Health component heeft
            if (playerHealth != null)
            {
                // Breng schade toe aan de speler
                playerHealth.TakeDamage(damageAmount);
                Debug.Log("Schade toegebracht aan de speler: " + damageAmount);
            }
        }
    }

    void Update()
    {

    }
    public void PlayCard()
    {
        Destroy(gameObject);
    }

}
