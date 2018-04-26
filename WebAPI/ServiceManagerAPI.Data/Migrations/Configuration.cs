namespace ServiceManagerAPI.Data.Migrations
{
    using ServiceManagerAPI.Entities.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ServiceManagerAPI.Data.ApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ServiceManagerAPI.Data.ApiContext context)
        {
            if (!context.Services.Any())
            {
                Service service_1 = new Service()
                {
                    ServiceName = "CLICK ME TO DISAPPEAR",
                    Description = "REMOVES ELEMENT FROM UI AND DB."
                };

                Service service_2 = new Service()
                {
                    ServiceName = "Software Development",
                    Description = "Develop a new web and mobile application for the company."
                };

                Service service_3 = new Service()
                {
                    ServiceName = "Cloud Service",
                    Description = "CI and DevOp services with Azure."
                };

                Service service_4 = new Service()
                {
                    ServiceName = "Outsourcing",
                    Description = "Improve existing software development teams and departments."
                };

                //TO DO: for-loop for these operations
                context.Services.Add(service_1);
                context.Services.Add(service_2);
                context.Services.Add(service_3);
                context.Services.Add(service_4);
            }

           

            if (!context.Orders.Any())
            {
                Service service = new Service();
                service = context.Services.FirstOrDefault(s => s.ServiceName == "Software Development");
                Order order_1 = new Order()
                {
                    OrderName = "Forex JSC project",
                    Description = "Develop a new trading platform.",
                    Service = service
                };

                context.Orders.Add(order_1);
            }

            if (!context.Customers.Any())
            {
                Service service = new Service();
                service = context.Services.FirstOrDefault(s => s.ServiceName == "Software Development");
                Order order = new Order();
                order = context.Orders.FirstOrDefault(o => o.OrderName == "Forex JSC");
                order = order ?? new Order()
                {
                    OrderName = "Forex JSC project",
                    Description = "Develop a new trading platform.",
                    Service = service
                };

                Customer customer_1 = new Customer()
                {
                    CustomerName = "Forex JSC"
                };
                customer_1.Orders.Add(order);

                context.Customers.Add(customer_1);
            }

            if (!context.Employees.Any())
            {
                Employee employee_1 = new Employee()
                {
                    EmployeeName = "Ivan Petrov"
                };
                Customer customer = new Customer();
                customer = context.Customers.FirstOrDefault(c => c.Id == 1);
                employee_1.Customers.Add(customer);
                context.Employees.Add(employee_1);
            }
        }
    }
}
