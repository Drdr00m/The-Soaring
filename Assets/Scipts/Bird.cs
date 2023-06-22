using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private bool FirstFly = true;//�ոջ�Ϊ��,Ϊ����**********************************************
    private bool FirstScene5 = true;//�ս��볡��5*********************
    private int SpreadNum = 0;//����5�ӳ��Ĵ���
    private Vector2 StartControlPoint = new Vector2(277.04f, 32.55f);//���Կ�ʼ�������Ƶĵ�
    private Vector2 Scene5ControlPoint = new Vector2(432.5f, 32.4f);
    private Vector2 dir = new Vector2();
    private Animator ani;
    private Rigidbody2D rb;
    public int SceneNum=3;//��¼��ǰ��Ϸ��������ʼΪ3,Ϊ�����������Ϊ4*****************************
    public GameObject WaterHit;//�������ˮ
    public GameObject Head;//ͷ��������������һ����ת
    bool Finish = false;//Scene9�ж��Ƿ񲥷��궯��
    bool Finish2=false;
    /*
     * Scene3:�����������
     * Scene4:��ʼ����������
     * Scene5:ˮ����ǧ��ҷ�ҡ����
     * Scene6:ȥ������Ϣ��Ҳ
     * Scene7:������������׵�
     * Scene8��Խ��
     * Scene9β��
     */
    void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        SceneNum = 3;//�������ʱ�ĳ���**********************
    }
    void Update()
    {
        
       switch(SceneNum)
        {
            case 3:
                if (FirstFly)
                {
                    ani.SetTrigger("Fly");
                    transform.position = Vector2.MoveTowards(transform.position, StartControlPoint, 5 * Time.deltaTime);
                    //�ջ�Ϊ��ʱ������Զ����
                    if (transform.position.y - StartControlPoint.y > -0.1)
                    {
                        FirstFly = false;//����Ŀ�ĵ�
                    }
                }
                else if (!FirstFly)//�����ٿ�
                {
                    dir = DirDecide();
                    Fly(dir);
                }
            break;
            case 4:
                dir = DirDecide();
                Fly(dir);;
                BoundaryTreatment(49.63f, 15.9f, 265.06f,449.2f);//�ϱ߽磬�±߽磬��߽磬�ұ߽�
                break;
            case 5://ˮ����ǧ��ҷ�ҡ����
                if (FirstScene5)//�ȷɵ�ָ��λ��
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);//������̬
                    transform.position = Vector2.MoveTowards(transform.position, Scene5ControlPoint, 5 * Time.deltaTime);
                    if (transform.position.x - Scene5ControlPoint.x > -0.1)
                    {
                        FirstScene5 = false;
                    }
                }
                else if (!FirstScene5)
                {
                    if (SpreadNum < 3)//�����οո�
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            ani.SetTrigger("SpreadWings");
                            SpreadNum++;
                            rb.AddForce(new Vector2(0, 1) * SpreadNum * 2000);
                            HitWater(SpreadNum);

                        }
                    }
                    if (SpreadNum == 3)
                    {
                        transform.Translate(new Vector2(0, 1) * 10 * Time.deltaTime);//�˷����
                        ani.SetTrigger("SpreadWings");
                    }

                }
            break;
            case 6://ȥ������Ϣ��Ҳ
                if (Input.GetAxis("Vertical") > 0)
                {
                    transform.Translate(new Vector2(0, 1) * 10 * Time.deltaTime);
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    transform.Translate(new Vector2(0, -1) * 10 * Time.deltaTime);
                }
                BoundaryTreatment(193.82f, 171.9f, 410f);
                break;
            case 7://��Խ����
                dir = DirDecide();
                Fly(dir);
                BoundaryTreatment(193.82f, 171.9f, 410f);
                break;
            case 8://��Խ��
                dir = DirDecide();
                Fly(dir);
                BoundaryTreatment(372.3f, 184.52f, 873.76f, 898.3f);
                break;
            case 9://β��
                transform.rotation = Quaternion.Euler(0, 0, 0);//������̬
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(1024.69f, 349.16f), 10 * Time.deltaTime);
                if(transform.position.x-1021.6f>-30&&!Finish)
                {
                    ani.SetTrigger("Land");                   
                    Finish = true;
                }
                if(transform.position.x-1021.6>-1&&!Finish2)
                {
                    Head.GetComponent<Animator>().SetTrigger("Head2");
                    Finish2= true;
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
            Head.GetComponent<SpriteRenderer>().flipX = false;//ͷ����ת
            transform.rotation = Quaternion.Euler(0, 0, 30 * vertical);//��ת

        }
        else if (horizontal < 0)//����
        {
            GetComponent<SpriteRenderer>().flipX = true;//��ת
            Head.GetComponent<SpriteRenderer>().flipX = true;//ͷ��ת
            transform.rotation = Quaternion.Euler(0, 0, 30 * (-1) * vertical);//��ת

        }
        Vector2 dir = new Vector2(horizontal, vertical);//����

        return dir;

    }
    private void Fly(Vector2 dir)//����ķ���
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(dir * 2500);
            ani.SetTrigger("Fly");//���ŷ��趯��           
            if(SceneNum==1)
            {

            }
        }
    }
    private void BoundaryTreatment(float top,float bottom,float left)//���ڴ������嵽��߽�ķ���,ˮƽ�ƶ�
    {
        if (transform.position.y >top)//���嵽���϶�
        {
            transform.position = new Vector3(transform.position.x, top);
        }
        else if (transform.position.y < bottom)//���ﳡ���¶�
        {
            transform.position = new Vector3(transform.position.x, bottom);
        }
        else if (transform.position.x <= left)//���嵽����߽�
        {
            transform.position = new Vector3(left, transform.position.y);
        }

    }
    private void BoundaryTreatment(float top, float bottom, float left,float right)
    {
        if (transform.position.y > top)//���嵽���϶�
        {
            transform.position = new Vector3(transform.position.x, top);
        }
        else if (transform.position.y < bottom)//���ﳡ���¶�
        {
            transform.position = new Vector3(transform.position.x, bottom);
        }
        else if (transform.position.x <= left)//���嵽����߽�
        {
            transform.position = new Vector3(left, transform.position.y);
        }else if(transform.position.x> right)
        {
            transform.position = new Vector3(right, transform.position.y);
        }
    }
    private void HitWater(int SpreadTime)//����ˮЧ����
    {
        for (int i = 0; i < SpreadTime * 5; i++)
        {
            Instantiate(WaterHit, new Vector2(Random.Range(transform.position.x - 30, transform.position.x - 10), transform.position.y - 15 - i*3), Quaternion.Euler(0, 0, -90));
        }
        for (int i = 0; i < SpreadTime * 5; i++)
        {
            Instantiate(WaterHit, new Vector2(Random.Range(transform.position.x + 10, transform.position.x + 30), transform.position.y - 15 - i * 3), Quaternion.Euler(0, 0, -90));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GoNewScene")
        {
            SceneNum++;
            Destroy(collision.gameObject);//��ֹ�ٴ�����
        }
        if (collision.tag == "Wind")
        {
            rb.AddForce(new Vector2(1, 0)*3000);//ȥ������Ϣ��Ҳ
            ani.SetTrigger("Fly");
            Destroy(collision.gameObject);
        }
        if(collision.tag=="Enemy")//�����׵�
        {
            rb.AddForce(new Vector2(-1, 0) * 2500);
        }
        if (collision.tag == "BecomeBird")
        {
            Destroy(collision.gameObject);
        }
    }
}
