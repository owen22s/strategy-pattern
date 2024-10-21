using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public int[] Attacks = { 7, 11, 36 };

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Attack()
    {
        int randomAttack = Random.Range(0, Attacks.Length);
        int damage = Attacks[randomAttack];
        playerHealth.health -= damage;
    }
}
