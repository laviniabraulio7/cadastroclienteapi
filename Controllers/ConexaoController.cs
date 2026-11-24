
/*
Importa o namespace onde está localizada
a classe ConexaoBanco.
*/
using ClienteApi.Data;

/*
Importa os recursos do ASP.NET Core MVC.
Esse namespace fornece classes e atributos como:
ControllerBase, ApiController, Route, HttpGet e IActionResult.
*/
using Microsoft.AspNetCore.Mvc;

/*
Define que esta classe pertence ao namespace ClienteApi.Controllers.
O namespace ajuda a organizar os Controllers da aplicação.
*/
namespace ClienteApi.Controllers;

/*
Informa ao ASP.NET Core que esta classe
será utilizada como Controller de uma API.
*/
[ApiController]

/*
Define a rota principal deste Controller.
Todas as rotas declaradas nesta classe começarão com:
api/conexao
*/
[Route("api/conexao")]

/*
Declara a classe pública ConexaoController.
A classe herda de ControllerBase para receber recursos
necessários à criação de Controllers de uma API.
*/
public class ConexaoController : ControllerBase
{
    /*
    Declara um atributo privado que armazenará
    uma referência para a classe ConexaoBanco.
    */
    private readonly ConexaoBanco _conexaoBanco;

    /*
    Construtor da classe ConexaoController.
    O ASP.NET Core fornecerá automaticamente um objeto
    ConexaoBanco por meio da injeção de dependência.
    */
    public ConexaoController(ConexaoBanco conexaoBanco)
    {
        // Armazena no atributo privado o objeto recebido
        // pelo parâmetro do construtor.
        _conexaoBanco = conexaoBanco;
    }

    /*
    Define que o método abaixo responderá
    a requisições HTTP do tipo GET.
    A rota completa será:
    GET /api/conexao/testar
    */
    [HttpGet("testar")]

    /*
    Declara o método público e assíncrono Testar.
    Task indica que o método executará uma operação assíncrona.
    IActionResult permite que o método devolva uma resposta HTTP.
    */
    public async Task<IActionResult> Testar()
    {
        /*
        Chama o método TestarAsync() da classe ConexaoBanco.
        O await aguarda o término do teste de conexão.
        O resultado true ou false será armazenado na variável conectou.
        */
        bool conectou =
            await _conexaoBanco.TestarAsync();

        /*
        O método Ok() cria uma resposta HTTP com o código 200 — OK.
        O conteúdo será convertido automaticamente para JSON.
        */
        return Ok(
            new
            {
                mensagem =
                    conectou
                        ? "Conexão realizada com sucesso."
                        : "Não foi possível conectar."
            }
        );
    }
}
