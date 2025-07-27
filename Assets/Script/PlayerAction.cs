using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private Animator anim;
    public float Speed;

    public GameManager manager;
    float h;
    float v;
    GameObject scanObject;
    Vector2 moveVec = Vector2.zero;
    Vector3 dirVec;
    bool isHorizonMove;
    private Vector2 lastMoveDir = Vector2.down;

    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move Value
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        //Check Button & UP
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        // 십자 이동 로직 (가로 우선)
        // 세로와 가로가 동시에 눌렸을 때는 가로 이동 먼저 처리
        if (h != 0)
        {
            moveVec = new Vector2(h, 0);
            isHorizonMove = true;
        }
        else if (v != 0)
        {
            moveVec = new Vector2(0, v);
            isHorizonMove = false;
        }
        else
        {
            moveVec = Vector2.zero;
        }

        bool isInput = moveVec.sqrMagnitude > 0.01f;

        // Animation 처리 로직
        if (isInput)
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("hAxisRaw", moveVec.x);
            anim.SetFloat("vAxisRaw", moveVec.y);

            lastMoveDir = moveVec;
        }
        else
        {
            anim.SetBool("isMoving", false);
            anim.SetFloat("hAxisRaw", lastMoveDir.x);
            anim.SetFloat("vAxisRaw", lastMoveDir.y);
        }
       
        //Direction 방향 제어
        if (vDown && v == 1)
        {
            dirVec = Vector3.up;
        }
        else if (vDown && v == -1)
        {
            dirVec = Vector3.down;
        }
        else if (hDown && h == -1)
        {
            dirVec = Vector3.left;
        }
        if (hDown && h == 1)
        {
            dirVec = Vector3.right;
        }

        // Scan Object 오브젝트 상호작용 코드
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            manager.Action(scanObject);
        }
    }
    void FixedUpdate()
    {
        
        if (isHorizonMove)
        {
            if (h != 0) moveVec = new Vector2(h, 0);
        }
        else
        {
            if (v != 0) moveVec = new Vector2(0, v);
        }

        rigid.velocity = moveVec * Speed;

        //Ray 상호 작용을 하는 코드 (player가 오브젝트와 상호작용하는 부분)
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }

    }
}
