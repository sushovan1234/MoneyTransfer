﻿namespace MoneyTransfer.Models
{
    public class ApiResponse
    {
        public Status? Status { get; set; }
        public Errors? Errors { get; set; }
        public Params? Params { get; set; }
        public Data? Data { get; set; }
        public Pagination? Pagination { get; set; }
    }

    public class Status
    {
        public int Code { get; set; }
    }

    public class Errors
    {
        public object? Validation { get; set; } 
    }

    public class Params
    {
        public string? Date { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public string? PostType { get; set; }
        public string? PerPage { get; set; }
        public string? Page { get; set; }
        public string? Slug { get; set; }
        public string? Q { get; set; }
    }

    public class Data
    {
        public List<Payload>? Payload { get; set; }
    }

    public class Payload
    {
        public string? Date { get; set; }
        public string? PublishedOn { get; set; }
        public string? ModifiedOn { get; set; }
        public List<Rate>? Rates { get; set; }
    }

    public class Rate
    {
        public Currency? Currency { get; set; }
        public string? Buy { get; set; }
        public string? Sell { get; set; }
    }

    public class Currency
    {
        public string? Iso3 { get; set; }
        public string? Name { get; set; }
        public int? Unit { get; set; }
    }

    public class Pagination
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public Links? Links { get; set; }
    }

    public class Links
    {
        public string? Prev { get; set; }
        public string? Next { get; set; }
    }

}
