using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginAndSignUp : MonoBehaviour
{
    private GameManager _gameManager;
    private List<UserData> _userDataList;

    public TMP_InputField loginID;
    public TMP_InputField loginPassword;
    private string _loginIDText;
    private string _loginPwText;


    public TMP_InputField signUpName;
    public TMP_InputField signUpID;
    public TMP_InputField signUpPassword;
    private string _signUpNameText;
    private string _signUpIdText;
    private string _signUpPwText;

    void Start()
    {
        _gameManager = GameManager.Instance;
        _gameManager.loginAndSignUp = this;
        
        _userDataList = _gameManager.userDataList;
    }

    public void UpdateSignUp()
    {
        _signUpNameText = signUpName.text;
        _signUpIdText = signUpID.text;
        _signUpPwText = signUpPassword.text;
    }    
    
    public void UpdateLogin()
    {
        _loginIDText = loginID.text;
        _loginPwText = loginPassword.text;
    }

    public void LoginButton()
    {
        UpdateLogin();
        
        var match = _userDataList.Find
            (u => u.id == _loginIDText && u.password == _loginPwText);

        if (match != null)
        {
            _gameManager.userData = match;
            _gameManager.changePage.OnMain();
            _gameManager.Refresh();
        }
        else
        {
            // 로그인 실패 팝업
            _gameManager.changePage.OnPopUp("ID 혹은 비밀번호가 틀렸습니다");
        }
    }

    public void SignUpButton()
    {
        UpdateSignUp();
        
        if (string.IsNullOrWhiteSpace(_signUpIdText) ||
            string.IsNullOrWhiteSpace(_signUpPwText) ||
            string.IsNullOrWhiteSpace(_signUpNameText))
        {
            _gameManager.changePage.OnPopUp("모든 항목을 입력해주세요.");
            return;
        }

        if (_userDataList.Exists(u => u.id == _signUpIdText))
        {
            _gameManager.changePage.OnPopUp("아이디가 이미 존재합니다.");
            return;
        }

        var newUser = new UserData
            (_signUpNameText, 1000000, 0, _signUpIdText, _signUpPwText);

        _userDataList.Add(newUser);

        JsonDataSaveLoad.SaveJsonUserList
            (JsonDataSaveLoad.ConvertUserDataListToJsonList(_userDataList));
        
        _gameManager.changePage.OnPopUp("로그인 화면에서 로그인 해주세요");

        _gameManager.changePage.OnLogin();
    }
}