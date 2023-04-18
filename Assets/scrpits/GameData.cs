using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameData : MonoBehaviour
{
    public bool inGame = true;
    public GameObject pausemenu;
    public GameObject overmenu;
    public GameObject newscoremenu;
    public TMP_InputField input;

    public float wavelength = 30f;
    float current;
    int currentwave = 1;
    public spawner sp;
    public TextMeshProUGUI WaveCounter;
    public TextMeshProUGUI randtext;
    public float curve = 0.75f;

    public Transform topleft, bottomright;
    public gen g;

    public float currentpoints = 0f;
    public TextMeshProUGUI scoredisplay;
    public float comborate = 1f;
    public float drate = 0.1f;
    [SerializeField] Slider comboslider;
    [SerializeField] float maxscoremult = 50f;
    [SerializeField] TextMeshProUGUI cd;

    public List<string> nouns = new List<string>();
    public GameObject contentslider;
    [SerializeField] Vector3 offset;
    [SerializeField] float iterativeoffset;
    [SerializeField] int it = 0;
    public Plate plateprefab;

    float cooldown = 1f;

    public float gencheck = 20f;
    float cur;

    public TextMeshProUGUI sname;
    public TextMeshProUGUI sscore;
    void Start()
    {
        if (sname != null)
        {
            sname.text = PlayerPrefs.GetString("PlayerName");
        }
        if (sscore != null)
        {
            sscore.text = "" + PlayerPrefs.GetInt("PlayerScore", 0);
        }

        if (newscoremenu != null)
        {
            newscoremenu.SetActive(false);
        }

        if (pausemenu != null && inGame)
        {
            pausemenu.SetActive(false);
        }
        if (overmenu != null && inGame)
        {
            overmenu.SetActive(false);
        }
        if (WaveCounter != null)
        {
            WaveCounter.text = "Wave " + currentwave;
        }
        current = wavelength;
        
        gencheck = cur;
    }

    void FixedUpdate()
    {
        if (inGame)
        {
            cur -= Time.fixedDeltaTime;
            if (cur <= 0)
            {
                gen g = FindObjectOfType(typeof(gen)) as gen;
                if (g == null)
                {
                    SpawnGen();
                }
                cur = gencheck;
            }
            cooldown -= Time.fixedDeltaTime;
            current -= Time.fixedDeltaTime;
            if (current <= 0)
            {
                current = wavelength;
                currentwave++;
                WaveCounter.text = "Wave " + currentwave;
                sp.rate *= curve;
            }

            if (comborate > 1f)
            {
                comborate -= Time.fixedDeltaTime * drate;
            }
            else
            {
                comborate = 1f;
            }
            cd.text = "X" + (int)comborate;
            comboslider.value = comborate;
            Debug.Log(comborate);
        }
    }
    

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Debug.Log("Quit");
        Application.Quit();
    }

    public void GameOver()
    {
        overmenu.SetActive(true);
        Time.timeScale = 0;

        if (currentpoints > PlayerPrefs.GetInt("PlayerScore"))
        {
            newscoremenu.SetActive(true);
        }
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
       
    }

    public void OpenMenu()
    {
        overmenu.SetActive(true);
        pausemenu.SetActive(false);
    }

    public void CloseMenu()
    {
        overmenu.SetActive(false);
        pausemenu.SetActive(true);
    }


    public void acceleratetime(float boost)
    {
        current -= boost;
    }

    public void textrandomize()
    {
        string b = "Every " + nouns[Random.Range(0, nouns.Count)] + " has been replaced with a/an " + nouns[Random.Range(0, nouns.Count)];
        randtext.text = b;
        //results.Add(b);
        Plate clone;
        clone = Instantiate(plateprefab, contentslider.transform.position + offset + new Vector3(0, iterativeoffset * it, 0), Quaternion.identity);
        clone.gameObject.transform.SetParent(contentslider.transform);
        clone.box.text = b;
        it++;
    }

    public void SpawnGen()
    {
        if (cooldown <= 0)
        {
            gen clone;
            clone = Instantiate(g, new Vector3(Random.Range(topleft.position.x, bottomright.position.x), 0.7f, Random.Range(topleft.position.z, bottomright.position.z)), Quaternion.identity);
            clone.gd = this;
            cooldown = 3f;
        }
    }

    public void Addpoints(float amount)
    {
        currentpoints += amount * comborate;
        scoredisplay.text = "Score: " + (int)currentpoints;
        if (comborate < maxscoremult)
        {
            comborate++;
        }
        else
        {
            comborate = maxscoremult;
        }
        
    }

    public void NewScore()
    {
        PlayerPrefs.SetString("PlayerName", input.text);
        PlayerPrefs.SetInt("PlayerScore", (int)currentpoints);
        newscoremenu.SetActive(false);
    }
   
}
