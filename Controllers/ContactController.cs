using Impacto_Solucoes_Digitais.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace Impacto_Solucoes_Digitais.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendContato(Contato objet)
        {
            if (!ModelState.IsValid)
            {
                ViewData["message"] = "Informações Inválidas!";
                return View("Contato", objet);
            }

            var emailMsg = new MailMessage();
            emailMsg.Subject = "Contato de " + objet.Nome;//contato da msg
            emailMsg.From = new MailAddress("julianosgs@yahoo.com.br");//email que envia a msg
            emailMsg.To.Add("julianosgs@yahoo.com.br");//endereço que recebe o email
            emailMsg.IsBodyHtml = true;

            //body da msg em html
            emailMsg.Body = "<p>Nome: " + objet.Nome + "</p>" +
                            ",<p>Email: " + objet.Email + "</p>" +
                            "<p>Mensagem: " + objet.Message + "</p>";

            var client = new SmtpClient("smtp.yahoo.com", 587);//provedor de email
            client.Credentials = new NetworkCredential("julianosgs@yahoo.com.br", "minha senha");
            client.EnableSsl = true;//habilitando o Ssl


            try
            {
                client.Send(emailMsg);
            }
            catch (Exception ex)
            {

                ViewData["message"] = "Falha ao enviar a mensagem :" + ex.Message;
            }

            return View("SendContato");

        }
    }
}
