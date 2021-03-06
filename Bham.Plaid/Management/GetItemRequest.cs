﻿namespace Bham.Plaid.Management
{
    /// <summary>
    /// Represents a request for plaid's '/item/get' endpoint. The POST /item/get endpoint returns information about the status of an <see cref="Entity.Item"/>.
    /// </summary>
    /// <seealso cref="RequestBase" />
    public class GetItemRequest : RequestBase { }
}