using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTest.Models;


public class Branch
{
    public int ID { get; set; }
    public string BranchName { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string LocationName { get; set; }
    public string City { get; set; }
    public List<Service> Services { get; set; }
}

public class Service
{
    public int ID { get; set; }
    public string ServiceName { get; set; }
}
