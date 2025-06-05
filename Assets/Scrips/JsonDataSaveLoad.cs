using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public static class JsonDataSaveLoad
{
    private const string FileName = "JsonUserData.json";
    
    // 모든 저장·불러오기에서 공통으로 쓸 경로
    public static readonly string FilePath =
        Path.Combine(Application.persistentDataPath, FileName);

    public static bool SaveFileExists()
    {
        // 파일 존재 여부만 반환
        return File.Exists(FilePath);
    }

    public static void SaveUserDataToJson(JsonUserData userData)
    {
        string jsonData = JsonUtility.ToJson(userData, true);
        File.WriteAllText(FilePath, jsonData);
    }

    public static void LoadUserDataFromJson(UserData userData)
    {
        if (!File.Exists(FilePath))
        {
            Debug.LogWarning($"저장 파일이 없어 기본 값으로 시작합니다: {FilePath}");
            return;   // 또는 여기서 기본 데이터를 만들어 저장해도 됩니다.
        }

        string jsonData = File.ReadAllText(FilePath);
        JsonUserData jsonUserData = JsonUtility.FromJson<JsonUserData>(jsonData);
        jsonUserData.Load(userData);
    }
}