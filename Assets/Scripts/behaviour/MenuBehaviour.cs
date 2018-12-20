using UnityEngine;
using System;
using Valve.VR;

public interface IMenuBehaviour
{
    int NumberOfObjects();
    void Show(int index);
    Vector3 SpawnPosition { get; }

    event Action<float> SwipeUpdated;
    event Action SpawnPressed;
}

public class MenuBehaviour : MonoBehaviour, IMenuBehaviour
{
    [SerializeField] private GameObject[] rubeGoldbergObjects_;
    
    [SteamVR_DefaultAction("swipe", "default")]
    public SteamVR_Action_Vector2 thumbStickPosition;

    [SteamVR_DefaultAction("spawn", "default")]
    public SteamVR_Action_Boolean spawn;
    private const float SPAWN_DISTANCE = 1.5f;
    
    private void Update()
    {
        var select = thumbStickPosition.GetAxis(SteamVR_Input_Sources.RightHand).x;
        if (SwipeUpdated != null) 
            SwipeUpdated.Invoke(select);

        if (spawn.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            if (SpawnPressed != null) SpawnPressed.Invoke();
        }
    }
    
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

    public Vector3 SpawnPosition
    {
        get
        {
            return transform.position + transform.forward * SPAWN_DISTANCE;
        }
    }

    public event Action<float> SwipeUpdated;
    public event Action SpawnPressed;
}