using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour//�������ɵжԴ���
{
    public GameObject Enemy;
    public GameObject Turtle;
    private GameObject Fish;
    private Fish FishScene;
    private float timer=0;
    private float timer2 = 0;
    //���ڼ�����ȴʱ��
    void Start()
    {
        Fish = GameObject.FindGameObjectWithTag("Player");
        FishScene = Fish.GetComponent<Fish>();//��ȡ��������Ͻű����
    }

    // Update is called once per frame
    void Update()
    {
        if (FishScene.SceneNum == 0)//����Ҵ��ڵ�һ�����������ɵ���
        {
            timer += Time.deltaTime;
            timer2+=Time.deltaTime;
            if (Fish != null)
            {
                while (timer > 5)//������ȴʱ��
                {
                    Instantiate(Enemy, new Vector2(Fish.transform.position.x + Random.Range(60, 80), Random.Range(-17.07f, -2.78f)), Quaternion.Euler(0, 180, 0));
                    //����һ������
                    timer = 0;
                }
            }
            if(Fish!=null)
            {
                while(timer2>4)
                {
                    Instantiate(Turtle, new Vector2(Fish.transform.position.x + Random.Range(60, 80), Random.Range(-17.07f, -2.78f)), Quaternion.Euler(0, 0, 0));
                    //����һ����
                    timer2 =0;
                }
            }
        }
    }
   
}
