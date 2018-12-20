using System;
using UnityEngine;

public interface IStarBehaviour : IVisibilityBehaviour, IEnterable
{
    bool Availability { set; }
}

public class StarBehaviour : MonoBehaviour, IStarBehaviour
{
    [SerializeField] private GameObject activeObject_;
    [SerializeField] private GameObject inactiveObject_;
    [SerializeField] private float factor_ = 100f;
    private SphereCollider colliderComponent_;

    private void Start()
    {
        colliderComponent_ = GetComponent<SphereCollider>();
    }

    public bool IsVisible
    {
        set
        {
            gameObject.SetActive(value);
        }
    }

    public bool Availability
    {
        set
        {
            if (value)
            {
                activeObject_.SetActive(true);
                inactiveObject_.SetActive(false);
            }
            else
            {
                activeObject_.SetActive(false);
                inactiveObject_.SetActive(true);
            }

            colliderComponent_.enabled = value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Entered == null)
            return;
        
        Entered.Invoke(this);
    }

    private void Update()
    {
        transform.Rotate(0f, Time.deltaTime * factor_,0f) ;
    }

    public event Action<IVisibilityBehaviour> Entered;
}
