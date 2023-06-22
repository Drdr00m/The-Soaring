using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Vector2 dir = new Vector2();
    private Rigidbody2D rb;
    private Animator ani;
    public bool IsTimeToFly=false;//�жϱ������ʱ��
    public GameObject Bird;//��
    public int SceneNum = 0;//��¼��ǰ�������

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//��ȡ����ĸ������
        ani = GetComponent<Animator>();//��ȡ���嶯�����
    }

    void Update()
    {
        switch(SceneNum)
        {
            case 0:
                dir = DirDecide();//��ȡӦ�ƶ��ķ���       
                Swim(dir);//��÷�������
                BoundaryTreatment();//�������嵽��߽�����
                break;
            case 1:
                dir = DirDecide();//��ȡӦ�ƶ��ķ���
                BoundaryTreatment();//�������嵽��߽�����
                Swim(dir);//��÷�������
                break;
            case 2:
            case 3:
                dir = DirDecide();
                Swim(dir);
                BoundaryTreatment();
                if (transform.position.y > 22f)//Ծ��һ���߶�
                {
                    GetComponent<SpriteRenderer>().flipX = false;//����ת
                    transform.rotation = Quaternion.Euler(0, 0, 30);//������̬
                    Instantiate(Bird, transform.position, transform.rotation);//��Ϊ����
                    Destroy(gameObject);
                }
                break;


        }
        
        
    }
    private Vector2 DirDecide()//�����������ȡ�������µķ���
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal >= 0)//������
        {
            GetComponent<SpriteRenderer>().flipX = false;//����ת
            transform.rotation = Quaternion.Euler(0, 0, 30 * vertical);//��ת
            
        }else if(horizontal<0)//����
        {
            GetComponent<SpriteRenderer>().flipX = true;//��ת
            transform.rotation = Quaternion.Euler(0, 0, 30 * (-1) * vertical);//��ת

        }
        Vector3 dir = new Vector3(horizontal, vertical);//����


        return dir;

    }
    private void Swim(Vector2 dir)//���εķ���
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsTimeToFly)//���ñ���
            {
                rb.AddForce(dir * 2500);
            }else if(IsTimeToFly)//�ñ���
            {
                rb.AddForce(new Vector2(1,1.7f)* 5000);//���Էɵúܸ�
                SceneNum = 3;
            }
            ani.SetTrigger("Swim");//�������ζ���
        }
    }
    private void BoundaryTreatment()//���ڴ������嵽��߽�ķ���
    {
        switch (SceneNum)
        {
            case 0:
                if (transform.position.y > -1.84f)//���嵽���϶�
                {
                    transform.position = new Vector2(transform.position.x, -1.84f);
                }
                else if (transform.position.y < -16.72f)//���ﳡ���¶�
                {
                    transform.position = new Vector2(transform.position.x, -16.72f);
                }
                else if (transform.position.x < -35.17f)//���嵽����߽�
                {
                    transform.position = new Vector2(-35.17f, transform.position.y);
                }
                break;
            case 1:
                if (transform.position.y > -1.84f )//���嵽���϶�
                {
                    transform.position = new Vector2(transform.position.x, -1.84f);
                }
                else if (transform.position.y < -16.72f)//���ﳡ���¶�
                {
                    transform.position = new Vector2(transform.position.x, -16.72f);
                }
                else if (transform.position.x <= -6.5f)//���嵽����߽�
                {
                    transform.position = new Vector2(-6.5f, transform.position.y);
                }
                else if (transform.position.x >= 255.6f)//���嵽���ұ߽�
                {
                    transform.position = new Vector2(255.6f, transform.position.y);
                }
                break;
            case 2:
                if (transform.position.x >= 255.6f)//���嵽���ұ߽�
                {
                    transform.position = new Vector3(255.6f, transform.position.y);
                }
                break;
                if(transform.position.y<-16.72f)//�����±߽�
                {
                    transform.position = new Vector2(transform.position.x, -16.72f);
                }
        }
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="Enemy")
        {
            rb.AddForce(new Vector2(-1, 0)*2000);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="TimeToFly")//��ʱ��������
        {
            IsTimeToFly = true;
            SceneNum=2;
        }
        
        if(other.tag=="GoNewScene")
        {
            SceneNum++;
            Destroy(other.gameObject);//��ֹ�ٴ�����
        }
        if(other.tag=="BecomeBird")
        {
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if(other.tag=="TimeToFly")
        {
            IsTimeToFly= false;
        }
        
    }

}
