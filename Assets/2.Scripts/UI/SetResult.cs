using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetResult : MonoBehaviour
{
    public TextMeshProUGUI highestStageText;
    public TextMeshProUGUI highestScoreText;
    public TextMeshProUGUI stageText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    public GameObject newScore;
    public GameObject newStage;

    private AreaSpawner areaSpawner;
    private Player player;
    private DataManager data;
    private int score;
    private int stage;

    void OnEnable()     //������Ʈ Ȱ��ȭ��
    {
        areaSpawner = GameObject.Find("AreaSpawner").GetComponent<AreaSpawner>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        data = GameObject.Find("DataManager").GetComponent<DataManager>();

        setText();

        //������ ������Ʈ
        data.RankUpdate(score, stage);
        data.coinUpdate(player.coin);
        data.expUpdate((int)score / 100);
    }

    void setText()      //�ؽ�Ʈ ����
    {
        bool isNewScore, isNewStage;        //�ű�� �Ǻ�
        isNewScore = (player.score > data.getHighScore()) ? true : false;
        isNewStage = (areaSpawner.stage > data.getHighStage()) ? true : false;

        score = (player.score > data.getHighScore()) ? player.score : data.getHighScore();      //�ű�� �Ǻ��Ͽ� �� �Ҵ�
        stage = (areaSpawner.stage > data.getHighStage()) ? areaSpawner.stage : data.getHighStage();

        if (!isNewScore)            //�ű������ �ƴ��� �Ǻ��Ͽ� NEW �̹��� Ȱ��ȭ
            newScore.SetActive(false);
        if (!isNewStage)
            newStage.SetActive(false);

        //text �ʱ�ȭ
        highestStageText.text = stage.ToString();
        highestScoreText.text = score.ToString();
        stageText.text = areaSpawner.stage.ToString();
        scoreText.text = player.score.ToString();
        coinText.text = player.coin.ToString();
    }
}
