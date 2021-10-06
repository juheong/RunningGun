using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageClear : MonoBehaviour
{
    public Image img;
    public TextMeshProUGUI text1, text2;
    private TextMeshProUGUI StageInfo;
    private AreaSpawner areaSpawner;

    Color init_color;
    bool fade;
    // Start is called before the first frame update
    void OnEnable()
    {
        areaSpawner = GameObject.Find("AreaSpawner").GetComponent<AreaSpawner>();       //�������� �� ����� ���� AreaSpawner ��ũ��Ʈ

        StageInfo = GameObject.Find("Text_Number").GetComponent<TextMeshProUGUI>();     //���� ��� �������� �� ������ ���� �ؽ�Ʈ

        init_color = new Color(1, 1, 1, 0);
        fade = false;

        img.color = init_color;
        text2.text = (areaSpawner.stage).ToString();
        text1.color = init_color;
        text2.color = init_color;
        text2.text = areaSpawner.stage.ToString();       //AreaSpawner�� Ŭ���� �� �ݿ�
        StageInfo.text = areaSpawner.stage.ToString();
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        if (fade == true)
        {
            StartCoroutine(FadeOut());
        }

        //img.color = Color.Lerp(init_color, new_color, Time.deltaTime * 2f);
        //Vector2.Lerp(init_color.a, new_color.a, 0.25f);  Mathf.PingPong(Time.time, 5.5f) Mathf.PingPong(Time.time, 1f)
    }

    IEnumerator FadeIn()
    {
        float fadeCount = 0;
        while(fadeCount < 1.0f)
        {
            fadeCount += 0.02f;
            yield return new WaitForSeconds(0.01f);
            img.color = new Color(1, 1, 1, fadeCount);
            text1.color = new Color(1, 1, 1, fadeCount);
            text2.color = new Color(1, 1, 1, fadeCount);
        }

        if (fadeCount >= 1.0f) 
        {
            yield return new WaitForSeconds(2.0f);
            fade = true;
        }
        
    }

    IEnumerator FadeOut()
    {
        float fadeCount = 1;
        while (fadeCount > 0.02f)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.01f);
            img.color = new Color(1, 1, 1, fadeCount);
            text1.color = new Color(1, 1, 1, fadeCount);
            text2.color = new Color(1, 1, 1, fadeCount);
        }

        if (fadeCount <= 0.02f)
            this.gameObject.SetActive(false);
    }
}
