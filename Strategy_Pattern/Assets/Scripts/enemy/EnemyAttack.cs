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
        GenerateRandomAttack();
        ShowDamagePreview(nextDamage);
        TurnSystem.TurnEnded.AddListener(Attack);
    }

    public void Attack()
    {
        Invoke(nameof(ApplyDamage), 1f);
        currentDamage = nextDamage;
        GenerateRandomAttack();
        ShowDamagePreview(nextDamage);
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
