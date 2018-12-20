using UnityEngine;

public class BallSpawnerBehaviour : MonoBehaviour
{
    [SerializeField] private float threshold_;
    [SerializeField] private GameObject demoBall_;

    private Rigidbody rbody_;
    private float sum_;

    void Start()
    {
        rbody_ = demoBall_.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        sum_ += Time.deltaTime;
        if (sum_ > threshold_)
        {
            Respawn();
            sum_ = 0f;
        }
    }

    private void Respawn()
    {
        rbody_.ResetInertiaTensor();
        rbody_.ResetCenterOfMass();
        rbody_.velocity = Vector3.zero;
        rbody_.position = gameObject.transform.position;
    }

}