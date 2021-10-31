using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEquip : MonoBehaviour
{

    DataManager data;
    WeaponSelection weapon;
    SkinSelection skin;

    public void activeEquip()       //������ Ȯ�� �� ���â ǰ�� ����
    {
        int weaponIndex = 6;
        int characIndex = 8;
        int skinIndex = 17;

        data = GameObject.Find("DataManager").GetComponent<DataManager>();
        weapon = GameObject.Find("EquipmentPanel").GetComponent<WeaponSelection>();
        skin = GameObject.Find("EquipmentPanel").GetComponent<SkinSelection>();

        int i=0;

        ////ǰ���� true�� Ȱ�� �׷��� ������ ��Ȱ��
        for (i=0;i< weaponIndex; i++)     //����
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

        for (i=6; i < characIndex; i++)      //ĳ����
        {
        }

        for (i=8; i < skinIndex; i++)      //��Ų
        {
            if (data.player.hasItem[i] == false)
            {
                skin.skin[i- characIndex].SetActive(false);
            }
            else
            {
                skin.skin[i- characIndex].SetActive(true);
            }
        }

    }

}
