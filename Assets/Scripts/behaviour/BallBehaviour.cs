using System;
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
        material_ = GetComponent<Material>();
        rigidbody_ = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Ground"))
        {
            if(FloorTouched != null)
                FloorTouched.Invoke();
        }

    }

    public void Reset()
    {
        rigidbody_.isKinematic = true;
        transform.position = new Vector3(0.533f, 0.861f, 0.48f);
        rigidbody_.isKinematic = false;
    }

    public bool Warn
    {
        set { material_.color = value ? Color.red : Color.white; }
    }

    public event Action FloorTouched;
}
