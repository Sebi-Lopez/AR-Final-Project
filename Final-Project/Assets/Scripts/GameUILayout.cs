using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUILayout : MonoBehaviour
{
    public Text playerText;
    public Text playerScore;
    public RawImage playerTex;

    public void UpdateUILayout(int player, int score, Texture2D tex)
    {
        playerText.text = "PLAYER " + player;
        playerTex.texture = tex;
        playerScore.text = "Score: " + score;
    }

}
