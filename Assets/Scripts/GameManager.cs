using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public QuestionManager[] m_QuestionManagers = new QuestionManager[2];
    public Player[] m_Players = new Player[2];

    // The rounds that has been played since now
    public int m_RoundsCount = 0;
    // The total rounds a game has
    public int m_Rounds = 20;

    public bool m_IsOver = false;
    public EndScreen m_EndScreen;

    private bool m_CanRandomizeQuestion = true;

    void Start()
    {
        if (m_CanRandomizeQuestion)
        {
            for (int i = 0; i < m_QuestionManagers.Length; i++)
            {
                m_QuestionManagers[i].RandomizeQuestion();
            }
            m_RoundsCount++;
        }
    }

    void Update()
    {
        if (!m_IsOver)
        {
            bool reference = true;
            for (int i = 0; i < m_QuestionManagers.Length; i++)
            {
                if (!m_QuestionManagers[i].HasAnswered())
                {
                    reference = false;
                    break;
                }
            }
            if (reference && m_CanRandomizeQuestion)
            {
                // Validate answers
                for (int i = 0; i < m_QuestionManagers.Length; i++)
                {
                    m_QuestionManagers[i].ValidateAnswer();
                }

                m_CanRandomizeQuestion = false;
                IEnumerator coroutine = WaitAndReset(3.0f);
                StartCoroutine(coroutine);
            }
        }
    }

    private IEnumerator WaitAndReset(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
        for (int i = 0; i < m_QuestionManagers.Length; i++)
            m_QuestionManagers[i].OnReset();

        m_CanRandomizeQuestion = true;
        NextQuestion();
    }

    private void NextQuestion()
    {
        if (!m_IsOver)
        {
            if (m_RoundsCount == m_Rounds)
            {
                m_IsOver = true;
                m_EndScreen.SetVisible(true);
                for (int i = 0; i < m_QuestionManagers.Length; i++)
                    m_QuestionManagers[i].OnOver();
                return;
            }
            for (int i = 0; i < m_QuestionManagers.Length; i++)
            {
                m_QuestionManagers[i].RandomizeQuestion();
            }
            m_RoundsCount++;
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void FormatText(TextMeshProUGUI upText, TextMeshProUGUI downText)
    {
        // HARD CODED!
        if (m_Players[0].GetScore() > m_Players[1].GetScore())
        {
            upText.text = "Jucatorul 1 a castigat cu o diferenta de " + (m_Players[0].GetScore() - m_Players[1].GetScore()).ToString() + " puncte!";
            downText.text = "Felicitari! Ai fost mai atent la orele online decat adversarul tau!";
        }
        else if (m_Players[1].GetScore() > m_Players[0].GetScore())
        {
            upText.text = "Jucatorul 2 a castigat cu o diferenta de " + (m_Players[1].GetScore() - m_Players[0].GetScore()).ToString() + " puncte!";
            downText.text = "Felicitari! Ai fost mai atent la orele online decat adversarul tau!";
        }
        else
        {
            upText.text = "Scorul este... Egal!";
            downText.text = "Felicitari! Amandoi ati fost la fel de atenti la orele online!";
        }
    }
}