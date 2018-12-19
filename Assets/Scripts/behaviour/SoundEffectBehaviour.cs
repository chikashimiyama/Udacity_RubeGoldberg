using UnityEngine;

public interface ISoundEffectBehaviour
{
    void PlayFail();
    void PlayClear();
    void PlayStar();
}

public class SoundEffectBehaviour : MonoBehaviour, ISoundEffectBehaviour
{
    private AudioClip fail_;
    private AudioClip star_;
    private AudioClip clear_;

    private AudioSource audioSource_;

    private void Start()
    {
        fail_ = Resources.Load<AudioClip>("Audio/fail.mp3");
        star_ = Resources.Load<AudioClip>("Audio/star.wav");
        clear_ = Resources.Load<AudioClip>("Audio/clear.wav");

        audioSource_ = gameObject.AddComponent<AudioSource>();
    }

    public void PlayFail()
    {
        audioSource_.PlayOneShot(fail_);
    }

    public void PlayClear()
    {
        audioSource_.PlayOneShot(clear_);
    }

    public void PlayStar()
    {
        audioSource_.PlayOneShot(star_);
    }
}
