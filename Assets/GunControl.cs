using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunControl : MonoBehaviour
{
    //关联火焰点
    public Transform FirePoint;
    //关联火焰预设体
    public GameObject FirePre;
    //关联子弹体
    public Transform BulletPoint;
    //关联子弹预设体
    public GameObject BulletPre;
    //关联枪声音效
    public AudioClip clip;
    //关联换子弹音效
    public AudioClip check;
    //关联子弹UI
    public Text BulletText;

    //子弹个数
    private int bulletCount = 30;
    //开火间隔
    private float cd = 0.15f;
    //计时器
    private float timer = 0;
    //音频组件
    private AudioSource gunPlayer;

    void Start()
    {
        //获取音频组件
        gunPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        //计时
        timer += Time.deltaTime;
        //如果计时器满足cd，并且按下鼠标左键，而且有子弹，开火
        if(timer > cd && Input.GetMouseButton(0) && bulletCount > 0)
        {
            //重置计时器
            timer = 0;
            //创建火焰
            Instantiate(FirePre, FirePoint.position, FirePoint.rotation);
            //创建子弹
            Instantiate(BulletPre, BulletPoint.position, BulletPoint.rotation);
            //子弹个数减少
            bulletCount--;
            //刷新UI
            BulletText.text = bulletCount + "";
            //播放枪声
            gunPlayer.PlayOneShot(clip);
            //如果子弹打完了自动换子弹
            if(bulletCount == 0)
            {
                //播放动画
                GetComponent<Animator>().SetTrigger("Reload");
                //播放换子弹音效
                gunPlayer.PlayOneShot(check);
                //1.5秒后换号子弹
                Invoke("Reload", 1.5f);
            }
        }
        //按R换子弹
        if (Input.GetKeyDown(KeyCode.R))
        {
            //清空当前子弹
            bulletCount = 0;
            //播放动画
            GetComponent<Animator>().SetTrigger("Reload");
            //播放换子弹音效
            gunPlayer.PlayOneShot(check);
            //1.5秒后换号子弹
            Invoke("Reload", 1.5f);
        }
    }

    void Reload()
    {
        bulletCount = 30;
        //刷新UI
        BulletText.text = bulletCount + "";
    }
}
