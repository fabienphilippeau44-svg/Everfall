using UnityEngine;

public class MusicGameScene : MonoBehaviour
{
    [SerializeField] private AudioClip AudioClip;
    void Start()
    {
        SoundManager.Instance.PlayMusic(AudioClip);
    }
}
