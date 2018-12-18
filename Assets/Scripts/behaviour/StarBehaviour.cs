using System;
using UnityEngine;

public interface IStarBehaviour : IVisibilityBehaviour, IEnterable
{     
}

public class StarBehaviour : MonoBehaviour, IStarBehaviour {

    [SerializeField] private float factor_ = 100f;

    public bool IsVisible
    {
        set
        {
            gameObject.SetActive(value);
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
