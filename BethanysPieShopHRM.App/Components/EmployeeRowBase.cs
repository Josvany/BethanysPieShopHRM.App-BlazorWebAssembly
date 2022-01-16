using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.App.Components
{
    public class EmployeeRowBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }
    }
}
