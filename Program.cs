using System;

using System;

// Implementor - реализация интерфейса устройства
interface IDevice
{
    void TurnOn();
    void TurnOff();
}

// Конкретные реализации ConcreteImplementor для устройств: телевизор и радио
class TV : IDevice
{
    public void TurnOn() => Console.WriteLine("Телевизор включен");
    public void TurnOff() => Console.WriteLine("Телевизор выключен");
}

class Radio : IDevice
{
    public void TurnOn() => Console.WriteLine("Радио включено");
    public void TurnOff() => Console.WriteLine("Радио выключено");
}

// Абстракция Abstraction - пульт управления (один для телевизора и для радио)
class RemoteControl
{
    protected IDevice _device;

    public RemoteControl(IDevice device) => _device = device;

    public void PowerOn() => _device.TurnOn();
    public void PowerOff() => _device.TurnOff();
}

// Раасширенная абстракция RefinedAbstraction
class AdvancedRemote : RemoteControl
{
    // Наследуем конструктор от базовой Абстракции
    public AdvancedRemote(IDevice device) : base(device) { }

    public void Mute() => Console.WriteLine("Звук выключен"); // Добавляем метод выкл. звука
}

class Program
{
    static void Main()
    {
        var tvRemote = new RemoteControl(new TV()); // экземпляр класса пульта для ТВ
        tvRemote.PowerOn();

        // Продвинутый пульт для Radio
        var radioRemote = new AdvancedRemote(new Radio()); // экземпляр класса пульта для радио
        radioRemote.PowerOn();
        radioRemote.Mute();
    }
}