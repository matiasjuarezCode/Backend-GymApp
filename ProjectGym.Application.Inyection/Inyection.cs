﻿using Microsoft.Extensions.DependencyInjection;
using ProjectGym.Infraestructure;
using ProjectGym.Service.Implementation;
using ProjectGym.Service.Inferface;
using System;
using ProjectGym.Domain.Entities;
using ProjectGym.Infraestructure.Repository;
using ProjectGym.Domain.Repository;
using ProjectGym.Service.Interface;

namespace ProjectGym.Application.Inyection
{
    public class Inyection
    {
        public static void ConfigurationServices(IServiceCollection servicios)
        {

            servicios.AddDbContext<DataContext>();


            servicios.AddTransient<IEmployeeRepository, EmployeeRepository>();
            servicios.AddTransient<ISegurityRepository, SegurityRepository>();
            servicios.AddTransient<IProductRepository, ProductRepository>();
            servicios.AddTransient<ICustomerRepository, CustomerRepository>();
            servicios.AddTransient<IPlanRepository, PlanRepository>();
            servicios.AddTransient<IInscriptionRepository, InscriptionRepository>();

            servicios.AddTransient<IRepository<Employee>, Repository<Employee>>();
            servicios.AddTransient<IRepository<Product>, Repository<Product>>();
            servicios.AddTransient<IRepository<Customer>, Repository<Customer>>();
            servicios.AddTransient<IRepository<Plan>, Repository<Plan>>();
            servicios.AddTransient<IRepository<Inscription>, Repository<Inscription>>();



        }
    }
}
