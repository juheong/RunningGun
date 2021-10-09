using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEquip : MonoBehaviour
{

    DataManager data;
    WeaponSelection weapon;

    public void activeEquip()       //������ Ȯ�� �� ���â ǰ�� ����
    {
        data = GameObject.Find("DataManager").GetComponent<DataManager>();
        weapon = GameObject.Find("EquipmentPanel").GetComponent<WeaponSelection>();

        for (int i=0;i<data.player.hasItem.Length;i++)      //ǰ���� true�� Ȱ�� �׷��� ������ ��Ȱ��
        {
            if(data.player.hasItem[i]==false)
            {
                weapon.weapon[i].SetActive(false);
            }
            else
            {
                weapon.weapon[i].SetActive(true);
            }
        }

    }

}
