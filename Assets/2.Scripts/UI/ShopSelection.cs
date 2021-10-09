using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSelection : MonoBehaviour
{
    public static int selectedThing = 0;

    private DataManager data;
    public GameObject[] things;
    private TabManager tab;
    private ActiveShop activeShop;

    GameObject obj1;
    GameObject obj2;

    void Start()
    {
        obj1 = GameObject.Find("C_1");
        obj2 = GameObject.Find("TopTab_St");

        data = GameObject.Find("DataManager").GetComponent<DataManager>();
        tab = obj1.GetComponent<TabManager>();
        activeShop = GameObject.Find("ShopPanel").GetComponent<ActiveShop>();
    }

    public void SelectThing(int num)        //���ñ��
    {
        things[selectedThing].transform.parent.Find("Frame_Focus").gameObject.SetActive(false);
        selectedThing = num;
        things[selectedThing].transform.parent.Find("Frame_Focus").gameObject.SetActive(true);
    }
    public void BuyThing()      //���ű��
    {
        data.ItemUpdate(things[selectedThing].GetComponent<ItemDataSet>().itemId);      //DataManager�� ������ ǰ���� id�� ���ڷ� ItemUpdate ����
        things[selectedThing].transform.parent.Find("Frame_Focus").gameObject.SetActive(false);     //������ ǰ�� �������� ����
        things[selectedThing].gameObject.SetActive(false);      //���ñ�� ��
    }
}
