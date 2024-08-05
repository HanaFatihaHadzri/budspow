using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public List<GameObject> prefab_Luggage;
    public List<GameObject> prefab_Power;
    public GameObject go_LuggageSpawnPoint;
    public GameObject go_AudioContainer;
    public GameObject go_AudioSource;

    public AudioClip audioClip_Push;

    public Slider slider_ComplainBar;
    public Image image_bar;
    public Image image_circle;

    public int point_TotalLuggageSent = 0;
    public int point_TotalBadLuggageSent = 0;
    public float point_Score = 0;
    public float total_Score = 0;
    public int gate_ALuggageCount = 0;
    public int gate_BLuggageCount = 0;
    public int gate_CLuggageCount = 0;
    public int gate_DLuggageCount = 0;

    public float point_AMultiplier = 1f;
    public float point_BMultiplier = 1f;
    public float point_CMultiplier = 1f;
    public float point_DMultiplier = 1f;

    public int point_GoodExit = 100;
    public int point_BadExit = -10;

    public float speed_Conveyor = 1f;
    public float timer_SpawnDelay = 1f;

    public float meterMax = 100f;
    public float meterCur = 0f;

    // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI text_TotalLuggageSent;
    public TextMeshProUGUI text_TotalLuggageError;
    public TextMeshProUGUI text_PointScore;
    public TextMeshProUGUI text_TotalScore;

    private void Start()
    {
        // Update the text initially
        UpdateTotalLuggageSentText();
        UpdateTotalLuggageErrorText();
        UpdatePointScore();
        TotalScore();

    }

    public void AddPoint(float point)
    {
        point_Score += point;
        UpdateTotalLuggageSentText();
        UpdateTotalLuggageErrorText();
        UpdatePointScore();
        TotalScore();
    }

    public void SubtractPoint(float point)
    {
        point_Score -= Mathf.Abs(point);
        point_Score = (point_Score < 0) ? 0 : point_Score;
        UpdateTotalLuggageSentText();
        UpdateTotalLuggageErrorText();
        UpdatePointScore();
        TotalScore();
    }



    private void UpdateTotalLuggageSentText()
    {
        text_TotalLuggageSent.text = point_TotalLuggageSent.ToString();
    }

    private void UpdateTotalLuggageErrorText()
    {
        text_TotalLuggageError.text = point_TotalBadLuggageSent.ToString();
    }

    private void UpdatePointScore()
    {
        text_PointScore.text = "SCORE: " + point_Score.ToString();

    }

    private void TotalScore()
    {
        total_Score = point_Score;
        text_TotalScore.text = "TOTAL SCORE: " + total_Score.ToString();
    }

}