using TMPro;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI damagePreviewText; // Display the damage preview
    [SerializeField] private PlayerHealth playerHealth;
    private int currentDamage; // Damage to be applied this turn
    private int nextDamage;    // Damage to be previewed for the next turn
    public int[] Attacks = { 7, 11, 36 };

    void Start()
    {
        // Generate the first "next" attack
        GenerateRandomAttack();

        // Show the preview for the first turn's attack
        ShowDamagePreview(nextDamage);

        // Register attack logic
        TurnSystem.TurnEnded.AddListener(Attack);
    }

    public void Attack()
    {
        // Apply current damage after a delay
        Invoke(nameof(ApplyDamage), 1f);

        // Prepare the damage for the next turn
        currentDamage = nextDamage;
        GenerateRandomAttack(); // Generate the attack for the next turn
        ShowDamagePreview(nextDamage); // Update the preview for the next turn
    }

    public void GenerateRandomAttack()
    {
        int randomAttackIndex = Random.Range(0, Attacks.Length);
        nextDamage = Attacks[randomAttackIndex];
        Debug.Log("Generated random attack for next turn: " + nextDamage);
    }

    private void ShowDamagePreview(int damage)
    {
        damagePreviewText.text = $"Enemy will deal {damage} damage next turn!";
        damagePreviewText.gameObject.SetActive(true);
    }

    private void ApplyDamage()
    {
        playerHealth.health -= currentDamage;

        if (playerHealth.health < 0)
        {
            playerHealth.health = 0;
        }

        Debug.Log($"Applied {currentDamage} damage to the player. Remaining health: {playerHealth.health}");
    }
}
