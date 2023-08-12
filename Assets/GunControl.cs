using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunControl : MonoBehaviour
{
    //���������
    public Transform FirePoint;
    //��������Ԥ����
    public GameObject FirePre;
    //�����ӵ���
    public Transform BulletPoint;
    //�����ӵ�Ԥ����
    public GameObject BulletPre;
    //����ǹ����Ч
    public AudioClip clip;
    //�������ӵ���Ч
    public AudioClip check;
    //�����ӵ�UI
    public Text BulletText;

    //�ӵ�����
    private int bulletCount = 30;
    //������
    private float cd = 0.15f;
    //��ʱ��
    private float timer = 0;
    //��Ƶ���
    private AudioSource gunPlayer;

    void Start()
    {
        //��ȡ��Ƶ���
        gunPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        //��ʱ
        timer += Time.deltaTime;
        //�����ʱ������cd�����Ұ������������������ӵ�������
        if(timer > cd && Input.GetMouseButton(0) && bulletCount > 0)
        {
            //���ü�ʱ��
            timer = 0;
            //��������
            Instantiate(FirePre, FirePoint.position, FirePoint.rotation);
            //�����ӵ�
            Instantiate(BulletPre, BulletPoint.position, BulletPoint.rotation);
            //�ӵ���������
            bulletCount--;
            //ˢ��UI
            BulletText.text = bulletCount + "";
            //����ǹ��
            gunPlayer.PlayOneShot(clip);
            //����ӵ��������Զ����ӵ�
            if(bulletCount == 0)
            {
                //���Ŷ���
                GetComponent<Animator>().SetTrigger("Reload");
                //���Ż��ӵ���Ч
                gunPlayer.PlayOneShot(check);
                //1.5��󻻺��ӵ�
                Invoke("Reload", 1.5f);
            }
        }
        //��R���ӵ�
        if (Input.GetKeyDown(KeyCode.R))
        {
            //��յ�ǰ�ӵ�
            bulletCount = 0;
            //���Ŷ���
            GetComponent<Animator>().SetTrigger("Reload");
            //���Ż��ӵ���Ч
            gunPlayer.PlayOneShot(check);
            //1.5��󻻺��ӵ�
            Invoke("Reload", 1.5f);
        }
    }

    void Reload()
    {
        bulletCount = 30;
        //ˢ��UI
        BulletText.text = bulletCount + "";
    }
}
