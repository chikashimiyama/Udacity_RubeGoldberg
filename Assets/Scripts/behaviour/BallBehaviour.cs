﻿using System;
using UnityEngine;

public interface IBallBehaviour
{
    void Reset();
    bool Warn { set; }
    event Action FloorTouched;
}

public class BallBehaviour : MonoBehaviour, IBallBehaviour
{
    private Material material_;
    private Rigidbody rigidbody_;

    private void Start()
    {
        material_ = GetComponent<Renderer>().material;
        rigidbody_ = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Ground")) return;
        if(FloorTouched != null)
            FloorTouched.Invoke();
    }

    public void Reset()
    {
        rigidbody_.isKinematic = true;
        transform.position = new Vector3(0f, 1.082f, 0.671f);
        rigidbody_.isKinematic = false;
    }

    public bool Warn
    {
        set { material_.color = value ? Color.red : Color.white; }
    }

    public event Action FloorTouched;
}
