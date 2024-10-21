using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnController : MonoBehaviour
{
    public EnemyAttack enemy;
    public PlayerHealth player;
    public Energy energy;

    public TextMeshProUGUI TurnTimer;

    public float turnTime = 10f;
    private float currentTurnTime;
    private bool isPlayerTurn;

    void Start()
    {
        StartCoroutine(GameLoop());
    }

   
    IEnumerator GameLoop()
    {
        isPlayerTurn = true;
        currentTurnTime = turnTime;

        while (player.health > 0) //doorgaan tot dood
        {
            currentTurnTime = turnTime;

            if (isPlayerTurn)
            {
                Debug.Log("Beurt Player");
                
                while (currentTurnTime > 0)
                {
                    currentTurnTime -= Time.deltaTime; //aftellen
                    TurnTimer.text = "Time: " + Mathf.Ceil(currentTurnTime).ToString(); //Timer op scherm
                
                    yield return null;
                }
                energy.ResetEnergy();
            }

            else
            {
                Debug.Log("Beurt Enemy");

                enemy.Attack();
                yield return new WaitForSeconds(turnTime);
            }
            
            isPlayerTurn = !isPlayerTurn;
            

            
        }

        if (player.health <= 0)
        {
            Debug.Log("Je bent dood");
        }
    }
}
