﻿
namespace Ordering.Application.Dtos;

public record PaymentDto(string CardName, string CardNumber, string CardHolderName, string Expiration, string Cvv, int PaymentMethod);
