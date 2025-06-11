using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class JsonDataSaveLoad
{
    private const string FileName = "UserDataList.json";
    public static readonly string FilePath = Path.Combine(Application.persistentDataPath, FileName);

    public static bool SaveFileExists() => File.Exists(FilePath);

    public static void SaveJsonUserList(List<JsonUserData> userList)
    {
        var wrapper = new JsonUserDataListWrapper { jsonUsers = userList };
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(FilePath, json);
    }

    public static List<JsonUserData> LoadJsonUserList()
    {
        if (!SaveFileExists())
        {
            return new List<JsonUserData>();
        }
        
        string json = File.ReadAllText(FilePath);
        var wrapper = JsonUtility.FromJson<JsonUserDataListWrapper>(json);
        
        return wrapper.jsonUsers;
    }
    
    public static List<JsonUserData> ConvertUserDataListToJsonList(List<UserData> userDatas)
    {
        List<JsonUserData> result = new List<JsonUserData>();
        foreach (UserData user in userDatas)
        {
            result.Add(new JsonUserData(user));
        }
        return result;
    }

    public static List<UserData> ConvertJsonListToUserDataList(List<JsonUserData> jsonUserDatas)
    {
        List<UserData> result = new List<UserData>();
        foreach (JsonUserData json in jsonUserDatas)
        {
            result.Add(new UserData(json));
        }
        return result;
    }

}