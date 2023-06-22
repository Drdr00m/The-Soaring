using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject Verse1;//��ڤ����
    public GameObject Scene3;
    public GameObject Verse2;//����Ϊ��
    public GameObject Scene5;
    public GameObject Verse3;//ˮ����ǧ��ҷ�ҡ�����߾�����
    public GameObject Scene6;
    public GameObject Verse4;//ȥ������Ϣ��Ҳ
    public GameObject Scene8;
    public GameObject Verse5;//�Ϲ��д���
    public GameObject Scene9;//������β��
    private GameObject Camera;
    public GameObject South;//��ʾ������ڤ
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Camera.transform.position.x,Camera.transform.position.y,Camera.transform.position.z+10);
        if(Scene3==null)
        {
            Verse2.SetActive(true);
        }
        if(Scene5==null)
        {
            Verse3.SetActive(true);
        }
        if(Scene6==null)
        {
            Verse4.SetActive(true);
        }
        if(Scene8==null)
        {
            Verse5.SetActive(true);
        }
        if(Scene9==null)
        {          
             South.SetActive(true);
        }
    }
}
