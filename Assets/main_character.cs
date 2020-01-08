using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_character : Monobehavier
{
    private void Update()

    {
        Turn();
        Run();
        Take();
    }
    public Rigidbody rigcatch;


    private void OnTriggerStay(Collider other)
    {
        if (other.name == "" && (ani.GetCurrentAnimatorStateInfo(0).IsName("")))
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
            other.GetComponent<HingeJoint>().connectedBody = rigcatch;
        }
        if (other.name == "" && (ani.GetCurrentAnimatorStateInfo(0).IsName("")))
        {
            GameObject.Find("").GetComponent<HingeJoint>().connectedBody = null;
        }
    }


    #region 區域
    [Header("")]
    [Range(1, 500)]
    public int speed = 10;                   // 整數
    [Tooltip("")]
    [Range(1f, 750f)]
    public float turn = 20.5f;               // 浮點數
    public bool mission;                     // 布林值
    public string Name = "";        // 字串
    #endregion
    public Transform tran;
    public Rigidbody rig;
    public Animator ani;
    public AudioSource aud;
    public AudioClip soundBark;


    private void Run()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("")) return;
        float v = Input.GetAxis("");
        rig.AddForce(tran.forward * speed * v * Time.deltaTime);
        ani.SetBool("walk", v != 0);
    }
    private void Turn()
    {
        float f = Input.GetAxis("");
        tran.Rotate(0, turn * f * Time.deltaTime, 0);
    }
    /// <summary>
    /// 踢擊
    /// </summary>
    private void Burk()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 按下空白鍵跳躍
            ani.SetTrigger("jump");
            aud.PlayOneShot(soundBark, 0.6f);
        }
    }

    private void Take()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            ani.SetTrigger("kick");
    }
    private void Task()
    { }
}
