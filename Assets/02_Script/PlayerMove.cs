using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Move
{
    [HideInInspector] public static Move Instance = default;
    [SerializeField] GameObject _increase;
    List<GameObject> _increaseList = new();
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
            var inc = Instantiate(_increase, transform.position, Quaternion.identity);
            _increaseList.Add(inc);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            var n = _increaseList.Count;
            for (int i = 0; i < n; i++)
            {
                Destroy(_increaseList[i]);
            }
            _increaseList.Clear();
        }
    }
}
