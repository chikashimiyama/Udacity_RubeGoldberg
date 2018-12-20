using Valve.VR;

public interface ISceneLoader
{
    void Load();
}

public class SceneLoader: ISceneLoader
{
    private readonly string sceneName_;

    public SceneLoader(string sceneName)
    {
        sceneName_ = sceneName;
    }
    
    public void Load()
    {
        SteamVR_LoadLevel.Begin(sceneName_);
    }
}
