using Microsoft.AspNetCore.Mvc;
using MvcClienteApiDoctores.Services;
using NugetDoctores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClienteApiDoctores.Controllers
{
    public class DoctoresController : Controller
    {
        private ServiceApiDoctores service;

        public DoctoresController(ServiceApiDoctores service)
        {
            this.service = service;
        }
        public async Task<IActionResult> DoctoresEspecialidad()
        {
            List<Doctor> doctores = await this.service.GetDoctoresAsync();
            List<string> especialidades = await this.service.GetEspecialidadesAsync();
            ViewBag.especialidades = especialidades;
            return View(doctores);
        }

        [HttpPost]
        public async Task<IActionResult> DoctoresEspecialidad(string especialidad)
        {
            List<Doctor> doctores = await this.service.GetDoctoresEspecialidadAsync(especialidad);
            List<string> especialidades = await this.service.GetEspecialidadesAsync();
            ViewBag.especialidades = especialidades;
            return View(doctores);
        }
    }
}
