using UnityEngine;

class TurnLeft : Command
{
    float m_sidewaysForce;

    public TurnLeft(Rigidbody rb, float sidewaysForce)
    {
        m_rb = rb;
        m_sidewaysForce = sidewaysForce;
    }
    public override void Execute()
    {
        timeStamp = Time.timeSinceLevelLoad;
        m_rb.AddForce(-m_sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}