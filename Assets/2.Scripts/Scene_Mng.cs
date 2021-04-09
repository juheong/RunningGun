using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_Mng : MonoBehaviour
{
    public void MainMenu()      // ���θ޴�
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void CharacterSel()     // ĳ���� ����â
    {
        SceneManager.LoadScene("Scene_Char");
    }
    public void EquipMenu()       // ���޴�
    {
        SceneManager.LoadScene("Scene_Equip");
    }
    public void OptionMenu()       // �ɼǸ޴�
    {
        SceneManager.LoadScene("Scene_Option");
    }
    public void StageMenu()     // �������� ����â
    {
        SceneManager.LoadScene("Scene_Stage");
    }
    public void ShopMenu()      // ������
    {
        SceneManager.LoadScene("Scene_Shop");
    }
    public void First_Stage()      // ù��������
    {
        SceneManager.LoadScene("SampleScene");
    }
}
