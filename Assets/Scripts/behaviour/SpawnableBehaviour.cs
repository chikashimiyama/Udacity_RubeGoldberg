using UnityEngine;

public interface ISpawnableBehaviour
{
    void SpawnAt(int index, Vector3 position);
}

public class SpawnableBehaviour : MonoBehaviour, ISpawnableBehaviour
{
    [SerializeField] private GameObject[] spawnables_;

    public void SpawnAt(int index, Vector3 position)
    {
        spawnables_[index].transform.position = position;
        spawnables_[index].SetActive(true);
    }

}
