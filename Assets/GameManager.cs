using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private int selectedZombiePosition = 0;
    public Text scoreText;
    private int score = 0;
    // Created a Function to GetCurrent Zombie Selected
    public GameObject selectedZombie;
    // Add a List of Zombies
    public List<GameObject> zombies;
    // Add New parameters to Change 3d Vector Size from Zombies
    public Vector3 selectedSize;
    public Vector3 defaultSize;

    // Start is called before the first frame update
    void Start()
    {
        SelectZombie(selectedZombie);
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left")) 
        {
            GetZombieLeft();
        }

        if (Input.GetKeyDown("right")) 
        {
            GetZombieRight();
        }

        if (Input.GetKeyDown("up")) 
        {
            PushUp();
        }
    }

    void GetZombieLeft()
    {
        if (selectedZombiePosition == 0)
        {
            selectedZombiePosition = 3;
            SelectZombie(zombies[selectedZombiePosition]);
        } else
        {
            selectedZombiePosition = selectedZombiePosition - 1;
            SelectZombie(zombies[selectedZombiePosition]);
        }
    }

    void GetZombieRight()
    {
        if (selectedZombiePosition == 3)
        {
            selectedZombiePosition = 0;
            SelectZombie(zombies[selectedZombiePosition]);
        } else
        {
            selectedZombiePosition = selectedZombiePosition + 1;
            SelectZombie(zombies[selectedZombiePosition]);
        }
    }

    // SelectCurrentZombieSelected and Update Size
    void SelectZombie(GameObject newZombie)
    {
        selectedZombie.transform.localScale = defaultSize;
        selectedZombie = newZombie;
        newZombie.transform.localScale = selectedSize;
    }

    void PushUp()
    {
        Rigidbody rb = selectedZombie.GetComponent<Rigidbody> ();
        rb.AddForce(0,0, 10, ForceMode.Impulse); 
    }

    public void AddPoint()
    {
        score = score + 1;
        scoreText.text = "Score: " + score;
    }
}
