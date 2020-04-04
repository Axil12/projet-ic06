using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    SpriteRenderer rend;
    Color playerColor;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
    public float shootDelay = 0.25f;
    public bool canShoot = true;
    public string weapon = "singleShot";

    Transform playerTransform;

    public string shootRight = "h";
    public string shootDown = "g";
    public string shootLeft = "f";
    public string shootUp = "t";


    void Start()
    {
        playerColor = GetComponent<PlayerCharacteristics>().playerColor;
        rend = GetComponent<SpriteRenderer>();
        rend.color = playerColor;

        playerTransform = gameObject.GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
        //singleKeyShooting();
        fourDirectionsShooting();
    }

    void singleKeyShooting() {
        if(Input.GetKey("space"))
        {
            float shootingDirection = gameObject.GetComponent<PlayerMovement>().getAngle();
            Shoot(shootingDirection);
		}
	}

    void fourDirectionsShooting() {
        if (!(Input.GetKey(shootUp) || Input.GetKey(shootRight) || Input.GetKey(shootDown) || Input.GetKey(shootLeft)))
            return;

        float shootingDirection = 0;
        if (Input.GetKey(shootDown))
            shootingDirection = -90;
        else if (Input.GetKey(shootLeft))
            shootingDirection = 180;
        else if (Input.GetKey(shootUp))
            shootingDirection = 90;

        Shoot(shootingDirection);
            
	}


    public Vector3 getFirePointPosition(Vector3 playerPosition, float playerAngle) {
        Vector3 firePoint = playerPosition;
        float verticalFactor = 0.3f;
        float horizontalFactor = 0.3f;
        float verticalOffset = 0.0f;
        float horizontalOffset = 0.0f;
        firePoint = firePoint + new Vector3(Mathf.Cos(playerAngle*Mathf.Deg2Rad)*horizontalFactor + horizontalOffset, Mathf.Sin(playerAngle*Mathf.Deg2Rad)*verticalFactor + verticalOffset, 0);
        return firePoint;
	}

    void setCanShootToTrue(){canShoot = true;}

    void singleShot(float shootingDirection) {
        Invoke("setCanShootToTrue", 0.25f);
        GameObject bullet = Instantiate(bulletPrefab, getFirePointPosition(playerTransform.position, shootingDirection), Quaternion.Euler(0, 0, shootingDirection));
        bullet.GetComponent<Bullet>().setColor(playerColor);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.rotation = shootingDirection;
        rb.AddForce(rb.transform.right * bulletForce, ForceMode2D.Impulse);
	}

    void shotgunShot(float shootingDirection) {
        Invoke("setCanShootToTrue", 0.33f);
        GameObject bullet1 = Instantiate(bulletPrefab, getFirePointPosition(playerTransform.position, shootingDirection), Quaternion.Euler(0, 0, shootingDirection));
        GameObject bullet2 = Instantiate(bulletPrefab, getFirePointPosition(playerTransform.position, shootingDirection + 10), Quaternion.Euler(0, 0, shootingDirection + 10));
        GameObject bullet3 = Instantiate(bulletPrefab, getFirePointPosition(playerTransform.position, shootingDirection - 10), Quaternion.Euler(0, 0, shootingDirection - 10));
        bullet1.GetComponent<Bullet>().setColor(playerColor);
        bullet2.GetComponent<Bullet>().setColor(playerColor);
        bullet3.GetComponent<Bullet>().setColor(playerColor);
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb1.rotation = shootingDirection;
        rb2.rotation = shootingDirection;
        rb3.rotation = shootingDirection;
        rb1.AddForce(rb1.transform.right * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(rb2.transform.right * bulletForce, ForceMode2D.Impulse);
        rb3.AddForce(rb3.transform.right * bulletForce, ForceMode2D.Impulse);
	}

    void tripleShot(float shootingDirection) {
        Invoke("setCanShootToTrue", 0.4f);
        GameObject bullet1 = Instantiate(bulletPrefab, getFirePointPosition(playerTransform.position, shootingDirection), Quaternion.Euler(0, 0, shootingDirection));
        GameObject bullet2 = Instantiate(bulletPrefab, getFirePointPosition(playerTransform.position + new Vector3(Mathf.Cos(shootingDirection*0.017453f)*0.2f,Mathf.Sin(shootingDirection*0.017453f)*0.2f,0), shootingDirection), Quaternion.Euler(0, 0, shootingDirection));
        GameObject bullet3 = Instantiate(bulletPrefab, getFirePointPosition(playerTransform.position + new Vector3(Mathf.Cos(shootingDirection*0.017453f)*0.4f,Mathf.Sin(shootingDirection*0.017453f)*0.4f,0), shootingDirection), Quaternion.Euler(0, 0, shootingDirection));
        bullet1.GetComponent<Bullet>().setColor(playerColor);
        bullet2.GetComponent<Bullet>().setColor(playerColor);
        bullet3.GetComponent<Bullet>().setColor(playerColor);
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb1.rotation = shootingDirection;
        rb2.rotation = shootingDirection;
        rb3.rotation = shootingDirection;
        rb1.AddForce(rb1.transform.right * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(rb2.transform.right * bulletForce, ForceMode2D.Impulse);
        rb3.AddForce(rb3.transform.right * bulletForce, ForceMode2D.Impulse);
	}

    void Shoot(float shootingDirection)
    {
        if (!canShoot)
            return;
        else
            canShoot = false;

        if (weapon == "shotgun") {
            shotgunShot(shootingDirection);
		}
        else if (weapon == "burst") {
            tripleShot(shootingDirection);  
		}
        else {
            singleShot(shootingDirection);  
		}
	}
}
