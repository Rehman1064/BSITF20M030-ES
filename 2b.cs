using System;
using System.Collections.Generic;

interface IAirTrafficControl
{
    void RegisterAircraft(Aircraft aircraft);
    void NotifyAircraftInEmergency(Aircraft reportingAircraft, string emergencyMessage);
}

class Aircraft
{
    private readonly string registrationCode;
    private readonly IAirTrafficControl airTrafficControl;

    public Aircraft(string registrationCode, IAirTrafficControl airTrafficControl)
    {
        this.registrationCode = registrationCode;
        this.airTrafficControl = airTrafficControl;
        airTrafficControl.RegisterAircraft(this);
    }

    public string RegistrationCode => registrationCode;

    public void ReceiveWarning(string message)
    {
        Console.WriteLine($"Aircraft {registrationCode} receives warning: {message}");
    }

    public void ReportEmergency(string emergencyMessage)
    {
        Console.WriteLine($"Aircraft {registrationCode} reports emergency: {emergencyMessage}");
        airTrafficControl.NotifyAircraftInEmergency(this, emergencyMessage);
    }
}

class AirTrafficControl : IAirTrafficControl
{
    private readonly List<Aircraft> registeredAircrafts = new List<Aircraft>();

    public void RegisterAircraft(Aircraft aircraft)
    {
        registeredAircrafts.Add(aircraft);
    }

    public void NotifyAircraftInEmergency(Aircraft reportingAircraft, string emergencyMessage)
    {
        foreach (var otherAircraft in registeredAircrafts)
        {
            if (otherAircraft != reportingAircraft)
            {
                otherAircraft.ReceiveWarning(emergencyMessage);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        var airTrafficControl = new AirTrafficControl();

        var aircraft1 = new Aircraft("A1", airTrafficControl);

        aircraft1.ReportEmergency("Mayday! Engine failure, requesting assistance!");
    }
}
