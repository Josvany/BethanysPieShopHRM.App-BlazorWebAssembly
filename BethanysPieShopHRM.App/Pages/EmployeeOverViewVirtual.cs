﻿using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.App.Pages
{
    public partial class EmployeeOverViewVirtual
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        private readonly float itemHeight = 50;

        protected async override Task OnInitializedAsync()
        {
            Employees = (await EmployeeDataService.GetLongEmployeeList()).ToList();
        }

        private readonly int totalNumberOfEmployees = 1000;

        public async ValueTask<ItemsProviderResult<Employee>> LoadEmployees(ItemsProviderRequest request)
        {
            //assume that we have asked the API the total number in a separate call

            var numberOfEmployees = Math.Min(request.Count, totalNumberOfEmployees - request.StartIndex);
            var EmployeeListItems = await EmployeeDataService.GetTakeLongEmployeeList(request.StartIndex, numberOfEmployees);

            return new ItemsProviderResult<Employee>(EmployeeListItems, totalNumberOfEmployees);
        }
    }
}
