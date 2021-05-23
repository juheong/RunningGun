using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;


public class DataManager : MonoBehaviour
{
    public void OnClickInsertData()
    {

        int charLevel = 1;
        int charExp = 0;
        int charScore = 0;

        // Param�� �ڳ� ������ ����� �� �� �Ѱ��ִ� �Ķ���� Ŭ���� �Դϴ�. 
        Param param = new Param();
        param.Add("Lv", charLevel);
        param.Add("Exp", charExp);
        param.Add("Score", charScore);

        // ���� Dictionary �� ����ϱ�
        Dictionary<string, bool> equipment = new Dictionary<string, bool>
        {
            { "weapon1", true },
            { "weapon2", true },
            { "weapon3", true },
            { "weapon4", true }
        };

        param.Add("equipItem", equipment);

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

}
