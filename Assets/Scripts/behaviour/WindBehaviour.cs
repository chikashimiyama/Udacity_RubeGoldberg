using UnityEngine;

public class WindBehaviour : MonoBehaviour
{
	private void OnTriggerStay(Collider col)
	{
		if(col.attachedRigidbody)
			col.attachedRigidbody.AddForce(-transform.forward.x, 0, -transform.forward.z);
	}
}
