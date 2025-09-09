using biblioteca.DTO.Autor;
using biblioteca.Models;

namespace biblioteca.Services.Livro
{
    public interface ILivrointerfaces 
    {
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);
        Task<ResponseModel<List<LivroModel>>> ListarLivros();

        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto);
    }
}
