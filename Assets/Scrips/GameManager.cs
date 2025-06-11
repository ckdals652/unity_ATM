using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.IO;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get { return instance; }
    }
    
    public ChangePage changePage;
    public LoginAndSignUp loginAndSignUp;

    [Header("UserInfo")] 
    public UserData userData;
    public List<UserData> userDataList;

    [Header("RefreshText")] 
    public TextMeshProUGUI currentName;
    public TextMeshProUGUI currentCash;
    public TextMeshProUGUI currentBalance;

    public void Awake()
    {
        // 싱글턴 초기화
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 유지하고 싶다면
        }
        else if (instance != this)
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    public void Start()
    { 
        userDataList = JsonDataSaveLoad.ConvertJsonListToUserDataList
            (JsonDataSaveLoad.LoadJsonUserList());
        changePage.OnLogin();
    }
    
    public void Refresh()
    {
        currentName.text = userData.userName;
        currentCash.text = userData.cash.ToString();
        currentBalance.text = "Balance : " + userData.bankAccountBalance;
    }
}