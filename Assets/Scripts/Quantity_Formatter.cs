using UnityEngine;

public class Quantity_Formatter : MonoBehaviour
{
    private static readonly string[] quantityName =
    {
        "oui", "Mille", "Million","Milliard","Billion","Billiard", "Trillion", "Trilliard", "Quadrillion", "Quadrilliard", "Quintillion", "Quintilliard", "Sextillion", "Sextilliard", "Septillion", "Septilliard", "Octillion", "Octilliard", "Nonillion", "Nonilliard"

    };

    public string FormateQuantity(int quantity)
    {
        if (quantity < 1000)
        {
            return quantity.ToString("0.##");
        }
        int suffixIndex = 0;

        while (suffixIndex >= 1000 && suffixIndex < quantityName.Length - 1 )
        {
            quantity /= 1000;
            suffixIndex++;
        }

        return quantity.ToString("0.##");
    }



}
