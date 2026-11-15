using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    protected CharaStatus _CharaStatus;

    protected int _CurrentHp;

    public int CurrentHp => _CurrentHp;

    public int MaxHp => _CharaStatus._MaxHp;

    protected virtual void Awake()
    {
        _CharaStatus = GetComponent<CharaStatus>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        
    }

    // FixedUpdate is called once per physics frame
    protected virtual void FixedUpdate()
    {
        
    }
}
