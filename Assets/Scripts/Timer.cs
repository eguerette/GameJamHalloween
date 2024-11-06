using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private InfosNiveau _infosNiveau;
    [SerializeField] private TMP_Text timerText;

    private bool _decompteActif = false;

    public UnityEvent auChangementDuTemps;
    public UnityEvent aLaFinDuTemps;

    void Start()
    {
        DemarrerDecompte();
    }

    void Update()
    {
        if (_decompteActif)
        {
            if (_infosNiveau.temps > 0)
            {
                _infosNiveau.temps -= Time.deltaTime;

                int minutes = Mathf.FloorToInt(_infosNiveau.temps / 60);
                int secondes = Mathf.FloorToInt(_infosNiveau.temps % 60);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, secondes);

                auChangementDuTemps.Invoke();
            }
            else
            {
                _infosNiveau.temps = 0;
                _decompteActif = false;

                timerText.text = "00:00";
                aLaFinDuTemps.Invoke();

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void DemarrerDecompte()
    {
        _infosNiveau.temps = _infosNiveau.tempsInitial;
        _decompteActif = true;

        int minutes = Mathf.FloorToInt(_infosNiveau.temps / 60);
        int secondes = Mathf.FloorToInt(_infosNiveau.temps % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, secondes);
    }
}
