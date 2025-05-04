using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCBehavior : MonoBehaviour
{
    public NpcState currentState = NpcState.IdleAtHome;
    
    public Transform home;

    public Transform work;
    
    public float speed = 2.0f;
    
    private Vector2 _newVelocity;

    private float _waitTimer = 0.0f;
    private float _moveTimer = 1.0f;
    private Vector2 _moveOffset = Vector2.zero;

    private void Start()
    {
        JobManager.instance.RequestJob(this);
    }

    public void Update()
    {
        switch (currentState)
        {
            case NpcState.IdleAtHome:
                StayNear(home.position);
                break;
            case NpcState.GoingToWork:
                MoveTo(work.position);
                if (Vector2.Distance(transform.position, work.position) <= 5.0f)
                {
                    currentState = NpcState.Working;
                }
                break;
            case NpcState.Working:
                StayNear(work.position);
                break;
        }
    }

    public void AssignJob(GameObject job)
    {
        work = job.transform;
        currentState = NpcState.GoingToWork;
    }

    public void SetHome(GameObject home)
    {
        this.home = home.transform;
    }

    private void StayNear(Vector2 position)
    {
        float distance = Vector2.Distance(transform.position, position);

        if (distance > 5.0f)
        {
            transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
            return;
        }
        
        if (_moveTimer > 0.0f)
        {
            _moveTimer -= Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, position + _moveOffset, speed * Time.deltaTime);
        }
        else
        {
            _waitTimer -= Time.deltaTime;
            if (_waitTimer < 0.0f)
            {
                _moveTimer = Random.Range(3.0f, 5.0f);
                _moveOffset = new Vector2(Random.Range(-4.0f, 4.0f), 0);
                _waitTimer = Random.Range(1.0f, 3.0f);
            }
        }
    }
    
    private void MoveTo(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    
}

public enum NpcState
{
    IdleAtHome,
    GoingToWork,
    Working,
}