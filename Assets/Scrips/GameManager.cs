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

    [Header("UserInfo")] 
    public UserData userData;
    public JsonUserData jsonUserData;

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
        Debug.Log(JsonDataSaveLoad.FilePath);
        if (JsonDataSaveLoad.SaveFileExists())
        {
            JsonDataSaveLoad.LoadUserDataFromJson(userData);
        }
        else
        {
            userData = new UserData("임창민", 1000000, 1000000);
            // 첫 실행: 기본 데이터 생성 → 저장
            jsonUserData = new JsonUserData(userData); // 원하는 초기값 넣기
            JsonDataSaveLoad.SaveUserDataToJson(jsonUserData);
            jsonUserData.Load(userData);
        }
        
        Refresh();
        changePage.OnMain();
    }

    public void Refresh()
    {
        currentName.text = userData.userName;
        currentCash.text = userData.cash.ToString();
        currentBalance.text = "Balance : " + userData.bankAccountBalance;
    }
}