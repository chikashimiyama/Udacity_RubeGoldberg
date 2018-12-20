using UnityEngine;

public class CircleTextBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] texts_;
    private float TIME = 8f;
    private float sum_ = 0f;
    private int index_ = 0;

    void Update()
    {
        sum_ += Time.deltaTime;

        if (sum_ > TIME)
        {
            sum_ = 0f;
            index_++;
            if (index_ == texts_.Length)
                index_ = 0;

            foreach (var text in texts_)
            {
                text.SetActive(false);
            }

            texts_[index_].SetActive(true);
        }
    }
}