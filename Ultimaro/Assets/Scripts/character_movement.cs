using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class character_movement : MonoBehaviour
{
    public CharacterController2D controller; // 用于CharacterController2D(自制脚本)的调用
    public Animator animator; // 用于动画的切换控制
    public Transform camera; // 用于控制摄影机的移动
    public Rigidbody2D rigidbody; // 保留

    public float runSpeed = 40f; // 人物速度的控制
    public float factor = 0.6f; // 加减速因子
    float horizontalMove = 40f; // 保留
    bool jump = false; // 记录是否跳跃
    bool grounded = true; // 保留，目前使用CharacterController2D.isGrounded()来确认
    bool double_jump = false; // 记录是否双重跳跃
    bool crouch = false; // 记录是否下蹲
    bool slope = false; // 记录是否滑坡，保留
    bool damaging = false;
    // 记录人物血量，保留
    public float maxHP = 100f;
    public float currentHP = 100f;
    public GameObject track;
    float Speed = 0f; // 记录/测量人物的速度，保留，用于Debug
    float timeR;

    public LayerMask groundLayerMask; // 地面Layer
    public GameManager GameManager; // 游戏管理
    private Vector2 boxSize; // 记录Collider2D的大小
    private BoxCollider2D boxCollider; // Collider2D，用于控制不同动作包围盒的大小
    private Scene scene;
    Vector3 PreviousFramePosition = Vector3.zero; // 用于获取速度，保留，Debug用


    

    // Start is called before the first frame update
    void Start()
    {
        PreviousFramePosition = transform.position;
        boxCollider = GetComponent<BoxCollider2D>();
        boxSize = boxCollider.size;
        timeR = Time.time;
        scene = SceneManager.GetActiveScene(); //判断获取当前在哪个场景

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = 40f;
        horizontalMove += Input.GetAxisRaw("Horizontal") * factor * runSpeed;
        // Debug.Log(Input.GetAxisRaw("Horizontal") * factor);

        if (controller.isGrounded())
        {
            track.active = true;
        }
        else{
            track.active = false;
        }

        // 跳跃
        if (Input.GetButtonDown("Jump"))
        {
            // 人物在地上
            if (controller.isGrounded())
            {
                jump = true;
                double_jump = true;
                // controller.isGrounded() = false;
                animator.SetBool("IsJumping", jump);
                // GameObject.Find("Track").active = false;
            }
            // 不在地上，且可以双重跳跃
            else if (!controller.isGrounded() && double_jump)
            {
                // controller.isGrounded() = true;
                Debug.Log("sadasdnhjkjnkjnkjnjknjknjknjknjk");
                jump = true;
                animator.SetBool("DoubleJump", double_jump);
                double_jump = false;
                // GameObject.Find("Track").active = true;
            }

        }
        // 下蹲
        if (Input.GetButtonDown("Crouch"))
        {
            // Collider变小了，由于下蹲
            boxCollider.size = new Vector2(1, 0.5f);

            crouch = true;
            animator.SetBool("IsCrouching", crouch);

        }
        else if (Input.GetButtonUp("Crouch"))
        {
            // 由于恢复姿态，变回正常
            boxCollider.size = boxSize;
            crouch = false;
            // Debug.Log("sadasbdjbhasbdhsbaajbd");
            animator.SetBool("IsCrouching", crouch);
        }
        /*
        // 人物出屏
        if (transform.position.x <= -10.5f || transform.position.y <= -8f)
        {
            Debug.Log("found it!");
            GameManager.Instance.GameOver();
        }
        // else
        // {
        //     transform.position = Vector2.Lerp(transform.position, new Vector2(-4.5f, transform.position.y), Time.deltaTime);
        // }
        */
        // get the speed of this character
        float movementPerFrame = Vector3.Distance(PreviousFramePosition, transform.position);
        Speed = movementPerFrame / Time.deltaTime;
        PreviousFramePosition = transform.position;
        Vector3 direction = transform.position - PreviousFramePosition;

        // if(direction.y > 0.05)
        // {
        //     Debug.Log("Up!");
        // }
        // else if(direction.y < -0.05)
        // {
        //     Debug.Log("Down!");
        // }

        // if (direction.x > 0.05)
        // {
        //     Debug.Log("Right!");
        // }
        // else if(direction.x < -0.05)
        // {
        //     Debug.Log("Left!");
        // }
        // if (Speed > 0.01)
        // Debug.Log(Speed);
        // Debug.Log(rigidbody.GetVector());


        // 保留，暂时无用，加速跑功能时可以用
        animator.SetFloat("Speed", Mathf.Abs(Speed));
        //随时间回血
        adjust_health(0.003f);



    }

    void FixedUpdate()
    {
        // // Debug.Log(transform.position);
        // GameObject[] bg = GameObject.FindGameObjectsWithTag("Background");
        // float middle = 0f;
        // foreach (GameObject i in bg)
        // {
        //     // Debug.Log(i.GetComponent<Transform>().position);
        //     middle += i.GetComponent<Transform>().position.x;
        // }
        // middle /= 2;
        // if (transform.position.x < middle)
        // {
        //     // Debug.Log(bg[0].name);
        //     BuoyancyEffector2D BE = bg[0].GetComponent<BuoyancyEffector2D>();
        //     // Debug.Log();
        //     if (BE)
        //     {
        //         animator.speed = 0.3f;
        //     }
        //     else
        //     {
        //         animator.speed = 1.0f;
        //     }
        //     // Debug.Log("YEAH!");
        //     // else
        //     //     Debug.Log("NO!");
        // }
        // else
        // {
        //     // Debug.Log(bg[1].name);
        //     BuoyancyEffector2D BE = bg[1].GetComponent<BuoyancyEffector2D>();
        //     // Debug.Log();
        //     if (BE)
        //     {
        //         animator.speed = 0.3f;
        //     }
        //     else
        //     {
        //         animator.speed = 1.0f;
        //     }
        //     //     Debug.Log("YEAH!");
        //     // else
        //     //     Debug.Log("NO!")
        // }
        // 判断是否为坡，保留
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, groundLayerMask);
        if (hit.collider != null)
        {
            Debug.Log(hit.normal.x.ToString() + "         " + hit.normal.y.ToString());
            if (Mathf.Abs(hit.normal.x) > 0.5)
            {
                Debug.Log("On a slope!");
                slope = true;
                animator.SetBool("IsClimbing", slope);
            }
            // Debug.Log(hit.normal.y);
            Debug.DrawRay(transform.position, hit.normal, Color.white);
        }
        slope = false;
        animator.SetBool("IsClimbing", slope);

        // Move character
        // Vector3 move = new Vector3(horizontalMove * Time.fixedDeltaTime, 0, 0);
        // Debug.Log(Time.fixedDeltaTime);
        // Debug.Log("asdasdsabhdbsahbdhsabdh");

        // 移动
        // Debug.Log(horizontalMove);
        // horizontalMove = 40.0f;
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        // if(double_jump){
        //     controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, double_jump);
        // }

        // 移动后，恢复状态
        jump = false;
        // double_jump = false;
        // controller.isGrounded() = true;
        // animator.SetBool("IsJumping", jump);
        animator.SetBool("DoubleJump", false);
        float timeC = Time.time;    //翻转1s后归位
        if(timeC - timeR > 1){
            Camera camera_m = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Camera>();
            camera_m.ResetWorldToCameraMatrix ();
            camera_m.ResetProjectionMatrix ();
            camera_m.projectionMatrix = camera_m.projectionMatrix * Matrix4x4.Scale(new Vector3 (1, 1, 1));
        }
            // animator.SetBool("Damage", false);
    }


    // 人物与其它物体碰撞时
    public void OnCollisionEnter2D(Collision2D coll)
    {
        // Debug.Log(coll.gameObject.tag);
        // 人物站在其它物体上，双跳开启，毁灭当前物体
        if (coll.gameObject.tag == "UpCollider")                  //UpCollider是地刺上的碰撞检测，用于人物扣血
        {   
            if (scene.name == "第3关.Game")
            {
                Camera camera_m = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Camera>();
                camera_m.ResetWorldToCameraMatrix();
                camera_m.ResetProjectionMatrix();
                camera_m.projectionMatrix = camera_m.projectionMatrix * Matrix4x4.Scale(new Vector3(1, -1, 1));
                // Debug.Log(Time.time.ToString("f6"));
            }
            float timeC = Time.time;
            if (timeC - timeR > 1) {
                // Debug.Log(timeC - timeR);
                // if(!AnimatorIsPlaying("Damage"))
                /*if(!damaging){
                    animator.SetBool("Damage", true);
                    // animator.SetBool("Damage", false);
                    damaging = true;
                }*/
                // Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("Damage"));
                // animator.SetBool("Damage", false);
            

                bool status = adjust_health(-10);            //扣血
                if (!status)
                    GameManager.Instance.GameOver();
                
            }
            timeR = timeC;
            // canJump = true;
            // rigidbody.velocity = Vector2.up * jumpForce;
            // Debug.Log("UP!");

            // double_jump = true;
            // controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            // animator.SetBool("IsJumping", true);
            // animator.SetBool("DoubleJump",true);
            // GameObject.Destroy(coll.transform.parent.gameObject);


            


        }
        /*// 人物被挤压致死
        if (coll.gameObject.tag == "EnemyBarrier")
        {

            GameManager.Instance.GameOver();

        }
        // 碰到敌人，死亡
        if (coll.gameObject.tag == "EnemyBarrier")
        {

            GameManager.Instance.GameOver();

        }
        */

        if (coll.gameObject.tag == "UpCollider1")
        {
            GameObject.Destroy(coll.transform.parent.gameObject);
        }
    }

    bool AnimatorIsPlaying(){
        // Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        return animator.GetCurrentAnimatorStateInfo(0).length >
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    
    bool AnimatorIsPlaying(string stateName){
        return AnimatorIsPlaying() && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    // 获取当前健康值
    public float get_health()
    {
        return currentHP;
    }

    // 调节健康值，如果血量小于等于0,人物死亡
    public bool adjust_health(float number)
    {
        currentHP = currentHP + number / 2 * 100 * Time.fixedDeltaTime;
        Debug.Log(number * Time.fixedDeltaTime);
        if (currentHP <= 0)
            return false;
        if (currentHP > 100)
            currentHP = 100;
        return true;
    }

    
    
    

    public void Jumped()
    {
        Debug.Log("Jumped!");
        animator.SetBool("IsJumping", false);
    }

    // 收集物体
    void OnTriggerEnter2D(Collider2D coll)
    {
        // Debug.Log("Here is "+other.gameObject.name);
        // other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y+1f, other.gameObject.transform.position.z);
        // spriteMove = -0.1f;
        if (coll.gameObject.tag == "Bonus1")
        {
            GameManager.Instance.UpdateBonus(1);
            //gameManager.UpdateBonus(1);
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "Bonus2")
        {
            GameManager.Instance.UpdateBonus(5);
            //gameManager.UpdateBonus(5);
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "EnemyBarrier")
        {
            Destroy(coll.gameObject);
            bool status = adjust_health(-10);            //扣血
            if (!status)
                GameManager.Instance.GameOver();
        }
    }
}

