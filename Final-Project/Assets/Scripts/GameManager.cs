using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum CHAR
    {
        None = 0,
        Ripoll,
        Etepe, 
        Simon,
        Rivera, 
        Negrazo,
        Piter, 
        Yikes
    }

    class Player
    {
        public int score = 0;
        public CHAR character = CHAR.None;
    }

    Player player_1 = new Player();
    Player player_2 = new Player();

    Player current_player;

    public int MAX_SCORE = 8; 

    void Start()
    {
        // TODO: Enable choose character menu
        current_player = Random.Range(0, 1) == 0 ? player_1 : player_2;
    }

    void Update()
    {
        
    }

    public void Hit()
    {
        // Add score
        current_player.score++;

        // TODO: Update player UI score
         
        
        // TODO: Show PLAYER X DRINKS!!! 

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
            // TODO: Switch to Winner Scene!

            Debug.Log("Game Over");
            return;
        }

        // Change current player
        current_player = current_player == player_1 ? player_2 : player_1;

        // TODO: Update UI Layout
            

        // TODO: Reset Ball


    }

    public void SetPlayersChars(int player1, int player2)
    {
        player_1.character = (CHAR)player1;
        player_2.character = (CHAR)player2;
    }

}
