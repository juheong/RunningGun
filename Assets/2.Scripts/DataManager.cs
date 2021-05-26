using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using TMPro;


public class DataManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textName;
    [SerializeField]
    private TextMeshProUGUI textLevel;
    [SerializeField]
    private TextMeshProUGUI textCoin;
    DataSet dataset;

    public void InsertData()
    {

        int charLevel = 1;
        int charExp = 0;
        int charScore = 0;
        int charCoin = 100;
        // Param�� �ڳ� ������ ����� �� �� �Ѱ��ִ� �Ķ���� Ŭ���� �Դϴ�. 
        Param param = new Param();
        param.Add("Lv", charLevel);
        param.Add("Exp", charExp);
        param.Add("Score", charScore);
        param.Add("Coin", charCoin);

        // ���� Dictionary �� ����ϱ�
        bool[] equipment = { true, true, true, true, true, true };

        param.Add("Equip", equipment);

        BackendReturnObject BRO = Backend.GameData.Insert("User", param);

        if (BRO.IsSuccess())
        {
            Debug.Log("indate : " + BRO.GetInDate());
        }
        else
        {
            switch (BRO.GetStatusCode())
            {
                case "404":
                    Debug.Log("�������� �ʴ� tableName�� ���");
                    break;

                case "412":
                    Debug.Log("��Ȱ��ȭ �� tableName�� ���");
                    break;

                case "413":
                    Debug.Log("�ϳ��� row( column���� ���� )�� 400KB�� �Ѵ� ���");
                    break;

                default:
                    Debug.Log("���� ���� ���� �߻�: " + BRO.GetMessage());
                    break;
            }
        }
    }

    public void ReadData()
    {
        var bro = Backend.GameData.GetMyData("User", new Where(), 10);        
        if (bro.IsSuccess() == false)
        {
            // ��û ���� ó��
            Debug.Log(bro);
            return;
        }
        if (bro.GetReturnValuetoJSON()["rows"].Count <= 0)
        {
            // ��û�� �����ص� where ���ǿ� �����ϴ� �����Ͱ� ���� �� �ֱ� ������
            // �����Ͱ� �����ϴ��� Ȯ��
            // ���� ���� new Where() ������ ��� ���̺� row�� �ϳ��� ������ Count�� 0 ���� �� �� �ִ�.
            Debug.Log(bro);
            return;
        }
        // �˻��� �������� ��� row�� inDate �� Ȯ��
        for (int i = 0; i < bro.Rows().Count; ++i)
        {
            var level = bro.Rows()[i]["Lv"]["N"].ToString();
            var exp = bro.Rows()[i]["Exp"]["N"].ToString();
            var score = bro.Rows()[i]["Score"]["N"].ToString(); 
            var coin = bro.Rows()[i]["Coin"]["N"].ToString();
            var weapon1 = bro.GetFlattenJSON()["rows"][0]["Equip"][0].ToString();
            var weapon2 = bro.GetFlattenJSON()["rows"][0]["Equip"][1].ToString();
            var weapon3 = bro.GetFlattenJSON()["rows"][0]["Equip"][2].ToString();
            var weapon4 = bro.GetFlattenJSON()["rows"][0]["Equip"][3].ToString();
            var weapon5 = bro.GetFlattenJSON()["rows"][0]["Equip"][4].ToString();
            var weapon6 = bro.GetFlattenJSON()["rows"][0]["Equip"][5].ToString();

            BackendReturnObject bro2 = Backend.BMember.GetUserInfo();
            var name = bro2.GetReturnValuetoJSON()["row"]["nickname"].ToString();
            textName.text = name;
            textLevel.text = level;
            textCoin.text = coin;
            dataset = gameObject.GetComponent<DataSet>();
            dataset.nickname = name;
        }
    }
}
