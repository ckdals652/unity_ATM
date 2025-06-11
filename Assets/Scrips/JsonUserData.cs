using System;
using System.Collections.Generic;

[Serializable]
public class JsonUserData
{
    public string userName;
    public int cash;
    public int bankAccountBalance;
    public string id;
    public string password;

    public JsonUserData(UserData userData)
    {
        userName = userData.userName;
        cash = userData.cash;
        bankAccountBalance = userData.bankAccountBalance;
        id = userData.id;
        password = userData.password;
    }

    public void UserDataToJsonData(UserData userData)
    {
        userName = userData.userName;
        cash = userData.cash;
        bankAccountBalance = userData.bankAccountBalance;
        id = userData.id;
        password = userData.password;
    }

    public void JsonDataToUserData(UserData userData)
    {
        userData.userName = userName;
        userData.cash = cash;
        userData.bankAccountBalance = bankAccountBalance;
        userData.id = id;
        userData.password = password;
    }
}

[Serializable]
public class JsonUserDataListWrapper
{
    public List<JsonUserData> jsonUsers = new();
}