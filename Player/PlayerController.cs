using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Material _damageTakenMaterial;

    private int _playerHP;
    private float _moveSpeed;
    private float _spinSpeed;
    private float _rotationSpeed;
    private float _attackRadius;
    public bool isAttacking = false;
    public bool isHitten = false;

    private HealthBar _healthBar;
    private SkinnedMeshRenderer _playerMesh;
    private Material _playerMaterial;
    private Color _noneAttackColor;
    private Animator _playerAnimator;
    private Enemy _enemy;
    private Rigidbody _rb;
    private EndPanel _endPanel;

    private Vector3 _distance;
    private Vector3 _startMousePosition;
    private Vector3 _movementDirection;

    //public bool coroutineEnable = false;

    private void Awake()
    {
        _endPanel = FindObjectOfType<EndPanel>();
        _healthBar = FindObjectOfType<HealthBar>();
    }

    void Start()
    {
        _moveSpeed = GameplaySettings.moveSpeed;
        _spinSpeed = GameplaySettings.spinSpeed;
        _rotationSpeed = GameplaySettings.rotationSpeed;
        _attackRadius = GameplaySettings.attackRadius;
        _playerHP = GameplaySettings.playerHP;

        _rb = GetComponent<Rigidbody>();
        _playerMesh = transform.Find("Pers").GetComponentInChildren<SkinnedMeshRenderer>();
        _playerMaterial = _playerMesh.material;
        _noneAttackColor = _playerMaterial.color;
        Debug.Log(_playerMesh.gameObject.name);
        _playerAnimator = transform.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 newMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            _movementDirection = new Vector3(newMousePosition.x - _startMousePosition.x, 0.0f, newMousePosition.y - _startMousePosition.y).normalized;

            if (_movementDirection != Vector3.zero && isAttacking == false)
            {
                _playerAnimator.SetBool("isRunning", true);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_movementDirection), _rotationSpeed * Time.fixedDeltaTime);
            }

            transform.Translate(_movementDirection * _moveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _playerAnimator.SetBool("isRunning", false);
        }

        EnemyDetection(transform.position, _attackRadius);
    }

    private void EnemyDetection(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.layer == 9)
            {
                _playerAnimator.SetBool("isRunning", false);
                _playerAnimator.SetBool("isAttacking", true);
                isAttacking = true;
                StartCoroutine(routine: Rotating());
                break;
            }
            isAttacking = false;
            _playerAnimator.SetBool("isAttacking", false);
        }
    }

    private IEnumerator Rotating()
    {
        yield return null;
        transform.Rotate(0, _spinSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 12)
        {
            StartCoroutine(routine: DamageTaken(20));
        }
        else if (collision.gameObject.layer == 9)
        {
            StartCoroutine(routine: DamageTaken(5));
        }
        else if(collision.gameObject.layer == 4)
        {
            _playerHP = 0;
            Destroy(gameObject);
            _endPanel.EnableDeafeatPanel();
        }
    }

    private IEnumerator DamageTaken(int damageValue)
    {
        _playerMesh.material.color = new Color32(255, 20, 0, 255);
        if (isHitten == false)
        {
            _playerHP -= damageValue;
            if (_playerHP <= 0)
            {
                _playerHP = 0;
                Destroy(gameObject);
                _endPanel.EnableDeafeatPanel();
            }
            isHitten = true;
        }
        _healthBar.SetHealth(_playerHP);
        Debug.Log(_playerHP);
        yield return new WaitForSeconds(0.2f);
        _playerMesh.material.color = _noneAttackColor;
        isHitten = false;
    }
}
