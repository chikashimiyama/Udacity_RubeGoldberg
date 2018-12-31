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
    [SerializeField] private GameObject pedastal;
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
        var origin = pedastal.transform.position;
        origin.y = 1.082f;
        transform.position = origin;
        rigidbody_.isKinematic = false;
    }

    public bool Warn
    {
        set { material_.color = value ? Color.red : Color.white; }
    }

    public event Action FloorTouched;
}
