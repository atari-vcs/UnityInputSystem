using System;
using System.Collections;
using System.Collections.Generic;

public static class ControllerNames
{
    public static List<string> ControllerName(string controllerName)
    {
        List<string> controller = new List<string>();
        switch (controllerName)
        {
            case "Classic":
                controller.Add("Cetus CDC Device");
                break;
            case "Modern":
                controller.Add("Keyboard Hub");
                break;
            case "Xbox":
                controller.Add("PlayStation 3 Memory Card Adaptor");
                controller.Add("Xbox360 Controller");
                break;
            case "XboxBluetooth":
                controller.Add("DCP-J152N");
                break;
        }
        return controller;
    }
}