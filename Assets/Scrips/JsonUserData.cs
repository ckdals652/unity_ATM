using System;

[Serializable]
public class JsonUserData
{
    public string userName;
    public int cash;
    public int bankAccountBalance;

    public JsonUserData(UserData userData)
    {
        userName = userData.userName;
        cash = userData.cash;
        bankAccountBalance = userData.bankAccountBalance;
    }
    
    public void Save(UserData userData)
    {
        this.userName = userData.userName;
        this.cash = userData.cash;
        this.bankAccountBalance = userData.bankAccountBalance;
    }

    public void Load(UserData userData)
    {
        userData.userName = this.userName;
        userData.cash = this.cash;
        userData.bankAccountBalance = this.bankAccountBalance;
    }
}