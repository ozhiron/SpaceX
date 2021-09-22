using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    public float HP = 100;
    public Text HPText;

    [Header("Fix")]
    public GameObject slider;
    public GameObject pressEToFix;

    [Header("Spawn ships")]
    public GameObject[] savedShip;
    public GameObject bigShip;

    [Header("Message")]
    public GameObject console;

    [Header("UI")]
    public GameObject deathPenal;

    [Header("EndTimeline")]
    public GameObject endTimeline;

    void Update()
    {
        HPText.text = HP + " %";

        if (HP > 30)
            HPText.color = Color.green;
        else if (HP < 30 && HP > 0)
            HPText.color = Color.red;
        else if (HP <= 0)
        {
            HPText.text = "0 %";
            GameManger.instance.isDead = true;
            deathPenal.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BrokenShip") && GameManger.instance.isDead == false)
            pressEToFix.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("BrokenShip") && GameManger.instance.isDead == false)
        {
            
            if (Input.GetKey(KeyCode.E))
            {
                other.transform.GetChild(0).gameObject.SetActive(true);
                slider.SetActive(true);
                pressEToFix.SetActive(false);
                slider.GetComponent<Slider>().value += Time.fixedDeltaTime * 4;
            }
            else
            {
                other.transform.GetChild(0).gameObject.SetActive(false);
                slider.GetComponent<Slider>().value = 0;
                slider.SetActive(false);
            }

            if (slider.GetComponent<Slider>().value == slider.GetComponent<Slider>().maxValue)
            {
                if (other.gameObject.name.Equals("BIGBIGBIGSHIP(Clone)") == false)
                {
                    console.GetComponent<MessageController>().SendMessage(false);
                    GameManger.instance.score += 1;
                    slider.GetComponent<Slider>().value = 0;
                    slider.SetActive(false);
                    Instantiate(savedShip[Random.Range(0, savedShip.Length)], other.transform.position, other.transform.rotation);
                    Destroy(other.gameObject);
                }
                else
                {
                    console.GetComponent<MessageController>().SendMessage(true);
                    GameManger.instance.score += 1;
                    slider.GetComponent<Slider>().value = 0;
                    slider.SetActive(false);
                    Instantiate(bigShip, other.transform.position, other.transform.rotation);
                    endTimeline.SetActive(true);
                    Destroy(other.gameObject);
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("BrokenShip") && GameManger.instance.isDead == false)
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
            slider.SetActive(false);
            pressEToFix.SetActive(false);
        }
    }
}
