using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour {

    public int initialHealth;
    public int healthPerHeart;
    public GameObject heart;
    public float heartDistance = 32;
    public Sprite[] imageHearts;
    public GameObject player;

    ArrayList hearts = new ArrayList();
    int currentHealth;
    int maxHealth;

    // Use this for initialization
    void Start () {
        currentHealth = initialHealth;
        AddHearts(initialHealth / healthPerHeart);
	}
	
	public void AddHearts(int n)
    {
        for (int i = 0; i < n; i++)
        {
            GameObject heartInstance = Instantiate(heart, heart.transform.position + new Vector3(heartDistance * i, 0), Quaternion.identity);
            heartInstance.transform.SetParent(gameObject.transform, false);
            heartInstance.GetComponent<Image>().sprite = imageHearts[0];
            hearts.Add(heartInstance);
        }

        maxHealth += n * healthPerHeart;
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int damage)
    {
        currentHealth -= damage;
        

        int i = 1;
        GameObject heartDestroy = null;

        foreach (GameObject heart in hearts)
        {
            if (currentHealth >= i * healthPerHeart)
            {
                heart.GetComponent<Image>().sprite = imageHearts[0];
            }
            else
            {
                int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - currentHealth));
                if (currentHeartHealth != 0 && currentHeartHealth  <= healthPerHeart / 2)
                {
                    heart.GetComponent<Image>().sprite = imageHearts[1];
                }
                else if(currentHeartHealth <=0)
                {
                    heartDestroy = heart;
                }


            }
            i++;
        }
        if (heartDestroy != null)
        {
            hearts.Remove(heartDestroy);
            Destroy(heartDestroy);
        }

        if (currentHealth <= 0)
        {
            PlayerMovement.movementEnabled = false;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponents<AudioSource>()[1].Play();
            player.GetComponent<BoxCollider2D>().enabled = false;
            player.transform.Find("Head").GetComponentInChildren<Animator>().SetTrigger("IsDead");            
            Text gameOver = transform.GetChild(0).GetComponent<Text>();
            gameOver.enabled = true;
            StartCoroutine(LoadLevelAfterDelay(2.5f));
            
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Scene1");
    }
}
