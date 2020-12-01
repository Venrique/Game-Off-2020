using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame(){
        GameManager.PlayIntro();
    }

    public void Continue(){
        GameManager.Continue();
    }
    
    public void MainMenuScreen(){
        GameManager.MainMenu();
    }

    public void Quit(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
