using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]

public class Movement : MonoBehaviour
{
    private const string Speed = "Speed";
    private const string Jump = "Jump";

    [SerializeField] private float _speed;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private float _jumpForce = 10f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _animator.SetFloat(Speed, 0);

        float xCoordinate = 0;
        float yCooordinate = 0;

        if (Input.GetKey(KeyCode.D))
        {
            xCoordinate = _speed * Time.deltaTime;

            _spriteRenderer.flipX = false;
            _animator.SetFloat(Speed, 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            xCoordinate = _speed * Time.deltaTime * -1;

            _spriteRenderer.flipX = true;
            _animator.SetFloat(Speed, 1);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            yCooordinate = _jumpForce * Time.deltaTime;

            _animator.SetTrigger(Jump);
        }

        transform.Translate(xCoordinate, yCooordinate, 0);
    }
}
