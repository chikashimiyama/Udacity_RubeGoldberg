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
        fail_ = Resources.Load<AudioClip>("SE/fail.mp3");
        star_ = Resources.Load<AudioClip>("SE/star.wav");
        clear_ = Resources.Load<AudioClip>("SE/clear.wav");

        audioSource_ = new AudioSource();
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
