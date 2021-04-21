using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Triggers : MonoBehaviour
{
    //Escape Points
    public Transform Vent;
    public GameObject EscapePointOne;


    //Inmates
    public Transform Bill;
    public Transform Bob;
    public Transform Joe;
    public Transform Schmoe;
    public Transform Jeff;

    public float maxAllowedDist = 4f;
    public Text dialogue;

    public AudioClip BobSaysHi;
    public AudioClip JoeSaysHi;
    public AudioClip BillSaysHi;
    public AudioClip SchmoeSaysHi;
    public AudioClip JeffSaysHi;
    public AudioSource CharacterVoiceBox;


    //Inventory Management
    public List<GameObject> Inventory = new List<GameObject>();
    public GameObject Wrench;
    public GameObject KeyCard;
    public GameObject Knife;
    public void AddItemToList(GameObject ItemToAdd)
    {
        Inventory.Add(ItemToAdd);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            Debug.Log("Player has collected an item");
            AddItemToList(gameObject);
        }
    }
    //End Inventory Management

    void Start()
    {
        EscapePointOne = GameObject.Find("Vent");
    }


    void Update()
    {
        float ventDist = Vector3.Distance(Vent.position, transform.position);
        if (ventDist < maxAllowedDist && (Inventory.Contains(Wrench))) 
        {
            dialogue.text = "You used your wrench to unscrew the vent.";
            GameObject.Destroy(EscapePointOne);
        }
        else
        {
            dialogue.text = "You need some sort of tool to get through here.";
        }
        if (ventDist > maxAllowedDist)
        {
            dialogue.text = "";
        }

        //bills interaction call
        float billDist = Vector3.Distance(Bill.position, transform.position);
        if (billDist < maxAllowedDist)
        {
            PlayerInteractWithBill();
        }
        //end bills interaction call

        //Bobs interaction call
        float bobDist = Vector3.Distance(Bob.position, transform.position);
        if (bobDist < maxAllowedDist)
        {
            PlayerInteractedWithBob();
        }
        //end bobs interaction call

        //Joe interaction call
        float joeDist = Vector3.Distance(Joe.position, transform.position);
        if (joeDist < maxAllowedDist)
        {
            PlayerInteractedWithJoe();
        }
        //end bobs interaction call
    }

    //Track How Many Times Player has interacted with inmates to effect dialogue and content
    public int PlayerSpokeToJoe;
    public int PlayerSpokeToSchmoe;
    public int PlayerSpokeToBill;
    public int PlayerSpokeToBob;
    public int PlayerSpokeToJeff;




    void PlayerInteractedWithJoe()
    {
        CharacterVoiceBox.PlayOneShot(JoeSaysHi);
        Debug.Log("Collided With Joe");
        PlayerSpokeToJoe++;

        if(PlayerSpokeToJoe == 1)
        {
            dialogue.text = "Joe: I'm Joe. You got in last night?";
        }

        if(PlayerSpokeToJoe == 2)
        {
            dialogue.text = "Joe: What are you doing...";
        }
    }
    void PlayerInteractWithBill()
    {
        CharacterVoiceBox.PlayOneShot(BillSaysHi);
        Debug.Log("Collided with Bill");
        PlayerSpokeToBill++;

        if (PlayerSpokeToBill == 1 && PlayerSpokeToBob > 0)
        {
            dialogue.text = "Bill: Bob? He's been locked down for a few days. Tried to break out.\n He usually plays cards when he's not locked down.";
        }
    }

    void PlayerInteractedWithBob()
    {
        CharacterVoiceBox.PlayOneShot(BobSaysHi);
        Debug.Log("Collided with Bob");
        PlayerSpokeToBob++;

        if(PlayerSpokeToBob == 1)
        {
            dialogue.text = "Bob: ...";
        }
    }

    void PlayerInteractedWithSchmoe()
    {
        CharacterVoiceBox.PlayOneShot(SchmoeSaysHi);
        Debug.Log("Collided with Schmoe");
        PlayerSpokeToSchmoe++;

        if(PlayerSpokeToSchmoe == 1)
        {
            dialogue.text = "Schmoe: I'm Schmoe...";
        }
        if(PlayerSpokeToSchmoe == 2 && PlayerSpokeToJoe == 0)
        {
            dialogue.text = "Schmoe: Find someone else to bother kid.";
        }

        if(PlayerSpokeToSchmoe == 2 && PlayerSpokeToJoe > 0)
        {
            dialogue.text = "Schmoe: Joe? He's my buddy. A bit weird. I'd leave him alone if I were you";
        }


    }

    void PlayerInteractedWithJeff()
    {
        CharacterVoiceBox.PlayOneShot(JeffSaysHi);
        Debug.Log("Collided with Jeff");
        PlayerSpokeToJeff++;

        if(PlayerSpokeToJeff == 1)
        {
            dialogue.text = "Jeff: Can I help you with something?";
        }
    }

}
