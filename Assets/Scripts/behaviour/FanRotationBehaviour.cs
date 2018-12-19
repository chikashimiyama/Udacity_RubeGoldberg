using UnityEngine;

public class FanRotation : MonoBehaviour {

	[SerializeField] private float factor_ = 1f;
	
	private void Update () {
		gameObject.transform.Rotate(0f,0f, Time.deltaTime * factor_ );
	}
}
