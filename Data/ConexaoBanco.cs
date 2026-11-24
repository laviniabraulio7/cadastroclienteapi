
// Importa as classes da biblioteca Npgsql,
// responsável pela comunicação entre C# e PostgreSQL.
using Npgsql;

// Define que a classe pertence ao namespace ClienteApi.Data.
namespace ClienteApi.Data;

// Declara a classe pública responsável pela conexão com o banco.
public class ConexaoBanco : IAsyncDisposable
{
    private readonly NpgsqlDataSource _fonteDados;

    public ConexaoBanco(IConfiguration configuration)
    {
        string stringConexao =
            configuration.GetConnectionString("Postgres")
            ?? throw new InvalidOperationException(
                "A conexão Postgres não foi configurada."
            );

        _fonteDados = NpgsqlDataSource.Create(stringConexao);
    }

    public async Task<NpgsqlConnection> CriarConexaoAsync()
    {
        return await _fonteDados.OpenConnectionAsync();
    }

    public async Task<bool> TestarAsync()
    {
        await using NpgsqlConnection conexao =
            await CriarConexaoAsync();

        await using NpgsqlCommand comando =
            new NpgsqlCommand("SELECT 1;", conexao);

        object? resultado =
            await comando.ExecuteScalarAsync();

        return Convert.ToInt32(resultado) == 1;
    }

    public async ValueTask DisposeAsync()
    {
        await _fonteDados.DisposeAsync();
    }
}
