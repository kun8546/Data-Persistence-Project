using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField NameInput;
    public TextMeshProUGUI BestScoreText;

    // start()에 최고 점수 플레이어 이름과 점수 불러오기
    private void Start()
    {
        if (DataKeeper.instance.bestPlayerName == null)
        {
            BestScoreText.text = "Best Score : : 0";

        }
        else
        {
            BestScoreText.text = "Best Score : " + DataKeeper.instance.bestPlayerName + " : " + DataKeeper.instance.BestScore;
        }
    }

    // StartNew()
    // 이름 저장하고
    // 메인 씬 불러오기
    public void StartNew()
    {
        DataKeeper.instance.playerName = NameInput.text;
        SceneManager.LoadScene(1);
    }

    // Exit()
    // 빌드인지 테스트인지 분류해서 종료
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
