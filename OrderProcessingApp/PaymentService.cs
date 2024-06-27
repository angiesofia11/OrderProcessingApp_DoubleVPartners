using System;
using System.Threading.Tasks;

//Clase que simula la validación del pago
public class PaymentService
{
    public async Task<bool> ValidatePaymentAsync(Payment payment)
    {
        await Task.Delay(1000);//Simula el tiempo que tarda en validarse un pago
        return true;
    }
}