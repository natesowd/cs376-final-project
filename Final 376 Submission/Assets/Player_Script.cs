using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Script : MonoBehaviour
{

    AudioSource my_AudioSource;

    public AudioClip sound;

    public AudioClip win;

    public AudioClip fire_sound;

    public bool fuel;

    public bool food;

    public bool reload_level;

    public float win_time;

    public Rigidbody2D body;

    public int speed_boost;


    // Start is called before the first frame update
    void Start()
    {
        my_AudioSource = GetComponent<AudioSource>();

        body = gameObject.GetComponent<Rigidbody2D>();

        fuel = false;

        food = false;

        reload_level = false;

        speed_boost = 2;


    }

    // Update is called once per frame
    void Update()
    {

        Scene curr_scene = SceneManager.GetActiveScene();

        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.MovePosition(body.position + new Vector2(2.00f, 0.0f) * Time.fixedDeltaTime * speed_boost);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.MovePosition(body.position + new Vector2(-2.00f, 0.0f) * Time.fixedDeltaTime * speed_boost);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.MovePosition(body.position + new Vector2(0.00f, 2.0f) * Time.fixedDeltaTime * speed_boost);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            body.MovePosition(body.position + new Vector2(0.00f, -2.0f) * Time.fixedDeltaTime * speed_boost);
        }

        if (Time.time > 20 && fuel == false)
        {
            StartCoroutine(first_level());
        }

        if (curr_scene.name == "Level1" && Time.time > 40)
        {
            StartCoroutine(first_level());


        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "FirstMaze" || col.gameObject.name == "SecondMaze" || col.gameObject.name == "ThirdMaze" || col.gameObject.name == "FourthMaze" || col.gameObject.name == "FifthMaze" || col.gameObject.name == "SixthMaze" || col.gameObject.name == "SeventhMaze" || col.gameObject.name == "EighthMaze")
        {
            my_AudioSource.PlayOneShot(sound);
        }

        if (col.gameObject.name == "fire")
        {
            fuel = true;
            my_AudioSource.PlayOneShot(fire_sound);
        }

        if (col.gameObject.name == "apple")
        {
            food = true;
        }

        if (col.gameObject.name == "Finish")
        {
            if (food == true && fuel == true)
            {
                my_AudioSource.PlayOneShot(win);
                StartCoroutine(first_level());

                
            }
        }

        if (col.gameObject.name == "helmet")
        {
            speed_boost = 7;
            
        }
    }

    IEnumerator first_level()
    {
        yield return new WaitForSeconds(3);
        Scene curr_scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curr_scene.name);


    }

    IEnumerator second_level()
    {
        yield return new WaitForSeconds(3);
        Scene curr_scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curr_scene.name);

    }


}
