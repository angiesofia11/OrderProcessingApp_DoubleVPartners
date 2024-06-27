using System;
using System.Threading.Tasks;

//Clase EmailSErvice que simula el envío de correos electrónicos
public class EmailService
{
    public async Task<bool> SendOderConfirmationEmailAsync (Order order)
    {
        await Task.Delay(1000); //Simula el tiempo que demora en enviarse el correo
        Console.WriteLine($"La confirmación del pedido fue enviada al correo {order.EmailCustomer} para la orden {order.OrderId}.");
        return true;

    }
}