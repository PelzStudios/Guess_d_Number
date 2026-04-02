using UnityEngine;

public class RandomNumberSelector : MonoBehaviour
{
    public int minValue = 0;
    public int maxValue = 100;
    public int selectedNumber;

    void SelectRandomNumber()
    {
        selectedNumber = Random.Range(minValue, maxValue);
    }

    void Start()
    {
        SelectRandomNumber(); // how would it then repeat each game session?
    }

    void Update()
    {
        
    }
}
