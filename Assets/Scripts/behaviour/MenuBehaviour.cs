using UnityEngine;
using System;
using Valve.VR;

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

    [SteamVR_DefaultAction("swipe", "default")]
    public SteamVR_Action_Vector2 thumbStickPosition;
    
    public int NumberOfObjects()
    {
        return rubeGoldbergObjects_.Length;
    }

    void Update()
    {
        var result = thumbStickPosition.GetAxis(SteamVR_Input_Sources.Any);
        Debug.Log(result.x);
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