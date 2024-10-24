using TMPro;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemyDamageText; // Display the damage dealt
    [SerializeField] private TextMeshProUGUI damagePreviewText; // Display the damage preview
    [SerializeField] private PlayerHealth playerHealth;
    private int currentDamage;
    public int[] Attacks = { 7, 11, 36 };

    void Start()
    {

        TurnSystem.TurnEnded.AddListener(Attack);
        GenerateRandomAttack();
        ShowDamagePreview(currentDamage);
    }

    public void Attack()
    {
        Invoke(nameof(ApplyDamage), 1f);
        GenerateRandomAttack();
        ShowDamagePreview(currentDamage);
    }
    public void GenerateRandomAttack()
    {
        int randomAttackIndex = Random.Range(0, Attacks.Length);
        currentDamage = Attacks[randomAttackIndex];
        Debug.Log("generated Random attack");
    }

    private void ShowDamagePreview(int damage)
    {
        damagePreviewText.text = $"Enemy will deal {damage} damage!";
        damagePreviewText.gameObject.SetActive(true);
    }

    private void ApplyDamage(int damage)
    {
        playerHealth.health -= damage;

        if (playerHealth.health < 0)
        {
            playerHealth.health = 0;
        }
    }
    private void ApplyDamage()
    {
        playerHealth.health -= currentDamage;
        if (playerHealth.health < 0)
        {
            playerHealth.health = 0;
        }
    }
}
