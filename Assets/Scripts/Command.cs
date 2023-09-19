﻿using UnityEngine;

public abstract class Command
{
    public Rigidbody m_rb;
    public float timeStamp;
    public abstract void Execute();
}