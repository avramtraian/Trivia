using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public QuestionManager m_QuestionManager;
    public GameManager m_GameManager;

    public Slider m_ScoreSlider;
    public ScoreText m_ScoreText;

    public int m_Score = 50;

    public void Start()
    {
        UpdateSlider();
    }

    public int GetScore()
    {
        return m_Score;
    }
    public void AddScore(int value)
    { 
        if(value != 0)
            m_Score += value;
        UpdateSlider();

    }

    private void UpdateSlider()
    {
        m_ScoreSlider.value = m_Score;
        m_ScoreText.UpdateText();
    }
}