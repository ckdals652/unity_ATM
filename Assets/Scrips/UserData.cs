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

    public string id;
    public string password;

    public UserData(string _userName, int _cash, int _bankAccountBalance, 
        string _id, string _password)
    {
        userName = _userName;
        cash = _cash;
        bankAccountBalance = _bankAccountBalance;
        id = _id;
        password = _password;
    }
    
    public UserData(JsonUserData json)
    {
        userName = json.userName;
        cash = json.cash;
        bankAccountBalance = json.bankAccountBalance;
        id = json.id;
        password = json.password;
    }
}
