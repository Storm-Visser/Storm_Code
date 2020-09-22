package com.carparking.cars;

import java.awt.Color;

public class car
{
    private String LP;
    private Color color;

    public car(String licensePlate, Color color)
    {
        this.LP = licensePlate;
        this.color = color;
    }

    public String getLP() {
        return LP;
    }

    public void setLP(String LP) {
        this.LP = LP;
    }

    public Color getColor() {
        return color;
    }

    public void setColor(Color color) {
        this.color = color;
    }
}
