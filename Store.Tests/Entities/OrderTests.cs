using Store.Domain.Entities;

namespace Store.Tests.Entities;

[TestClass]
public class OrderTests
{
    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
    {
        var customer = new Customer("Matheus Wisch", "wisch.dev@gmail.com");
        var order = new Order(customer, 0, null);
        Assert.AreEqual(8, order.Number.Length);
    }
    
    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
    {
        var customer = new Customer("Matheus Wisch", "wisch.dev@gmail.com");
        var order = new Order(customer, 0, null);
        Assert.AreEqual(8, order.Number.Length);
    }
}