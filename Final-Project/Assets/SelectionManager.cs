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

    [Header("Type Character")]
    public int  char_type_1 = 0;
    public int char_type_2 = 0;
    private int current_type = 0;

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
        char_type_1 = current_type;
    }

    public void SelectedSecond()
    {
        secondSelected = true; 
        bg.enabled = false;
        txts[lastText].enabled = false;
        char_type_2 = current_type;
    }

    public void Fight()
    {
        if(firstSelected && secondSelected)
        {
            selection_canvas.enabled = false;
            game_canvas.enabled = true;
            GM.SetPlayersChars(char_type_1, char_type_2, (Texture2D)player1.texture, (Texture2D)player2.texture);
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

    public void SetCharacterType(int type)
    {
        current_type = type; 
    }
}
