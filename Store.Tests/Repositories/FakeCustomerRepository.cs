﻿using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Tests.Repositories;

public class FakeCustomerRepository : ICustomerRepository
{
    public Customer? Get(string document)
    {
        return document == "12345678911" ? new Customer("Matheus Wisch", "teteu@gmail.com") : null;
    }
}