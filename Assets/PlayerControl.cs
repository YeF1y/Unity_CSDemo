using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    //����
    private Rigidbody rBody;
    //��Ƶ���
    private AudioSource footPlayer;
    //�Ƿ��ڵ�����
    private bool isGround;

    void Start()
    {
        //��ȡ�������
        rBody = GetComponent<Rigidbody>();
        //��ȡ��Ƶ���
        footPlayer = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        //������¿ո�������ҽ�ɫ�ڵ�����
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            //��Ծ��������һ�����ϵ���
            rBody.AddForce(Vector3.up * 200);
        }
        //�Ƿ����ƶ���
        float horizontal = Input.GetAxis("Horizontal");//a d�ֱ𷵻�-1��1
        float vertical = Input.GetAxis("Vertical");//s w�ֱ𷵻�-1��1
        if((horizontal != 0 || vertical != 0) && isGround == true)
        {
            //����Ϊ��˵�����ƶ����Ҳ�����Ծ״̬�����ŽŲ���
            if (footPlayer.isPlaying == false)
            {
                //���жϲ���״̬����ֹ��������
                footPlayer.Play();
            }
        }
        else
        {
            footPlayer.Stop();
        }
    }

    //������ײ
    private void OnCollisionEnter(Collision collision)
    {
       //�ж��ǲ��ǵ���
       if(collision.collider.tag == "Ground")
        {
            //���ڵ�������
            isGround = true;
        }
    }

    //������ײ
    private void OnCollisionExit(Collision collision)
    {
        //�ж��ǲ��ǵ���
        if (collision.collider.tag == "Ground")
        {
            //�뿪��������
            isGround = false;
        }
    }
}
