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
    public float productionDiffScale;
    public Quantity_Formatter quantityFormatterRef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        productionPower = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
  
    public void BuyProduction()
    {
        if (scoreManagerRef.fameAmount > productionDifficultyCount)
        {
            scoreManagerRef.fameAmount -= productionDifficultyCount;
            scoreManagerRef.listenText.text = scoreManagerRef.fameAmount.ToString("00");
            productionAmount += 1;
            productionText.text = productionAmount.ToString($"00");
            productionDifficultyCount = Mathf.RoundToInt(productionDifficultyCount * productionDiffScale);
            scoreManagerRef.addFameAmount += productionPower;
        }
    }

    //backups : 
    //quantityFormatterRef.FormateQuantity(productionAmount);
    //
    //
    //
    //
}
