using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Script : MonoBehaviour
{
    public float VanToc;
    public float TocDo;
    public float NhayLen;
    public AudioSource sound_death;
    public bool DuoiDat = true;
    public AudioSource coin;
    public AudioSource jump;
    private Animator HoatHoa;
    private Rigidbody2D r2d;
    public static bool isGameOver;
    public GameObject gameOverScreen;
    private float distanceTraveled = 0f;
    public TextMeshProUGUI distanceText;
    private void Awake()
    {
        isGameOver = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        HoatHoa = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HoatHoa.SetFloat("TocDo",TocDo);
        HoatHoa.SetBool("DuoiDat", DuoiDat);
        Nhay();
    }
    private void FixedUpdate()
    {
        DiChuyen();
        distanceTraveled += Mathf.Abs(TocDo) * Time.fixedDeltaTime;
        if (distanceText != null)
        {
            distanceText.text = "" + distanceTraveled.ToString("F2") + " m";
        }
    }
    void DiChuyen()
    {
        // cách 2:
        float PhimDiChuyen = Input.GetAxis("Horizontal");
        r2d.velocity = new Vector2(VanToc*PhimDiChuyen, r2d.velocity.y);
        TocDo = VanToc * PhimDiChuyen;
    }
    void Nhay()
    {
        if (Input.GetKey(KeyCode.Space) && DuoiDat)
        {
            //print("Nhảy lên đi đmmmmm");
            r2d.AddForce((Vector2.up)*NhayLen);
            jump.Play();
            DuoiDat = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trụ"))
        {
            DuoiDat = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ăn xu
        if (other.gameObject.name.Equals("xu"))
        {
            PlayerManager.numberOfCoins++;
            coin.Play();
            Destroy(other.gameObject);
            //Save coin
            //PlayerPrefs.SetInt("NumberOfCoins",PlayerManager.numberOfCoins);
            //gameObject.SetActive(false);
        }
        //die
        if (isGameOver && other.gameObject.name.Equals("Enemy") )
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            sound_death.Play();
        }
        
    }
}
