using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public static Ball Instance { set; get; }

    public GameObject gameControllerObject;
    GameController gc;
    Block heath;
    Rigidbody2D rb;
    AudioSource audio;
    public AudioClip clip;
    public GameObject deathPanel;
    public GameObject extraLifePanel;
    RaycastHit2D hit;
    SpriteRenderer sr;
    public GameObject explodeObject;
    Component movenemtScript;
    Quaternion ballRotation;
    public Button adButton;
    public Sprite[] ballSkin = new Sprite[20];
    public TrailRenderer Ctrail;
    //public Sprite[] adImage = new Sprite[5];

    public float latitudeSpeed = 2f;
    public float longitudeSpeed = 4f;

    private int power;
    private int i;
    bool isDead;
    float timer;

    private void Awake()
    {
        Instance = this;
    }

    void Start () {
        if (gameControllerObject == null)
            gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        Time.timeScale = 1;
        sr = GetComponent<SpriteRenderer>();
        gc = gameControllerObject.GetComponent<GameController>();
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        isDead = false;
        power = SaveManager.Instance.state.stars;
        LoadSkin();
    }

	void Update () {
        if (Input.touchCount > 0 && longitudeSpeed == 4f)
        {
            longitudeSpeed = 20f;
            Ctrail.time = 2;
        }
        if (Input.touchCount > 0 && longitudeSpeed == -4f)
        {
            longitudeSpeed = -20f;
            Ctrail.time = 2;
        }
        else if (Input.touchCount == 0 && longitudeSpeed == 20f)
        {
            longitudeSpeed = 4f;
        }
        else if (Input.touchCount == 0 && longitudeSpeed == -20f)
        {
            longitudeSpeed = -4f;
        }

        if (Input.touchCount == 0)
        {
            if (Ctrail.time > 0) Ctrail.time -= 0.05f;
        }

        if (isDead)
        {
            timer += Time.deltaTime;
            //if (timer >= i && timer < 5 && AdReward.Instance.rewardBasedVideo.IsLoaded())
            //{
            //    adButton.GetComponent<Image>().sprite = adImage[i];
            //    i++;
            //}
            if (timer >= 5f && AdReward.Instance.rewardBasedVideo.IsLoaded())
            {
                Time.timeScale = 0;
                deathPanel.SetActive(true);
                extraLifePanel.SetActive(false);
                timer = 0;
            }
            else if (timer >= 1.5f && !AdReward.Instance.rewardBasedVideo.IsLoaded() && i == 0)
            {
                Time.timeScale = 0;
                deathPanel.SetActive(true);
                extraLifePanel.SetActive(false);
                timer = 0;
            }
        }

        gc.Power = power;
    }

    void LostPower()
    {
        //Dotniecie z blokiem przeszkoda, zmiana power i scorce
        if (power >= heath.Health)
        {
            gc.Scorce += heath.Health;
        }
        else if (power < heath.Health)
        {
            gc.Scorce += power;
        }
        power -= heath.Health;
        //smierc
        if (power < 0)
        {
            if (!isDead)
            {
                if (AdReward.Instance.rewardBasedVideo.IsLoaded())
                {
                    extraLifePanel.SetActive(true);
                }
                sr.enabled = false;
                Instantiate(explodeObject, this.gameObject.transform.position, ballRotation);
                isDead = true;
            }
        }
    }

    private void FixedUpdate()
    {
        //ruch pileczki
        if (!isDead)
        {
            transform.Translate(longitudeSpeed * Time.deltaTime, latitudeSpeed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Dotniecie z sciana
        if (collision.tag == "Wall" || collision.tag == "Wal")
        {
            if (!isDead)
            {
                longitudeSpeed = longitudeSpeed * -1;
                audio.time = 0.1f;
                audio.PlayOneShot(clip, 0.8f);
            }
        }

        //Dotkniecie z blok przeszkoda
        if (collision.tag == "Block")
        {
            heath = collision.GetComponent<Block>();

            LostPower();
        }
        //Dotkniecie z star
        if(collision.tag == "StarFirst")
        {
            power += 1;
            SaveManager.Instance.state.money += 1;
            SaveManager.Instance.Save();
        }
        if (collision.tag == "StarSecond")
        {
            power += 3;
            SaveManager.Instance.state.money += 3;
            SaveManager.Instance.Save();
        }
        if (collision.tag == "StarThird")
        {
            power += 5;
            SaveManager.Instance.state.money += 5;
            SaveManager.Instance.Save();
        }
        if (collision.tag == "Spike")
        {
            if (!isDead)
            {
                if (AdReward.Instance.rewardBasedVideo.IsLoaded())
                {
                    extraLifePanel.SetActive(true);
                }
                sr.enabled = false;
                Instantiate(explodeObject, this.gameObject.transform.position, ballRotation);
                isDead = true;
            }
        }
    }

    void LoadSkin()
    {
        sr.sprite = ballSkin[SaveManager.Instance.state.SkinUse];
    }

    public void ExtraLife()
    {
        DestroyCopy();
        if (power < SaveManager.Instance.state.stars) power = SaveManager.Instance.state.stars;
        SaveManager.Instance.state.money += 100;
        sr.enabled = true;
        isDead = false;
        transform.position = new Vector3(0, this.gameObject.transform.position.y, 0);
        extraLifePanel.SetActive(false);
        i = 0;
        timer = 0;
        Pause.Instance.ContinueGame();
    }
    public void GameOver()
    {
        if (AdReward.Instance.rewardBasedVideo.IsLoaded())
        {
            Time.timeScale = 0;
            AdReward.Instance.rewardBasedVideo.Show();
        }
    }
    void DestroyCopy()
    {
        var obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject g in obstacles)
        {
            Destroy(g);
        }
        var spikes = GameObject.FindGameObjectsWithTag("Spike");
        foreach (GameObject g in spikes)
        {
            Destroy(g);
        }
    }
}
