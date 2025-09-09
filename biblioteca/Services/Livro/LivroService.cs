using biblioteca.Data;
using biblioteca.DTO.Autor;
using biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace biblioteca.Services.Livro
{
    public class LivroService : ILivrointerfaces
    {
        private readonly AppDbContext _context;
        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            var resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = _context.Livros.Include(a => a.Autor).FirstOrDefault(livroBanco => livroBanco.Id == idLivro);
                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro Localizado!";
                    return Task.FromResult(resposta);
                }
                resposta.Dados = livro;
                resposta.Mensagem = "Livro Localizado!";
                return Task.FromResult(resposta);
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return Task.FromResult(resposta);
            }

        }

        public Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            var resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = _context.Livros.ToList();
                if (livros.Count == 0)
                {
                    resposta.Mensagem = "Nenhum registro Localizado!";
                    return Task.FromResult(resposta);
                }
                resposta.Dados = livros;
                resposta.Mensagem = "Livros Localizados!";
                return Task.FromResult(resposta);
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return Task.FromResult(resposta);
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = new LivroModel()
                {
                    Titulo = livroCriacaoDto.Titulo,
                    Autor = _context.Autores.FirstOrDefault(a => a.Id == livroCriacaoDto.AutorId)

                };
                _context.Livros.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Livro Criado com Sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<LivroModel>>> EdicarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            var resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = _context.Livros.FirstOrDefaultAsync(l => l.Id == livroEdicaoDto.Id);
                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro Localizado!";
                    return resposta;
                }
                livro.Result.Titulo = livroEdicaoDto.Titulo;
                livro.Result.Autor = _context.Autores.FirstOrDefault(a => a.Id == livroEdicaoDto.AutorId);
                _context.Livros.Update(livro.Result);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Livro Editado com Sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            var resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(l => l.Id == idLivro);
                if (livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado para exclusão!";
                    return resposta;
                }

                _context.Remove(livro);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Livro removido com sucesso!";

                return resposta;


            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}