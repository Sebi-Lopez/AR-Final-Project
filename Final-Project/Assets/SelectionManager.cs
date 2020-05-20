using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectionManager : MonoBehaviour
{

    public Image[] characters;

    [Header("Players")]
    public RawImage player1;
    public RawImage player2;
   

    [Header("Selected")]
    public bool firstSelected = false;
    public bool secondSelected = false;

    [Header("Popups")]
    public Image bg;
    public Text[] txts;
    private int lastText = 0;

    [Header("Game Canvas")]
    public Canvas selection_canvas;
    public Canvas game_canvas;

    private GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        bg.enabled = false;
        game_canvas.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SelectCharacter(Texture2D tex)
    {
       
        if(firstSelected)
             player2.GetComponent<RawImage>().texture = tex;
        else
            player1.GetComponent<RawImage>().texture = tex;
  
    }

    public void SelectedFirst()
    {
        firstSelected = true;
        bg.enabled = false;
        txts[lastText].enabled = false;
    }

    public void SelectedSecond()
    {
        secondSelected = true; 
        bg.enabled = false;
        txts[lastText].enabled = false;
    }

    public void Fight()
    {
        if(firstSelected && secondSelected)
        {
            selection_canvas.enabled = false;
            game_canvas.enabled = true;
            GM.SetPlayersChars(0, 0);
            GM.NextTurn();
        }
    }

    public void HoverPopUp(int index)
    {
        bg.enabled = true;

        txts[lastText].enabled = false;
        txts[index].enabled = true;
        lastText = index;
    }
}
