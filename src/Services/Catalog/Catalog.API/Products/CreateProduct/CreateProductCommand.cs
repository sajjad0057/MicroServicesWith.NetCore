﻿namespace Catalog.API.Products.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price) : ICommand<CreateProductCommandResult>;

