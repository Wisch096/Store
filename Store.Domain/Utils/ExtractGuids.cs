﻿using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Utils;

public static class ExtractGuids
{
    public static IEnumerable<Guid> Extract(IList<CreateOrderItemCommand> items)
    {
        return items.Select(item => item.Product).ToList();
    }
}