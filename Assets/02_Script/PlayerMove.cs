using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Move
{
    [HideInInspector] public static Move Instance = default;
    [SerializeField] GameObject _increase;
    List<GameObject> _increaseList;
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
            _increaseList.Add(Instantiate(_increase, transform.position, Quaternion.identity));
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (var item in _increaseList)
            {
                Destroy(item.gameObject);
                _increaseList.Remove(item);
            }
        }
    }
}
