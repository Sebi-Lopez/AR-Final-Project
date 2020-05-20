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
        public Texture2D tex;
    }

    Player player_1 = new Player();
    Player player_2 = new Player();

    Player current_player;

    public GameUILayout UILayout;
    public GameFeedback UIFeedback;

    public GameObject gameHolder;
    public GameObject ball;
    public GameObject cups_player_1;
    public GameObject cups_player_2;
    public int MAX_SCORE = 8;

    void Start()
    {
        // Chosing random player
        current_player = Random.Range(0, 1) == 0 ? player_1 : player_2;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            Hit();

        if (Input.GetKeyDown(KeyCode.M))
            Miss();
    }

    public void Hit()
    {
        // Add score
        current_player.score++;

        Debug.Log("YOU HIT IT WINNER");
        // TODO: Update player UI score

        // TODO: Show PLAYER X DRINKS!!! 
        StartCoroutine("GetHit");


        NextTurn();

    }

    public void Miss()
    {
        // TODO: Show You Missed Text
        StartCoroutine("GetMiss");


        Debug.Log("YOU MISSED LOOSER");

        NextTurn();
    }

    public void NextTurn()
    {
        // Check if the game is over
        if (current_player.score >= MAX_SCORE)
        {
            // TODO: Switch to Winner Scene!

            Debug.Log("Game Over");
            return;
        }

        // Change current player
        current_player = current_player == player_1 ? player_2 : player_1;

        // Update UI Layout
        UILayout.UpdateUILayout(current_player == player_1 ? 1 : 2, current_player.score, current_player.tex);

        // Reset Ball
        ball.SetActive(true); // First turn
        ball.GetComponentInChildren<launchball>().ResetBall();

        // Switch cups after ball resets, if done before, it eats the others player cup
        SwitchCups(current_player == player_1 ? 1 : 2);
    }

    private void SwitchCups(int player)
    {
        if (player == 1)
        {
            cups_player_1.SetActive(true);
            cups_player_2.SetActive(false);
        }
        else
        {
            cups_player_1.SetActive(false);
            cups_player_2.SetActive(true);
        }
    }

    public void SetPlayersChars(int player1, int player2, Texture2D tex1, Texture2D tex2)
    {
        player_1.character = (CHAR)player1;
        player_2.character = (CHAR)player2;

        player_1.tex = tex1;
        player_2.tex = tex2;
    }

    IEnumerator GetHit()
    {
        UIFeedback.hit_txt.enabled = true;

        if (current_player == player_1)
        {
            UIFeedback.hit_txt.text = "WELL DONE!\n PLAYER 2 DRINKS!";
        }
        else
        {
            UIFeedback.hit_txt.text = "WELL DONE!\n PLAYER 1 DRINKS!";
        }

        yield return new WaitForSeconds(3);
        UIFeedback.hit_txt.enabled = false;
    }

    IEnumerator GetMiss()
    {
        UIFeedback.miss_txt.enabled = true;
        yield return new WaitForSeconds(3);
        UIFeedback.miss_txt.enabled = false;
    }
    public void ShutSystemDown()
    {
        Debug.Log("Shutting System down");
        gameHolder.SetActive(false);
    }

    public void RestartSystem()
    {
        Debug.Log("Restarting System");
        gameHolder.SetActive(true);
    }
}

