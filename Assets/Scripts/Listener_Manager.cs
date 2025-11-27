using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Listener_Manager : MonoBehaviour
{
    public int listenerAmount;
    public TextMeshProUGUI listenerText;
    public int listenerDifficultyCount;
    public int listenerPower;
    public ScoreManager scoreManagerRef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        listenerDifficultyCount = 1;
        listenerPower = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void buyListener()
    {
        if (scoreManagerRef.fameAmount > listenerDifficultyCount)
        {
            scoreManagerRef.fameAmount -= listenerDifficultyCount;
            scoreManagerRef.listenText.text = scoreManagerRef.fameAmount.ToString("00");
            listenerAmount += 1;
            listenerText.text = listenerAmount.ToString("00");
            listenerDifficultyCount = Mathf.RoundToInt(listenerDifficultyCount * 2.5f);
            scoreManagerRef.addFameAmount += listenerPower;
        }
    }
}
