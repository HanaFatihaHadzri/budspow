using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public Canvas canvas_Credit;
    public Canvas canvas_Quit;

    private void Start(){
      canvas_Credit.enabled = false;
    }

    public void ChangeScene(int index){
        SceneManager.LoadScene(index);
    }

    public void ToCredit(){
        canvas_Credit.enabled = true;
      
    }

    public void ToQuit()
    {
        // If we are running in the editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If we are running in a standalone build of the game
        Application.Quit();
#endif
    }
}
