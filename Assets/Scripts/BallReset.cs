using UnityEngine;

public class BallReset : MonoBehaviour
{

    private Rigidbody rigidbody_;

    private void Start()
    {
        rigidbody_ = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Ground")) return;
        
        rigidbody_.isKinematic = true;
        transform.position = new Vector3(0.533f, 0.861f, 0.48f);
        rigidbody_.isKinematic = false;
    }
}
