using UnityEngine;

public class RandomNumberSelector : MonoBehaviour
{
    private int minValue = 0;
    private int maxValue = 100;
    public int selectedNumber;

    
    // select random number between min and max value
    // store selected number

    public void SelectRandomNumber()
    {
        selectedNumber = Random.Range(minValue, maxValue);
    }
    
}
