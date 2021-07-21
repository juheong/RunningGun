using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Component : MonoBehaviour
{
    [SerializeField]
    private CapsuleCollider parentCol;  // ��ü���� ������ �پ��ִ� ĸ�� �ݶ��̴�. ������ �������� �̰� ��Ȱ��ȭ ���־�� ��.
    [SerializeField]
    private CapsuleCollider childCol;  // ������ ������ ���� ���κп� �پ��ִ� ĸ�� �ݶ��̴�. ������ �������� �̰� Ȱ��ȭ ���־�� ��.
    [SerializeField]
    private Rigidbody childRigid; // ������ ������ ���� ���κп� �پ��ִ� Rigidbody�� ���� ������ �������� �߷��� Ȱ��ȭ ���־�� ��.

    [SerializeField]
    private float force;  // ������ ���� ���������� �о��� ���� ����(�������� ���� ��) 
    [SerializeField]
    private GameObject go_ChildTree;  // ������ ���� ���κ�. �������� �� ������ ���� �ð� �� �ı� �Ǿ� �ؼ� �ʿ���.

    [SerializeField]
    private GameObject go_Tree_Prefabs;  // �볪��. ������ ������ ���� ������.

    [SerializeField]
    private float destroyTime;
       
    private Transform playertf;

    /* ȸ���� ���� */
    private Vector3 originRot;   // ���� ���� ���� ȸ�� ��. (���� ���� ������ ����̰� �� ���̶� ���߿� ������� ���� �� �� �ʿ�)
    private Vector3 wantedRot;   // ���� ���� ���� �� ȸ�� �Ǳ� ���ϴ� ��.
    private Vector3 currentRot;  // wanted_Rot �� �Ǳ� ���� ��� �����س��� ȸ�� ��
    GameObject obj1;
    

    private void Start()
    {
        originRot = transform.rotation.eulerAngles;  // ���� ���ϰ� Vector3 ��.
        currentRot = originRot;  // currentRot �ʱⰪ
        obj1 = GameObject.Find("Player_Zeniel");

        StartCoroutine(HitSwayCoroutine(obj1.gameObject.transform));


    }

    private void FallDownTree()
    {
        //SoundManager.instance.PlaySE(falldown_sound);

        //Destroy(go_treeCenter);

        parentCol.enabled = false;
        childCol.enabled = true;
        //childRigid.useGravity = true;

        //childRigid.AddForce(-force, 0f, force);

        StartCoroutine(HitSwayCoroutine(obj1.gameObject.transform));
    }

    IEnumerator HitSwayCoroutine(Transform tf)
    {
 
        Vector3 direction = (tf.position - transform.position).normalized; // �÷��̾� �������� �� ���ϴ� ���� 

        Vector3 rotationDir = Quaternion.LookRotation(direction).eulerAngles;  // �÷��̾� �������� ������ �ٶ󺸴� ������ ���� ��.
        Debug.Log(rotationDir);
        CheckDirection(rotationDir);

        while (!CheckThreadhold())
        {
            currentRot = Vector3.Lerp(currentRot, wantedRot, 0.01f);
            transform.rotation = Quaternion.Euler(currentRot);
            yield return null;
        }

        wantedRot = originRot;

        //while (!CheckThreadhold())
        //{
        //    currentRot = Vector3.Lerp(currentRot, originRot, 0.15f);
        //    transform.rotation = Quaternion.Euler(currentRot);
        //    yield return null;
        //}
    }

    private bool CheckThreadhold()
    {
        if (Mathf.Abs(wantedRot.x - currentRot.x) <= 0.5f && Mathf.Abs(wantedRot.z - currentRot.z) <= 0.5f)
            return true;
        return false;
    }

    private void CheckDirection(Vector3 _rotationDir)  // ��� �������� ���� ������ ������.
    {
       

       
        if (_rotationDir.y > 180)
        {
            if (_rotationDir.y > 300)  // 300 ~ 360 
                wantedRot = new Vector3(-80f, 0f, -80f);
            else if (_rotationDir.y > 240) // 240 ~ 300
                wantedRot = new Vector3(0f, 0f, -80f);
            else    // 180 ~ 240
                wantedRot = new Vector3(80f, 0f, -80f);
        }
        else if (_rotationDir.y <= 180)
        {
            if (_rotationDir.y < 60)  // 0 ~ 60
                wantedRot = new Vector3(-80f, 0f, 80f);
            else if (_rotationDir.y > 120)  // 120 ~ 180
                wantedRot = new Vector3(0f, 0f, 80f);
            else  // 60 ~ 120
                wantedRot = new Vector3(80f, 0f,80f);
        }
    }

    //IEnumerator LogCoroutine()
    //{
    //    yield return new WaitForSeconds(destroyTime);

    //    //SoundManager.instance.PlaySE(logChange_sound);

    //    //Instantiate(go_Tree_Prefabs, go_ChildTree.transform.position + (go_ChildTree.transform.up * 3f), Quaternion.LookRotation(go_ChildTree.transform.up));


    //   // Destroy(go_ChildTree.gameObject);
    //}
}