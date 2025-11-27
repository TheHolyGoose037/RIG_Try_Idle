using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Production_Manager : MonoBehaviour
{
    public int productionAmount;
    public TextMeshProUGUI productionText;
    public int productionDifficultyCount;
    public int productionPower;
    public ScoreManager scoreManagerRef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        productionDifficultyCount = 1;
        productionPower = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void buyProduction()
    {
        if (scoreManagerRef.fameAmount > productionDifficultyCount)
        {
            scoreManagerRef.fameAmount -= productionDifficultyCount;
            scoreManagerRef.listenText.text = scoreManagerRef.fameAmount.ToString("00");
            productionAmount += 1;
            productionText.text = productionAmount.ToString("00");
            productionDifficultyCount = Mathf.RoundToInt(productionDifficultyCount * 2.5f);
            scoreManagerRef.addFameAmount += productionPower;
        }
    }
}
