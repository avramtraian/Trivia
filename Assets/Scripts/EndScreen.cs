using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public GameObject itself;

    public GameManager m_GameManager;
    public TextMeshProUGUI m_UpText, m_DownText;

    public void SetVisible(bool visible)
    {
        itself.SetActive(visible);
        m_GameManager.FormatText(m_UpText, m_DownText);
    }
}