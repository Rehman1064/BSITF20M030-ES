using System;

interface IDeviceCommand
{
    void Execute();
}

class TurnOnCommand : IDeviceCommand
{
    private readonly ElectronicDevice device;

    public TurnOnCommand(ElectronicDevice device)
    {
        this.device = device;
    }

    public void Execute()
    {
        device.TurnOn();
    }
}

class TurnOffCommand : IDeviceCommand
{
    private readonly ElectronicDevice device;

    public TurnOffCommand(ElectronicDevice device)
    {
        this.device = device;
    }

    public void Execute()
    {
        device.TurnOff();
    }
}

class ElectronicDevice
{
    private string deviceName;

    public ElectronicDevice(string name)
    {
        this.deviceName = name;
    }

    public void TurnOn()
    {
        Console.WriteLine($"{deviceName} is turned on.");
    }

    public void TurnOff()
    {
        Console.WriteLine($"{deviceName} is turned off.");
    }
}

class RemoteController
{
    private IDeviceCommand deviceCommand;

    public void SetDeviceCommand(IDeviceCommand command)
    {
        this.deviceCommand = command;
    }

    public void PressButton()
    {
        deviceCommand.Execute();
    }
}

class Program
{
    static void Main()
    {
        var television = new ElectronicDevice("Television");

        var turnOnCommand = new TurnOnCommand(television);
        var turnOffCommand = new TurnOffCommand(television);

        var remoteController = new RemoteController();

        remoteController.SetDeviceCommand(turnOnCommand);
        remoteController.PressButton();

        remoteController.SetDeviceCommand(turnOffCommand);
        remoteController.PressButton();
    }
}
