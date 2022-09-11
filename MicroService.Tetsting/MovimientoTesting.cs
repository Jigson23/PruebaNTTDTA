using MicroService.Aplicaciones.Servicios;
using MicroService.Dominio;
using MicroService.Infraestructura.API.Controllers;
using MicroService.Infraestructura.API.DTOs;
using MicroService.Infraestructura.Datos.Contextos;
using MicroService.Infraestructura.Datos.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace MicroService.Tetsting
{
    public class MovimientoTesting
    {
        private readonly MovimientoController _controller;

        public MovimientoTesting()
        {
            _controller = new MovimientoController();
        }


        [Fact]
        public void ConsultarReporteOK()
        {
            ReportMovimientoQueryParameters parameters = new ReportMovimientoQueryParameters();
            parameters.beginDate = DateTime.Now;
            parameters.endDate = DateTime.Now;
            parameters.cuenta = "12345";

            var result = _controller.GetReport(parameters);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CrearMovimientoCuentaNoExiste() {
            Movimientos movimiento = new Movimientos();
            movimiento.cuenta = new Cuenta();
            movimiento.cuenta.numeroCuenta = "12345";
            movimiento.valor = 100;
            movimiento.tipoMovimiento = "credito";

            BadRequestObjectResult result = (BadRequestObjectResult)_controller.Post(movimiento);
            Exception exception;
            exception = (Exception)result.Value;

            Assert.Equal("La cuenta no existe", exception.Message);
            
        }


    }
}
