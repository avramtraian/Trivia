using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public QuestionManager[] m_QuestionManagers = new QuestionManager[2];

    private bool m_CanRandomizeQuestion = true;

    void Start()
    {
        if (m_CanRandomizeQuestion)
        {
            for (int i = 0; i < m_QuestionManagers.Length; i++)
            {
                m_QuestionManagers[i].RandomizeQuestion();
            }
        }
    }

    void Update()
    {
        bool reference = true;
        for(int i = 0; i < m_QuestionManagers.Length; i++)
        {
            if(!m_QuestionManagers[i].HasAnswered())
            {
                reference = false;
                break;
            }
        }
        if(reference && m_CanRandomizeQuestion)
        {
            // Validate answers
            for(int i = 0; i < m_QuestionManagers.Length; i++)
            {
                m_QuestionManagers[i].ValidateAnswer();
            }

            m_CanRandomizeQuestion = false;
            IEnumerator coroutine = WaitAndReset(3.0f);
            StartCoroutine(coroutine);
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
        for (int i = 0; i < m_QuestionManagers.Length; i++)
        {
            m_QuestionManagers[i].RandomizeQuestion();
        }
    }
}