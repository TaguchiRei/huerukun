using UnityEngine;

public abstract class Move : MonoBehaviour
{
    [SerializeField] protected GameObject[] _foot;
    [SerializeField] protected Rigidbody2D _rig;
    [SerializeField] protected Animator _anim;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _JumpPower;
    protected Vector2 movePower = Vector2.zero;
    protected bool _canJump = true;

    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            _anim.SetBool("Move", true);
        }
        else
        {
            _anim.SetBool("Move", false);
        }
        movePower = new Vector2(Input.GetAxisRaw("Horizontal") * _speed, _rig.linearVelocity.y);
        if (Input.GetButtonDown("Jump") && _canJump)
        {
            _rig.AddForce(new Vector2(0, _JumpPower), ForceMode2D.Impulse);
            _canJump = false;
        }
    }

    public virtual void FixedUpdate()
    {
        _rig.linearVelocity = movePower;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _canJump = true;
    }
}
