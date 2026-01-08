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
    public Image productionSpriteRef;
    public GameObject textsContainerRef;
    public TextMeshProUGUI costText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        productionSpriteRef.color = Color.black;
        textsContainerRef.SetActive(false);
        productionPower = 1;
        scoreManagerRef.eventProductionAdd = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreManagerRef.fameAmount > (productionDifficultyCount/2))
        {
            UnlockProduction();
        }
        costText.text = productionDifficultyCount.ToString($"Coute : 00 pts");
    }
  
    public void BuyProduction()
    {
        if (scoreManagerRef.fameAmount > (productionDifficultyCount * scoreManagerRef.eventProductionAdd))
        {
            scoreManagerRef.fameAmount -= Mathf.RoundToInt(productionDifficultyCount * scoreManagerRef.eventProductionAdd);
            scoreManagerRef.listenText.text = scoreManagerRef.fameAmount.ToString("00");
            productionAmount += 1;
            productionText.text = productionAmount.ToString($"00");
            productionDifficultyCount = Mathf.RoundToInt(productionDifficultyCount * productionDiffScale);
            scoreManagerRef.addFameAmount += productionPower;
        }
    }

    private void UnlockProduction()
    {
        productionSpriteRef.color = Color.white;
        textsContainerRef.SetActive(true);
    }

    //backups : 
    //quantityFormatterRef.FormateQuantity(productionAmount);
    //
    //
    //
    //
}
