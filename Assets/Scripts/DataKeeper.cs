using System.IO;
using UnityEngine;

public class DataKeeper : MonoBehaviour
{
    public static DataKeeper instance { get; private set; }

    public string playerName;
    public string bestPlayerName;
    public int BestScore;

    private void Awake()
    {
        // 싱글톤으로 데이터 유지
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        LoadBestScore(); // 게임 시작 시 최고 점수와 플레이어 이름 불러오기
    }

    // 데이터 저장 포멧
    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int bestScore;
    }


    // 게임 종료 시 최고 점수와 플레이어 이름을 저장하는 메서드
    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.bestPlayerName = bestPlayerName;
        data.bestScore = BestScore;
        
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // 게임 시작 시 최고 점수와 플레이어 이름을 불러오는 메서드
    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayerName = data.bestPlayerName;
            BestScore = data.bestScore;
        }
    }
    public void TryUpdateBestScore(int score)
    {
        if (score > BestScore)
        {
            BestScore = score;
            bestPlayerName = playerName;
            SaveBestScore();
        }
    }
}
