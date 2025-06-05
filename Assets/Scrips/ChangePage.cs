using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ChangePage : MonoBehaviour
{
    public Image backGround;
    public Color mainColor;
    public Color depositColor;
    public Color withdrawalColor;
    public Color loginPageColor;
    public Color singUpColor;

    public GameObject mainPage;
    public GameObject depositPage;
    public GameObject withdrawalPage;
    public GameObject userInfoAndCashPage;
    public GameObject loginPage;
    public GameObject singUpPage;

    public GameObject popUpPage;
    public TextMeshProUGUI popUpText;

    private GameManager _gameManager;

    public void Start()
    {
        _gameManager = GameManager.Instance;
        _gameManager.changePage = this;

        popUpPage.SetActive(false);
    }

    public void OnMain()
    {
        backGround.color = mainColor;
        userInfoAndCashPage.SetActive(true);
        mainPage.SetActive(true);
        depositPage.SetActive(false);
        withdrawalPage.SetActive(false);
        loginPage.SetActive(false);
        singUpPage.SetActive(false);
    }

    public void OnDeposit()
    {
        backGround.color = depositColor;
        userInfoAndCashPage.SetActive(true);
        depositPage.SetActive(true);
        withdrawalPage.SetActive(false);
        mainPage.SetActive(false);
        loginPage.SetActive(false);
        singUpPage.SetActive(false);
    }

    public void OnWithdrawal()
    {
        backGround.color = withdrawalColor;
        userInfoAndCashPage.SetActive(true);
        withdrawalPage.SetActive(true);
        mainPage.SetActive(false);
        depositPage.SetActive(false);
        loginPage.SetActive(false);
        singUpPage.SetActive(false);
    }

    public void OnLogin()
    {
        backGround.color = loginPageColor;
        loginPage.SetActive(true);
        userInfoAndCashPage.SetActive(false);
        mainPage.SetActive(false);
        depositPage.SetActive(false);
        withdrawalPage.SetActive(false);
        singUpPage.SetActive(false);
    }

    public void OnSignUp()
    {
        backGround.color = singUpColor;
        singUpPage.SetActive(true);
        loginPage.SetActive(false);
        userInfoAndCashPage.SetActive(false);
        mainPage.SetActive(false);
        depositPage.SetActive(false);
        withdrawalPage.SetActive(false);
    }

    public void OnPopUp(string msg)
    {
        popUpText.text = msg;
        popUpPage.SetActive(true);
    }

    public void ClosePopUp()
    {
        popUpPage.SetActive(false);
    }
}