using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    //Necesitamos exponer los parámetros de volumen de los canales que tengamos en el mixer para poder acceder desde código
    [SerializeField] private AudioMixer _audioMixer;
    private Slider _volumeSlider;
    private Toggle _muteToggle;
    private bool muted;
    //nombre del parámetro que hemos expuesto
    [SerializeField] private string _volumeParameter;

    void Awake()
    {
        _volumeSlider = GetComponent<Slider>();
        //Añadir automaticamente funciones a botones o sliders (onValueChanged en este caso porque es un slider, en botones sería onClick).
        //AddListener añade la función que pongamos dentro de los parentesis
        _volumeSlider.onValueChanged.AddListener(ChangeVolume);

        _muteToggle = GetComponentInChildren<Toggle>();
        _muteToggle.onValueChanged.AddListener(Mute);
    }

    void Start()
    {
        //Para ajustar que al abrir el juego se cargue el volumen guardado
        float volume = PlayerPrefs.GetFloat(_volumeParameter, 1f);

        _audioMixer.SetFloat(_volumeParameter, Mathf.Log10(volume) * 20);
        _volumeSlider.value = volume;
    }

    //el valor es el float que pilla el slider, como tal llamado value en el inspector del slider
    void ChangeVolume(float value)
    {
        //en lugar de poner el parametro del value a secas, lo metemos en el mathf.log10 para que el cambio de volumen sea más progresivo y no tan exponencial o logarítmico
        _audioMixer.SetFloat(_volumeParameter, Mathf.Log10(value) * 20);
    }

    /* ---------------------------------------------------------------------------------------------------------------------------------------- */

    //Interpolación lineal
    //value --> actual
    //min slider --> valor mínimo del slider -> 0
    //max slider --> valor máximo del slider -> 100
    //min range --> valor mínimo nuevo -> -80
    //max range --> valor máximo nuevo -> 0
    // (valor_slider / (max_slider - min_slider)) * (max_rango - min_rango) + min_rango

    /* ---------------------------------------------------------------------------------------------------------------------------------------- */

    void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _volumeSlider.value);
    }

    void Mute(bool soundEnable)
    {
        //_audioMixer.SetFloat(_volumeParameter, )
        if (soundEnable)
        {
            float lastVolume = PlayerPrefs.GetFloat(_volumeParameter, 1f);
            _audioMixer.SetFloat(_volumeParameter, lastVolume);
            muted = false;
        }
        else
        {
            PlayerPrefs.SetFloat(_volumeParameter, _volumeSlider.value);
            _audioMixer.SetFloat(_volumeParameter, _volumeSlider.minValue);
            muted = true;
        }
    }
}
