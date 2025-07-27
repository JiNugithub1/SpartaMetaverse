using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;

    Rigidbody2D _rigidbody;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;
    public bool godMode = false;
    FlyingManager flyingManager;

    void Start()
    {
        flyingManager = FlyingManager.Instance;
        animator = GetComponentInChildren<Animator>(); //하위 오브젝트(자식오브젝트)까지도 검색할 것
        _rigidbody = GetComponent<Rigidbody2D>(); // 현재 위치내 컴포넌트만 찾는다.


        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }
        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded RigidBody");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
                {
                    flyingManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
            {
                isFlap = true;
            }
        }
    }
    private void FixedUpdate() //FixedUpdate: 물리 연산이 필요할 때 일정한 간격으로 호출
    {
        if (isDead) return;

        Vector3 veloctiy = _rigidbody.velocity;
        veloctiy.x = forwardSpeed;

        if (isFlap)
        {
            veloctiy.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = veloctiy;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;

        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetInteger("isDie", 1);
        flyingManager.GameOver();
    }
}
