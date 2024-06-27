 
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var emailService = new EmailService();
        var paymentService = new PaymentService();
        var orderProcessor = new OrderProcessor(emailService, paymentService);

        //Crea instancia de órdenes de compra
        var order = new Order("John Doe", "john.doe@gmail.com" , Products.Laptop, 1, 999.99m, PaymentMethod.TarjetaCredito);
        var order2 = new Order( "Jane Doe", "jane.doe@gmail.com" , Products.Mouse, 3, 999.99m, PaymentMethod.TransferenciaBancaria);
        var order3 = new Order( "Ana Pearson", "anapearson@gmail.com" , Products.Teclado, 3, 999.99m, PaymentMethod.PSE);
        var order4 = new Order( "Victor Douglas", "vicdouglas@gmail.com" , Products.Pantalla, 7, 999.99m, PaymentMethod.TarjetaCredito);

        //Crea una lista de tareas para procesar las órdenes en paralelo
        var tasks = new List<Task>
        {
            orderProcessor.ProcessOrderAsync(order),
            orderProcessor.ProcessOrderAsync(order2),
            orderProcessor.ProcessOrderAsync(order3),
            orderProcessor.ProcessOrderAsync(order4)
        };

        await Task.WhenAll(tasks); //Espera a que todas las órdenes sean procesadas

        Console.WriteLine("Todas las ordenes fueron procesadas.");
    }
}
