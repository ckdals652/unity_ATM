using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class UserData
{
    public string userName;
    public int cash;
    public int bankAccountBalance;

    public UserData(string _userName, int _cash, int _bankAccountBalance)
    {
        userName = _userName;
        cash = _cash;
        bankAccountBalance = _bankAccountBalance;
    }
}
