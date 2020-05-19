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
    // Start is called before the first frame update
    void Start()
    {
        bg.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var ray2d = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit hit;
        RaycastHit2D hit2d = Physics2D.Raycast(ray2d, Vector2.zero);

        if(hit2d.collider != null)
        {
            Debug.Log("Enters to character");
            //var selection = hit2d.transform;

            //if (selection.CompareTag("Character"))
            //{
            //    var image = selection.GetComponent<RawImage>();
            //    player1.texture = image.texture;
            //}
        }


        //if (Physics2D.Raycast(ray2d, Vector2.zero))
        //{
        //    Debug.Log("Detected GameObject");
        //    var selection = hit.transform;
        //    if(selection.CompareTag("Character"))
        //    {
        //        Debug.Log("Enters to character");
        //        var image = selection.GetComponent<RawImage>();
        //        player1.texture = image.texture;

        //    }
        //}
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
            Debug.Log("Enter to Drunking arena");
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
