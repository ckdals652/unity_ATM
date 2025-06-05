using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputCash : MonoBehaviour
{
    private GameManager _gameManager;
    
    private List<UserData> _userDataList;

    private int inputNum;

    public TMP_InputField inputDepositText;
    public TMP_InputField inputWithdrawalText;


    public void Start()
    {
        _gameManager = GameManager.Instance;
        
        _userDataList = _gameManager.userDataList;
    }

    public void OnDeposit(int money)
    {
        if (money >= 0 && money <= _gameManager.userData.cash)
        {
            _gameManager.userData.cash -= money;
            _gameManager.userData.bankAccountBalance += money;

            JsonDataSaveLoad.SaveJsonUserList
                (JsonDataSaveLoad.ConvertUserDataListToJsonList(_userDataList));
        }
        else
        {
            _gameManager.changePage.OnPopUp("입금할 금액이 모자랍니다.");
        }

        _gameManager.Refresh();
    }

    public void OnWithdrawal(int money)
    {
        if (money >= 0 && money <= _gameManager.userData.bankAccountBalance)
        {
            _gameManager.userData.cash += money;
            _gameManager.userData.bankAccountBalance -= money;

            JsonDataSaveLoad.SaveJsonUserList
                (JsonDataSaveLoad.ConvertUserDataListToJsonList(_userDataList));
        }
        else
        {
            _gameManager.changePage.OnPopUp("출금 할 금액이 모자랍니다.");
        }

        _gameManager.Refresh();
    }

    public void OnCostomDeposit()
    {
        if (int.TryParse(inputDepositText.text, out inputNum))
        {
            if (inputNum <= _gameManager.userData.cash)
            {
                OnDeposit(inputNum);
            }
            else
            {
                //입금하려 한 금액이 지닌 돈 보다 작다고 팝업 띄우기
                _gameManager.changePage.OnPopUp("입금할 금액이 모자랍니다.");
            }
        }
        else
        {
            //입력한 게 숫자가 아니라고 띄우기
            _gameManager.changePage.OnPopUp("입력한 문자가 수가 아닙니다.");
        }
    }

    public void OnCostomWithdrawal()
    {
        if (int.TryParse(inputWithdrawalText.text, out inputNum))
        {
            if (inputNum <= _gameManager.userData.bankAccountBalance)
            {
                OnWithdrawal(inputNum);
            }
            else
            {
                //출금하려 한 금액이 은행 잔고 보다 작다고 팝업 띄우기
                _gameManager.changePage.OnPopUp("출금할 금액이 모자랍니다.");
            }
        }
        else
        {
            //입력한 게 숫자가 아니라고 띄우기
            _gameManager.changePage.OnPopUp("입력한 문자가 수가 아닙니다.");
        }
    }
}