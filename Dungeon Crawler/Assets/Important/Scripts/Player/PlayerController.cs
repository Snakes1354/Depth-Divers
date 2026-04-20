using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerInput.MainActions input;

    CharacterController characterController;
    [SerializeField] Animator anim;
    AudioSource audioSource;

    [Header("Movement")]
    public float gravity = -9.8f;
    public float JumpHeight = 1.2f;

    Vector3 _PlayerVelocity;
    bool isGrounded;

    Vector2 moveInput;

    [Header("Camera")]
    public Camera cam;
    public float sensitivity;
    float xRotation = 0f;

    [Header("Attacking")]
    public float attackDistance = 3f;
    public float attackDelay = 0.4f;
    public LayerMask attackLayer;

    public GameObject hitEffect;
    public AudioClip swordSwing;
    public AudioClip hitSound;

    bool attacking = false;
    bool readyToAttack = true;
    int attackCount;

    string currentAnimationState;

    [SerializeField] AnimationCurve dodgeCurve;

    bool isDodging;

    float dodgeTimer, dodge_coolDown;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        
        playerInput = new PlayerInput();
        playerInput.Enable();
        input = playerInput.Main;

        AssignInputs();
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;

        MoveInput(input.Movement.ReadValue<Vector2>());

        SetAnimations();

        if (dodge_coolDown > 0)
            dodge_coolDown -= Time.deltaTime;
    }

    void LateUpdate()
    {
        LookInput(input.Look.ReadValue<Vector2>());
    }

    void AssignInputs()
    {
        input.Jump.performed += ctx => Jump();
        input.Attack.started += ctx => Attack();
        //input.Dodge.performed += ctx => StartCoroutine(Dodge());
    }

    void MoveInput(Vector2 inputVec)
    {
        if (isDodging) return;

        moveInput = inputVec;

        Vector3 moveDirection = new Vector3(inputVec.x, 0, inputVec.y);

        float speed = StatManager.Instance.MovementSpeed;

        characterController.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        _PlayerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && _PlayerVelocity.y < 0)
            _PlayerVelocity.y = -2f;

        characterController.Move(_PlayerVelocity * Time.deltaTime);
    }

    void LookInput(Vector3 inputVec)
    {
        float mouseX = inputVec.x;
        float mouseY = inputVec.y;

        xRotation -= mouseY * Time.deltaTime * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -80, 80);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime * sensitivity));
    }

    void Jump()
    {
        if (isGrounded)
            _PlayerVelocity.y = Mathf.Sqrt(JumpHeight * -3.0f * gravity);
    }

    public void Attack()
    {
        if (isDodging) return;
        if (!readyToAttack || attacking) return;

        readyToAttack = false;
        attacking = true;

        Invoke(nameof(ResetAttack), 0.6f);
        Invoke(nameof(AttackRaycast), attackDelay);

        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(swordSwing);

        if (attackCount == 0)
        {
            ChangeAnimationState(ATTACK1);
            attackCount++;
        }
        else
        {
            ChangeAnimationState(ATTACK2);
            attackCount = 0;
        }
    }

    void ResetAttack()
    {
        attacking = false;
        readyToAttack = true;
    }

    void AttackRaycast()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward,
            out RaycastHit hit, attackDistance, attackLayer))
        {
            HitTarget(hit.point);

            if (hit.transform.TryGetComponent<Actor>(out Actor T))
            {
                T.TakeDamage(StatManager.Instance.damage);
            }

            if (hit.transform.TryGetComponent<Tutorial>(out Tutorial tutorial))
            {
                tutorial.TakeDamage(StatManager.Instance.damage);
            }
        }
    }

    void HitTarget(Vector3 pos)
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(hitSound);

        GameObject GO = Instantiate(hitEffect, pos, Quaternion.identity);
        Destroy(GO, 20);
    }

    IEnumerator Dodge()
    {
        if (dodge_coolDown > 0) yield break;

        anim.SetTrigger("Dodge");

        isDodging = true;

        float timer = 0;

        bool heightCompressed = false;
        Vector3 dodgeDirection = transform.forward;
        dodgeDirection = cam.transform.forward;

        dodge_coolDown = dodgeTimer + 0.25f;

        while (timer < dodgeTimer)
        {
            if (!heightCompressed && timer > dodgeTimer / 3)
            {
                characterController.center = new Vector3(0, 0.5f, 0);
                characterController.height = 1;
                heightCompressed = true;
            }

            float speed = dodgeCurve.Evaluate(timer);

            Vector3 dir = (transform.forward * speed) + (Vector3.up * _PlayerVelocity.y);

            characterController.Move(dir * Time.deltaTime);

            timer += Time.deltaTime;

            yield return null;
        }

        characterController.center = new Vector3(0, 1.1f, 0);
        characterController.height = 2;

        isDodging = false;
    }

    void SetAnimations()
    {
        anim.SetFloat("Speed", moveInput.magnitude);
        
        if (isDodging) return;

        if (!attacking)
        {
            if (moveInput.magnitude == 0)
                ChangeAnimationState(IDLE);
            else
                ChangeAnimationState(WALK);
        }
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentAnimationState == newState) return;

        currentAnimationState = newState;
        anim.CrossFadeInFixedTime(currentAnimationState, 0.2f);
    }

    public const string IDLE = "Idle";
    public const string WALK = "Walk";
    public const string ATTACK1 = "Attack 1";
    public const string ATTACK2 = "Attack 2";
}