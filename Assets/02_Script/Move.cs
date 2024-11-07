using Unity.VisualScripting;
using UnityEngine;

public abstract class Move : MonoBehaviour
{
    [SerializeField] GameObject[] _foot;
    [SerializeField] Rigidbody2D _rig;
    [SerializeField] Animator _anim;
    [SerializeField] float _speed;
    [SerializeField] float _JumpPower;
    Vector2 movePower = Vector2.zero;
    bool _canJump = true;

    // Update is called once per frame
    public virtual void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            _anim.SetBool("Move",true);
        }
        else
        {
            _anim.SetBool("Move", false);
        }
        movePower = new Vector2(Input.GetAxisRaw("Horizontal") * _speed, _rig.linearVelocity.y);
        if (Input.GetButtonDown("Jump") && _canJump)
        {
            _rig.AddForce(new Vector2(0,_JumpPower) , ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        _rig.linearVelocity = movePower;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _canJump = true;
        }
    }
}
