using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private InterfaceControll _Interface;
    [SerializeField] private PlayerControll _PlayerControll;

    private int CoinsCount;
    
    public InterfaceControll Interface => _Interface;
    public PlayerControll PlayerControll => _PlayerControll;


    private void Start()
    {
        CoinsCount = 0;
    }

    public bool TryDiscard(int price)
    {
        if (CoinsCount < price)
            return false;
        CoinsCount -= price;
        _Interface.UpdateValue();

        return true;
    }

    public int GetCoins()
    {
        return CoinsCount;
    }

    public bool SetCoins (int value)
    {
        if (value > 0xf423f)
        {
            return false;
        }
        CoinsCount = value;
        Interface.UpdateValue();
        return true;
    }
}
