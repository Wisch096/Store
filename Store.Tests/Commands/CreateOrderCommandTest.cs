﻿using Store.Domain.Commands;
using Store.Domain.Commands.Interfaces;

namespace Store.Tests.Commands;

[TestClass]
public class CreateOrderCommandTest
{
    [TestMethod]
    [TestCategory("Commands")]
    public void Dado_um_comando_invalido_o_pedido_nao_deve_ser_gerado()
    {
        var command = new CreateOrderCommand();
        command.Customer = string.Empty;
        command.ZipCode = "47813122";
        command.PromoCode = "huahauhau";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Validate();
        
        Assert.AreEqual(!command.IsValid, false);
    }
}