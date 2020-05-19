using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    class Player
    {
        public int score = 0; 
        // Character
    }

    Player player_1 = new Player();
    Player player_2 = new Player();

    Player current_player;

    public int MAX_SCORE = 8; 

    void Start()
    {
        // TODO: Enable choose character menu

    }

    void Update()
    {
        
    }

    public void Hit()
    {
        // Add score
        current_player.score++;

        // TODO: Show PLAYERX DRINKS!!! 
        NextTurn();
    }

    public void Miss()
    {
        // TODO: Show You Missed Text

        NextTurn();
    }

    public void NextTurn()
    {
        // Check if the game is over
        if(current_player.score >= MAX_SCORE)
        {
            Debug.Log("Game Over");
            return;
        }

        // Change current player
        current_player = current_player == player_1 ? player_2 : player_1;

        // TODO: Update Player UI 


        // TODO: Reset Ball


    }
}
