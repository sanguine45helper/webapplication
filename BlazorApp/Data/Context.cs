using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Data;

public class TicketContext : DbContext
{
    public DbSet<ProgrammerJunior> ProgrammerJuniors { get; set; }
    public string DbPath { get; }

    public TicketContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "ticketdatabase.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}