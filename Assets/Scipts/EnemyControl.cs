using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour//���ڿ��ƵжԴ���
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(1, 0)*2f* Time.deltaTime);//�����������ƶ�
        Destroy(gameObject, 20f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")//������������ײ
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")//�����������غ�
        {
            Destroy(gameObject);
        }
    }
}
