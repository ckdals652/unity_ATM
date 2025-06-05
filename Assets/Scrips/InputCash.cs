using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputCash : MonoBehaviour
{
    private GameManager _gameManager;
    private UserData _userData;
    private JsonUserData _jsonUserData;

    private int inputNum;

    public TMP_InputField inputDepositText;
    public TMP_InputField inputWithdrawalText;


    public void Start()
    {
        _gameManager = GameManager.Instance;
        _userData = _gameManager.userData;
        _jsonUserData = _gameManager.jsonUserData;
    }

    public void OnDeposit(int money)
    {
        if (money >= 0 && money <= _userData.cash)
        {
            _userData.cash -= money;
            _userData.bankAccountBalance += money;
            _jsonUserData.Save(_userData);
            JsonDataSaveLoad.SaveUserDataToJson(_jsonUserData);
        }

        _gameManager.Refresh();
    }

    public void OnWithdrawal(int money)
    {
        if (money >= 0 && money <= _userData.bankAccountBalance)
        {
            _userData.cash += money;
            _userData.bankAccountBalance -= money;
            _jsonUserData.Save(_userData);
            JsonDataSaveLoad.SaveUserDataToJson(_jsonUserData);
        }

        _gameManager.Refresh();
    }

    public void OnCostomDeposit()
    {
        if (int.TryParse(inputDepositText.text, out inputNum))
        {
            if (inputNum <= _userData.cash)
            {
                OnDeposit(inputNum);
            }
            else
            {
                //입금하려 한 금액이 지닌 돈 보다 작다고 팝업 띄우기
            }
        }
        else
        {
            //입력한 게 숫자가 아니라고 띄우기
        }
    }

    public void OnCostomWithdrawal()
    {
        if (int.TryParse(inputWithdrawalText.text, out inputNum))
        {
            if (inputNum <= _userData.bankAccountBalance)
            {
                OnWithdrawal(inputNum);
            }
            else
            {
                //출금하려 한 금액이 은행 잔고 보다 작다고 팝업 띄우기
            }
        }
        else
        {
            //입력한 게 숫자가 아니라고 띄우기
        }
    }
}