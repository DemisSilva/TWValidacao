using Microsoft.AspNetCore.Mvc;
using TWValidacao.Models;
using TWValidacao.Validators;

namespace TWValidacao.Controllers;

public class UserController : Controller
{
    public IActionResult Create()
    {
        ViewData["Title"] = "Cadastro de Usuarios";

        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateUserViewModel model)
    {
        var validator = new CreateUserValidator();
        var results = validator.Validate(model);

        if(!ModelState.IsValid)
        {
            Console.WriteLine("Houveram erros de validacao");
            ViewData["Title"] = "Cadastro de Usuarios";
            return View();
        }
        Console.WriteLine("Nao erros de validacao");
        return RedirectToAction();
    }
}