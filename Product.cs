using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_and_Abe;
public class Product : ProductTypeId
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool Available { get; set; }

    public int TypeId { get; set; }

    public DateTime DateStocked { get; set; }

    public int DaysOnShelf
    {
        get
        {
            TimeSpan timeOnShelf = DateTime.Now - DateStocked;
            return timeOnShelf.Days;
        }
    }
 }
