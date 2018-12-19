using UnityEngine;
using System;

public interface IMenuBehaviour
{
    int NumberOfObjects();
    void Show(int index);

    event Action LeftButtonPressed;
    event Action RightButtonPressed;
}

public class MenuBehaviour : MonoBehaviour, IMenuBehaviour
{
    [SerializeField] private GameObject[] rubeGoldbergObjects_;

    public int NumberOfObjects()
    {
        return rubeGoldbergObjects_.Length;
    }

    public void Show(int index)
    {
        foreach (var obj in rubeGoldbergObjects_)
        {
            obj.SetActive(false);
        }

        rubeGoldbergObjects_[index].SetActive(true);
    }

    public event Action LeftButtonPressed;
    public event Action RightButtonPressed;
}