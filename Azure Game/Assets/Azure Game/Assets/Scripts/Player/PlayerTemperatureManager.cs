using UnityEngine;
using System.Collections;

public class PlayerTemperatureManager : MonoBehaviour
{
    float m_charge;
    public int m_chargeIncrementor, m_chargeDecrementor, m_tempIncrementor, m_maxCharge;
    public GameManager gameManager;    

	// Use this for initialization
	void Start ()
    {
        m_charge = 0;
        m_maxCharge = 100;
        m_chargeIncrementor = 1;
        m_chargeDecrementor = 2;
        m_tempIncrementor = 2;
    }
	
	// Update is called once per frame
	void Update ()
    {        
        //if the player is colder than the room
        if (gameManager.player.m_temperature < gameManager.m_targetTemperature)
        {
            //if the player is trying to decrease their temperature
            if (gameManager.player.m_decreaseTemp)
            {
                //if they have charge
                if (m_charge > m_chargeDecrementor)
                {
                    //decrease temperature by using charge
                    m_charge -= m_chargeDecrementor;
                    gameManager.player.m_temperature -= Time.deltaTime * m_tempIncrementor;
                }
            }
            else
            {
                //increase their temperature
                gameManager.player.m_temperature += Time.deltaTime * m_tempIncrementor;
            }
        }
        //if the player is hotter than the room
        else if (gameManager.player.m_temperature > gameManager.m_targetTemperature)
        {
            //if the player is trying to decrease their temperature
            if (gameManager.player.m_increaseTemp)
            {
                //if they have charge
                if (m_charge < m_chargeDecrementor)
                {
                    //increase temperature using charge
                    m_charge -= m_chargeDecrementor;
                    gameManager.player.m_temperature += Time.deltaTime * m_tempIncrementor;
                }
            }
            //decrease their temperature
            gameManager.player.m_temperature -= Time.deltaTime * m_tempIncrementor;
        }

        //increase the charge unless cap is reached
        if (m_charge < m_maxCharge)
        {
            m_charge += m_chargeIncrementor;
        }
    }
}
