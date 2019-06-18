using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCreator : MonoBehaviour {

    public GameObject spike;
    public GameObject ball;
    //public GameObject Obstaclea;
    //public GameObject Obstacleb;
    //public GameObject Obstaclec;
    //public GameObject Obstacled;
    //public GameObject Obstaclee;
    //public GameObject Obstaclef;
    //public GameObject Obstacleg;
    public GameObject[] Obstacle = new GameObject[12];

    public GameObject StarFirst;
    public GameObject StarSecond;
    public GameObject StarThird;

    Vector3 spikePosition;
    Quaternion SpikeRotation;
    Vector3 BlockPosition;
    Vector3 StarPosition;

    float spikeXPosition;
    float timer;
    float timerBlock = 4f;
    float timerStar;
    int rmd;
    int rmdBlock;

    private void Start()
    {
        SpikeRotation.Set(0, 0, 0, 0);
        spikeXPosition = 3.3f;
    }

    void Update () {
        timer += Time.deltaTime;
        timerBlock += Time.deltaTime;

        //random miejsce dla kolcow
        if (timer >= 2f )
        {
            rmd = Random.Range(0, 2);
            if(rmd == 0)
            {
                spikePosition.Set(spikeXPosition, ball.transform.position.y + Random.Range(9.5f, 12f), 0);
            }
            else if (rmd == 1)
            {
                spikePosition.Set(spikeXPosition * -1, ball.transform.position.y + Random.Range(9.5f, 10f), 0);
            }


            Instantiate(spike, spikePosition, SpikeRotation);

            timer = 0;
        }

        //tworzenie przeszkod
        if (timerBlock >= 3f)
        {
            rmdBlock = Random.Range(0, 12);

            BlockPosition.Set(0, ball.transform.position.y + Random.Range(10.5f, 12f), 0);
            Instantiate(Obstacle[rmdBlock], BlockPosition, SpikeRotation);

            //switch (rmdBlock)
            //{
            //    case 0:
            //        Instantiate(Obstaclea, BlockPosition, SpikeRotation);
            //        break;
            //    case 1:
            //        Instantiate(Obstacleb, BlockPosition, SpikeRotation);
            //        break;
            //    case 2:
            //        Instantiate(Obstaclec, BlockPosition, SpikeRotation);
            //        break;
            //    case 3:
            //        Instantiate(Obstacled, BlockPosition, SpikeRotation);
            //        break;
            //    case 4:
            //        Instantiate(Obstaclee, BlockPosition, SpikeRotation);
            //        break;
            //    case 5:
            //        Instantiate(Obstaclef, BlockPosition, SpikeRotation);
            //        break;
            //    case 6:
            //        Instantiate(Obstacleg, BlockPosition, SpikeRotation);
            //        break;
            //    default:
            //        break;
            //}
            timerBlock = 0;
        }
        timerStar += Time.deltaTime;

        StarPosition.Set(Random.Range(-3f, 3f), ball.transform.position.y + Random.Range(10.5f, 12f), 0);

        if (timerStar >= 5f)
        {
            rmd = Random.Range(0, 6);
            switch (rmd)
            {
                case 0:
                    Instantiate(StarFirst, StarPosition, SpikeRotation);
                    break;
                case 1:
                    Instantiate(StarFirst, StarPosition, SpikeRotation);
                    break;
                case 2:
                    Instantiate(StarFirst, StarPosition, SpikeRotation);
                    break;
                case 3:
                    Instantiate(StarSecond, StarPosition, SpikeRotation);
                    break;
                case 4:
                    Instantiate(StarSecond, StarPosition, SpikeRotation);
                    break;
                case 5:
                    Instantiate(StarThird, StarPosition, SpikeRotation);
                    break;
                default:
                    break;
            }
            timerStar = 0;
        }

    }
}
