using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public enum NumPlayer
    {
        P1,
        P2
    }

    public AudioSource sfxPlayer = null;
    public SpriteRenderer rend;
    private Color playerColor;

    public NumPlayer numPlayer;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 5f;

    public string weapon = "standard";
    
    bool canShoot = true;

    Transform playerTransform;

    void Start()
    {
        playerColor = GetComponent<PlayerCharacteristics>().playerColor;
        rend = GetComponent<SpriteRenderer>();
        rend.color = playerColor;

        playerTransform = gameObject.GetComponent<Transform>();

        if(sfxPlayer == null)
        {
            sfxPlayer = this.GetComponent<AudioSource>();
        }
        sfxPlayer.volume = GameParameters.SfxVolume;

    }

    // Update is called once per frame
    void Update()
    {
        // SI TIR POSSIBLE
        if(!GameManagerScript.instance.pause && canShoot == true)
        {
            // JOUEUR 1
            if(numPlayer == NumPlayer.P1)
            {
                // TIR SIMPLE
                if (Input.GetButton("P1 - FireButton"))
                {
                    canShoot = false;
                    Shoot();
                }

                // TIR DIRECTIONNEL
                if (Input.GetAxisRaw("P1 - FireX") != 0 || Input.GetAxisRaw("P1 - FireY") != 0)
                {
                    canShoot = false;
                    Shoot();
                }
            }

            // JOUEUR 2
            else
            {
                // TIR SIMPLE
                if (Input.GetButton("P2 - FireButton"))
                {
                    canShoot = false;
                    Shoot();
                }

                // TIR DIRECTIONNEL
                if (Input.GetAxisRaw("P2 - FireX") != 0 || Input.GetAxisRaw("P2 - FireY") != 0)
                {
                    canShoot = false;
                    Shoot();
                }
            }
        }
    }

    void SetCanShootToTrue()
    {
        canShoot = true;
	}

    void SingleFire() {

        float shootingDirection = gameObject.GetComponent<PlayerMovement>().getAngle();
        GameObject bullet = Instantiate(bulletPrefab, getFirePointPosition(playerTransform.position, shootingDirection), Quaternion.Euler(0, 0, shootingDirection));
        bullet.GetComponent<Bullet>().setColor(playerColor);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.rotation = shootingDirection;
        rb.AddForce(rb.transform.right * bulletForce, ForceMode2D.Impulse);

        JouerSon(Sons.InGame.Shoot1);

        Invoke("SetCanShootToTrue", 0.33f);
	}

    void Shotgun() {
        SingleFire(); // Placeholder, obviously.
	}

    void Shoot()
    {
        switch (weapon)
        {
            case "shotgun":
                Shotgun();
                break;
            default:
                SingleFire();
                break;
		}
	}

    public Vector3 getFirePointPosition(Vector3 playerPosition, float playerAngle) {
        return playerPosition;
        Vector3 firePoint = playerPosition;
        float verticalFactor = 0.0f;
        float horizontalFactor = 0.5f;
        float verticalOffset = 0.15f;
        float horizontalOffset = 0.24f;
        firePoint = firePoint + new Vector3(Mathf.Cos(playerAngle)*horizontalFactor + horizontalOffset, Mathf.Sin(playerAngle)*verticalFactor + verticalOffset, 0);
        return firePoint;
	}

    public void JouerSon(Sons.InGame SonAJouer)
    {
        string chemin = "Sounds/InGame/" + SonAJouer.ToString();
        sfxPlayer.clip = Resources.Load(chemin, typeof(AudioClip)) as AudioClip;
        sfxPlayer.Play();
    }
}
