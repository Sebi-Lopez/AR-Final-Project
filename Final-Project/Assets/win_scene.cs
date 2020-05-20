using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class win_scene : MonoBehaviour
{
    // Start is called before the first frame update
    public string name;
    public string tex_name;
    private Texture2D tex;
    public RawImage img;
    public Text text;
    void Start()
    {
        name = PlayerPrefs.GetString("Name");
        tex_name = PlayerPrefs.GetString("TexName");

       tex =  Resources.Load(tex_name) as Texture2D;

        img.texture = tex;
        text.text = name;
      
        
        
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Sebi_Scene", LoadSceneMode.Single);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
