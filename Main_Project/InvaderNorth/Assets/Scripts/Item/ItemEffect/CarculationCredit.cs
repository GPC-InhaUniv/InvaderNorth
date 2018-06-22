using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculationCredit : MonoBehaviour
{
    delegate int SendGetCredit(int Count, int Amount);
    static SendGetCredit sendGetCredit;

    private int DarkResourceCount;
    private int DarkResourceAmount;

    private void Awake()
    {
        DarkResourceCount = 10;
        DarkResourceAmount = 0;
        sendGetCredit = AddAmount;
    }

    private int AddAmount(int Count, int Amount)
    {
        int result = Amount + Count;
        return result;
    }
}
