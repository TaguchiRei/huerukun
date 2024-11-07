using UnityEngine;

public class PlayerMove : Move
{
    [HideInInspector] public static Move Instance = default;
    [SerializeField] GameObject _increase;
    //シングルトンパターン
    private void Awake()
    {
        if (Instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public override void Update()
    {
        base.Update();
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_increase,transform.position,Quaternion.identity);
        }
    }
}
