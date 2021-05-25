using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingSceneController : MonoBehaviour
{
    public static string nextScene;
    public Slider progressBar;

    public TextMeshProUGUI loadingTextUI;

    public static void LoadString(string sceneName) //�� ������ �Ķ���� �� �ޱ� ����
    {
        nextScene = sceneName;        
    }
    public static void LoadSceneString(string sceneName) //�� �ܺο��� �Ķ���� �� ���޹ޱ� ����
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
    }

    private void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while(!op.isDone)
        {
            yield return null;
            if(op.progress < 0.9f) //�ε��� ���ҽ� �δ��� ������� else �б�� �ٷ� �Ѿ.
            {
                progressBar.value = op.progress;
                loadingTextUI.text = "Loading..." + (int)(progressBar.value * 100f) + "%";
            }
            else
            {
                timer += Time.unscaledDeltaTime / 3; //�ʹ� �ݹ����� �ӵ� ���� �������� ��� ����.
                progressBar.value = Mathf.Lerp(0.9f, 1f, timer);
                loadingTextUI.text = "Loading..." + (int)(progressBar.value * 100f) + "%";

                if (progressBar.value >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
