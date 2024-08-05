using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    Slider slider;
    Image bar;
    Image knob;

    //hana add
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    private bool isGameOver = false;

    private void Awake(){
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }

        
    }

    public void Start(){
        slider = GameManager.Instance.slider_ComplainBar;
        bar = GameManager.Instance.image_bar;
        knob = GameManager.Instance.image_circle;
        InitSlider();
        ChangeSliderColor();

        //hana add
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    public void InitSlider(){
        slider.maxValue = GameManager.Instance.meterMax;
        slider.minValue = 0f;
        slider.value = GameManager.Instance.meterMax;
        GameManager.Instance.meterCur = GameManager.Instance.meterMax;
    }

    public void AddValue(float val){
        GameManager.Instance.meterCur += val;
        slider.value += val;
        ChangeSliderColor();

        //check win condition here // hana!
        if(slider.value <= 0)
        {
            //game over screen display here
            GameOverPanel();
        }
    }

    private void ChangeSliderColor(){
        if(slider.value >= slider.maxValue * .75f){
            bar.color = Color.green;
            knob.color = Color.green;
        }else if(slider.value < slider.maxValue * .75f && slider.value >= slider.maxValue * .35f){
            bar.color = Color.yellow;
            knob.color = Color.yellow;
        }else{
            bar.color = Color.red;
            knob.color = Color.red;
        }
    }

    // hana add
    private void GameOverPanel()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Time.timeScale = 0f; //pause game until player click on restart button
            gameOverPanel.SetActive(true);

        }

    }

    public void PausePanel()
    {
        
            isGameOver = false;
            Time.timeScale = 0f; //pause game until player click on restart button
            pausePanel.SetActive(true);

        

    }

    //function to be used by Restart button inside Game Over panel
    public void RestartGame()
    {
        Time.timeScale = 1f; //resume game 
        isGameOver = false;
        gameOverPanel.SetActive(false);

        //reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //function to be used by Main Menu Button inside Game Over panel
    public void BackToMenu()
    {
        Time.timeScale = 1f; //resume game 
        isGameOver = false;
        gameOverPanel.SetActive(false);

        SceneManager.LoadScene("Menu");
    }

    public void ReturnToGame() 
    {
        pausePanel.SetActive(false);
        isGameOver=false;
        Time.timeScale = 1f;
    }
}


