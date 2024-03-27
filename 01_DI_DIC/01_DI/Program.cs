
Injector injector = new Injector();
Client client = injector.ResolveClient();
client.RunService();


interface IService
{
    public void Execute();
}

class ServiceOne : IService
{
    public void Execute()
    {
        Console.WriteLine("ServiceOne::Execute()");
    }
}

class ServiceTwo : IService
{
    public void Execute()
    {
        Console.WriteLine("ServiceTwo::Execute()");
    }
}

class Client
{
    private IService service;

    public Client(IService service)
    {
        this.service = service;
    }
    public void RunService()
    {
        service.Execute();
    }
}

class Injector
{
    public Client ResolveClient()
    {
        ServiceTwo service = new ServiceTwo();
        Client client = new Client(service);            // DI
        return client;
    }
}