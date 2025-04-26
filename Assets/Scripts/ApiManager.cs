using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;

[Serializable]
public class TrackAchievementInput
{
    public int userId;    // match z.number().int()
    public string name;      // one of the enum values
    public bool achieved;  // true/false
}

[Serializable]
public class UpdateStatsInput
{
    public int userId;
    public int longestSurvived;
    public int shortestSurvived;
    public int mostFood;
    public int mostMaterial;
    public int mostPower;
    public int mostPopulation;
    public int leastFood;
    public int leastMaterial;
    public int leastPower;
    public int leastPopulation;
    public int reincarnatedTimes;
    public int vaultFoundTimes;
}

public class ApiManager : MonoBehaviour
{
    const string BaseUrl = "https://your-domain.com/api/trpc";

    // 1. Track Achievement
    public void TrackAchievement(TrackAchievementInput inp, string jwt)
    {
        StartCoroutine(TrackAchievementRoutine(inp, jwt));
    }

    IEnumerator TrackAchievementRoutine(TrackAchievementInput inp, string jwt)
    {
        string url = $"{BaseUrl}/achievements.track";
        string body = JsonUtility.ToJson(new { input = inp });

        using var www = new UnityWebRequest(url, "POST")
        {
            uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body)),
            downloadHandler = new DownloadHandlerBuffer()
        };
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Authorization", $"Bearer {jwt}");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
            Debug.LogError($"Achieve Error: {www.error}");
        else
            Debug.Log("Achievement tracked!");
    }

    // 2. Update Game Stats
    public void UpdateStats(UpdateStatsInput inp, string jwt)
    {
        StartCoroutine(UpdateStatsRoutine(inp, jwt));
    }

    IEnumerator UpdateStatsRoutine(UpdateStatsInput inp, string jwt)
    {
        string url = $"{BaseUrl}/gameStats.update";
        string body = JsonUtility.ToJson(new { input = inp });

        using var www = new UnityWebRequest(url, "POST")
        {
            uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body)),
            downloadHandler = new DownloadHandlerBuffer()
        };
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Authorization", $"Bearer {jwt}");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
            Debug.LogError($"Stats Error: {www.error}");
        else
            Debug.Log("Stats updated!");
    }
}

