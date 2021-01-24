using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Player m_Player;
    public TextMeshProUGUI m_Text;

    public void UpdateText()
    {
        m_Text.text = m_Player.GetScore().ToString();
    }
}