using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Infraestructura.API.DTOs
{
    public class ReportMovimientoQueryParameters
    {
        [BindRequired]
        public DateTime beginDate { get; set; }

        [BindRequired]
        public DateTime endDate { get; set; }

        [BindRequired]
        public string cuenta { get; set; }
    }
}
