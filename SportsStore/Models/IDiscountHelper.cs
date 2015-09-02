using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SportsStore.WebUI.Entities
{
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }
}