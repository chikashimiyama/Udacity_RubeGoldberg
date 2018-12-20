using UnityEngine;

public class BladeBehaviour : MonoBehaviour {

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * 3000f));
    }
}
