using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    SpriteRenderer rend;
    Color playerColor;

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
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space") && canShoot)
        {
            canShoot = false;
            Shoot();
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
}
